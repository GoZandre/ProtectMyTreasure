using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Animator _menuAnimator;

    [SerializeField]
    private CharacterControler _playerController;

    private void Start()
    {
        _menuAnimator = GetComponent<Animator>();
    }


    public void StartGame()
    {
        _menuAnimator.SetTrigger("PlayGame");
        _playerController.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
