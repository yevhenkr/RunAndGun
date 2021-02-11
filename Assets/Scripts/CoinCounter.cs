using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance { get; private set; }
    [SerializeField]private Text coinConter;
    [SerializeField]private int coinCount;
    
    private void Awake()
    {
        Instance = this;
        coinCount = 0;
    }

    public void AddCoin()
    {
        coinCount++;
        coinConter.text = coinCount.ToString();
    }
}