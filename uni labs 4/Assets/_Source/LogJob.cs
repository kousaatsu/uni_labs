using UnityEngine;
using UnityEngine.Jobs;
using Unity.Collections;
using Unity.Jobs;

public struct LogJob : IJob
{
    private float logValue;

    public LogJob(float value)
    {
        logValue = value;
    }

    public void Execute()
    {
        Debug.Log(Mathf.Log(logValue));
    }
}