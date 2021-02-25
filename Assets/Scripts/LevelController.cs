using System;
using System.Collections;
using UnityEngine;



public class LevelController : MonoBehaviour
{
    [SerializeField] private CameraController levelCamera;
    [SerializeField] private GameController gameController;
    [SerializeField] private Spawner Spawner;
    [SerializeField] private CoinSpawner coinSpawner;
    public bool Restart = false;


    private void Start()
    {
        Console.WriteLine(11111);
    }

    public void LevelStart()
    {
        Spawner.SpawnPlayer();
        Spawner.SpawnPailsade();
        CameraStart();
        coinSpawner.CoinSpawn();
    }
    public void CameraStart()
    {
        StartCoroutine(OnObj());
        IEnumerator OnObj()
        {
            yield return new WaitForSeconds(1f);
            levelCamera.enabled = true;
        }
    }
    
    public void LevelFinish()
    {
        DestroyEnemy();
        gameController.OpenMainMenu();
        //Надпись конц игры
        //появление заставки 
    }

    private void DestroyEnemy()
    {
        foreach (var VARIABLE in Spawner.pailsadeList)
        {
            Destroy(VARIABLE);
        }
        Spawner.pailsadeList.Clear();
    }
}
