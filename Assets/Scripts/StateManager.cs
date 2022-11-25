using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour, IGameManager
{

    public ManagerStatus status { get; private set; }

    public void Startup()
    {
        status = ManagerStatus.Initializing;
        Debug.Log("State manager starting...");

        // тут загружаемые данные
        StartCoroutine(TimeLoad());
       
    }

    private IEnumerator TimeLoad ()
    {

        yield return new WaitForSeconds(3);
        Debug.Log("State manager finish...");
        status = ManagerStatus.Started;
        StopCoroutine(TimeLoad());
    }
}
