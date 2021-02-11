using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private float CountCoin;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float mixX;
    [SerializeField] private float maxY;

    public void CoinSpawn()
    {
        for (int i = 0; i < CountCoin; i++)
        {
            
            Vector3 position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(mixX,maxY));
            Instantiate(CoinPrefab, position, Quaternion.identity);
        }
    }

    public void CoinСollected()
    {

        Debug.Log("собран");
    }
      
}
