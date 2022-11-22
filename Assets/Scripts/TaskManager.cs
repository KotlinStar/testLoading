using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager
{
    public ITask CurrentTask
    {
        get
        {
            return _currentTask;
        }
    }

    private ITask _currentTask;
    private List<ITask> _tasks = new List<ITask>();

    public void AddTask(IEnumerator taskAction, TaskPriorityEnum taskPriority = TaskPriorityEnum.Default)
    {
        var task = Task.Create(taskAction, taskPriority);
        ProcessingAddedTask(task, taskPriority);
    }

    public void Break()
    {
        if (_currentTask != null)
        {
            _currentTask.Stop();
        }
    }

    private void ProcessingAddedTask(ITask task, TaskPriorityEnum taskPriority)
    {
        switch (taskPriority)
        {
            case TaskPriorityEnum.Default:
                {
                    _tasks.Add(task);
                }
                break;
            case TaskPriorityEnum.High:
                {
                    _tasks.Insert(0, task);
                }
                break;
        }

        if (_currentTask == null)
        {
            _currentTask = GetNextTask();

            if (_currentTask != null)
            {
                _currentTask.Subscribe(TaskQueueProcessing).Start();
            }
        }
    }

    private void TaskQueueProcessing()
    {
        _currentTask = GetNextTask();

        if (_currentTask != null)
        {
            _currentTask.Subscribe(TaskQueueProcessing).Start();
        }
    }

    private ITask GetNextTask()
    {
        if (_tasks.Count > 0)
        {
            var returnValue = _tasks[0]; _tasks.RemoveAt(0);

            return returnValue;
        }
        else
        {
            RunningCoroutine.DestroyObject();

            return null;
        }
    }

}
