using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}

	public void Startup()
	{
        status = ManagerStatus.Initializing;
        Debug.Log("Player manager starting...");


        // тут загружаемые данные

        status = ManagerStatus.Started;
        Debug.Log("Player manager finish...");
    }
}
