using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskPriorityEnum
{
    Default,
    High,
}

public interface ITask
{
    TaskPriorityEnum Priority { get; }
    void Start();
    ITask Subscribe(Action completeCallback);
    void Stop();
}
