using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}


	public void Startup()
	{
        status = ManagerStatus.Initializing;

        Debug.Log("Inventory manager starting...");
		
		// тут загружаемые данные
		
        

		status = ManagerStatus.Started;
        Debug.Log("Inventory manager finish...");
    }


}
