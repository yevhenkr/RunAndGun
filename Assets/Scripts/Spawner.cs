using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using System.Linq;
using Random = System.Random;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Pailsade;
    [SerializeField] private LevelController LevelController ;
    [SerializeField] private int countPalisade;
    [SerializeField] private int maebyPointSpawn;
    private  Vector3 pailsadePos;
    private List<int> array = new List<int>();
    public List<GameObject> pailsadeList = new List<GameObject>();
   
    private void Awake()
    {
        pailsadePos = new Vector3(Pailsade.transform.position.x,Pailsade.transform.position.y, Pailsade.transform.position.z);
        for (int i = 0; i <= maebyPointSpawn; i++)
        {
            array.Add(i);
        }
    }

    public void SpawnPlayer()
    {
        var go =Instantiate(Player);
        go.GetComponent<Hero>().OnDied += LevelController.LevelFinish;
    }
    
    public void SpawnPailsade()
    {
        MixList();
        for (int j = 0; j <= countPalisade; j++)
        {
            var temp = pailsadePos.x;
           pailsadePos.x += array[j];
            
            pailsadeList.Add(Instantiate(Pailsade, pailsadePos, Quaternion.identity));
            pailsadePos.x = temp;
        }
    }
    
    public void MixList()
    {
        System.Random rand = new System.Random();
        array = array.OrderBy((x) => rand.Next()).ToList();
    }
}
