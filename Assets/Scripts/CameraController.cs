using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float dumping;
    private Vector2 ofset = new Vector2(2f,1f);
    public bool isLeft;
    private Transform player;
    private int lastX;


    private void Start()
    {
        CameraRestart();
    }

    public void CameraRestart()
    {
        ofset = new Vector2(Math.Abs(ofset.x), ofset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Hero").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - ofset.x, player.position.y - ofset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + ofset.x, player.position.y + ofset.y, transform.position.z);
        }
    }

    private void Update()
    {
        Debug.Log("Player = " + player);
        if (player)
        {
            
            Debug.Log("111111");
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(player.position.x - ofset.x, player.position.y + ofset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + ofset.x, player.position.y + ofset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}