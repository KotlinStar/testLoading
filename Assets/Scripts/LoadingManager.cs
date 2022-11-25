using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadingManager : MonoBehaviour {
    [Header("Loading Text")]
    [Space]
    [SerializeField] private GameObject loadingText;
    [Header("Managers")]
    [Space]
    [SerializeField] private PlayerManager playerManager;
	[SerializeField] private InventoryManager inventoryManager;
	[SerializeField] private StateManager stateManager;

    private List<IGameManager> _startSequence = new List<IGameManager>();
	private int _numberCurrentManager = 0;


    void Awake()
    {
        loadingText.SetActive(true);

		_startSequence.Add(inventoryManager);            // порядок загрузки
		_startSequence.Add(stateManager);
        _startSequence.Add(playerManager);

		StartupManagers();
	}

	private void StartupManagers()
	{
		IGameManager manager = _startSequence[_numberCurrentManager];           
		manager.Startup();              
		StartCoroutine(LoadControl(manager));
	}

    private IEnumerator LoadControl(IGameManager manager)             // контроль изменение статуса загружаемого менеджера
    {
        while (true)
        {
            if (manager.status != ManagerStatus.Initializing)
            {
                if (_numberCurrentManager == _startSequence.Count - 1)
                {                  
                    loadingText.SetActive(false);  
                    break;
                }
                else
                {
                    Debug.Log("Загрузка следующего менеджера");
                    _numberCurrentManager++;
                    StopAllCoroutines();
                    StartupManagers();
                }
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Debug.Log("Загрузка всех менеджеров завершена");
        StopAllCoroutines();
    }
}
