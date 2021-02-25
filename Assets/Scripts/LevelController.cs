using System;
using System.Collections;
using UnityEngine;



public class LevelController : MonoBehaviour
{
    [SerializeField] private CameraController levelCamera;
    [SerializeField] private GameController gameController;
    [SerializeField] private Spawner Spawner;
    [SerializeField] private CoinSpawner coinSpawner;


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
        gameController.ShowGameOver();
        gameController.OpenMainMenu();
        
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
