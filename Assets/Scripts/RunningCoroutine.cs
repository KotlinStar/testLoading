using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningCoroutine : MonoBehaviour
{
    private static RunningCoroutine _Instance;
    public static GameObject HostObject;

    public static RunningCoroutine ÑoroutineHost
    {
        get
        {
            if (_Instance == null)
            {
                HostObject = new GameObject("RunningCoroutine");
               _Instance = HostObject.AddComponent<RunningCoroutine>(); 
            }
            return _Instance;            
        }
    }

    public static void DestroyObject()
    {
        Debug.Log("Stop loading");
        Destroy(HostObject);
    }
}
