using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    public LevelController levelController;

    private void Awake()
    {
        OpenMainMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CloseMainMenu();
        }
    }

    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
    }

    private void CloseMainMenu()
    {
        MainMenu.SetActive(false);
        levelController.LevelStart();
    }
}