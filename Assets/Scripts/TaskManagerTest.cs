using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TaskManagerTest : MonoBehaviour
{
    [SerializeField] private Button startTask;

    [Header("Target Object")]
    [Space]
    [SerializeField] private GameObject targetObject;

    [Header("Download Objects")]
    [Space]
    [SerializeField] private List<DownloadableObject> downloadableObject;

    private List<DownloadableObject> DownloadableObjects { get => downloadableObject; set => downloadableObject = value; }
    private TaskManager _taskManager = new TaskManager();

    private void Start()
    {
        startTask.onClick.AddListener(StartTaskQueueClick);
    }

    private void StartTaskQueueClick()            
    {
        AddTaskFromDownloadableObjects();
        Debug.Log("Start loading");
    }

    private void AddTaskFromDownloadableObjects()           
    {
        for (int i = 0; i < downloadableObject.Count; i++)
        {
            _taskManager.AddTask(ObjectLoadingDelay(DownloadableObjects[i].TaskObject, DownloadableObjects[i].LoadingTime));
        }
    }    

    private IEnumerator ObjectLoadingDelay (GameObject loadingObject, float delay)
    {
        Instantiate(loadingObject, targetObject.transform);
        yield return new WaitForSeconds(delay);
    }
}

[System.Serializable]
public class DownloadableObject
{
    [SerializeField] private GameObject taskObject;
    [SerializeField] private float loadingTime;
   
    public GameObject TaskObject { get => taskObject; set => taskObject = value; }

    public float LoadingTime { get => loadingTime; set => loadingTime = value; }

}

