using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine;
using Unity.Jobs;
using UnityEngine.Jobs;

public class ObjectProcessor : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementRadius;
    [SerializeField] private float logarithmCooldown;
    [SerializeField] private float minLogValue;
    [SerializeField] private float maxLogValue;
    [SerializeField] private Vector3 rotationAxis;
    [SerializeField] private int objectCount;

    private Transform[] instantiatedTransforms;
    private TransformAccessArray transformArray;

    private NativeArray<float> logValues;
    private float lastLogTime;

    private void Start()
    {
        instantiatedTransforms = new Transform[objectCount];
        for (int i = 0; i < objectCount; i++)
        {
            Transform objTransform = Instantiate(objectPrefab, Random.insideUnitSphere * movementRadius, Quaternion.identity).transform;
            instantiatedTransforms[i] = objTransform;
        }

        transformArray = new TransformAccessArray(instantiatedTransforms);
        logValues = new NativeArray<float>(objectCount, Allocator.Persistent);
    }

    private void Update()
    {
        MoveObjectsInCircle();
        ComputeLogarithms();
    }

    private void MoveObjectsInCircle()
    {
        CyclicMovement cyclicMovement = new CyclicMovement(movementSpeed, Time.deltaTime, rotationAxis);
        JobHandle moveHandle = cyclicMovement.Schedule(transformArray);
    }

    private void ComputeLogarithms()
    {
        if (Time.time - lastLogTime >= logarithmCooldown)
        {
            lastLogTime = Time.time;
            LogJob logJob = new LogJob(Random.Range(minLogValue, maxLogValue), logValues);
            JobHandle logHandle = logJob.Schedule(transformArray);
        }
    }

    private void OnDestroy()
    {
        transformArray.Dispose();
        logValues.Dispose();
    }
}