using UnityEngine;
using UnityEngine.Jobs;
using Unity.Collections;
using Unity.Jobs;

public struct CyclicMovement : IJobParallelForTransform
{
    private float speed;
    private float deltaTime;
    private Vector3 axis;

    public CyclicMovement(float speed, float deltaTime, Vector3 axis)
    {
        this.speed = speed;
        this.deltaTime = deltaTime;
        this.axis = axis;
    }

    public void Execute(int index, TransformAccess transform)
    {
        float angle = speed * deltaTime;
        transform.position = Quaternion.AngleAxis(angle, axis) * transform.position;
    }
}