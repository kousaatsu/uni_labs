using UnityEngine;
using UnityEngine.Jobs;
using Unity.Collections;
using Unity.Jobs;

public struct LogJob : IJobParallelForTransform
{
    private float value;
    private NativeArray<float> logValues;

    public LogJob(float value, NativeArray<float> logValues)
    {
        this.value = value;
        this.logValues = logValues;
    }

    public void Execute(int index, TransformAccess transform)
    {
        float logResult = Mathf.Log(value);
        logValues[index] = logResult;
        Debug.Log($"Logarithm of {value} for object {index}: {logResult}");
    }
}