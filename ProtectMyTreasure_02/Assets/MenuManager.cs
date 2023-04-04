using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Animator _menuAnimator;

    [SerializeField]
    private CharacterControler _playerController;

    [SerializeField]
    Spawner_Manager _spawnerManager;

    [SerializeField]
    private InGameUIManager _gameUIManager;

    private void Start()
    {
        _menuAnimator = GetComponent<Animator>();
    }


    public void StartGame()
    {
        _menuAnimator.SetTrigger("PlayGame");
        _playerController.gameObject.SetActive(true);
        _gameUIManager.gameObject.SetActive(true);
        _spawnerManager.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
