﻿using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fierPoint;
    public GameObject bullet;
    public float setTimeFier;
    
    public float speedFier;

    private void Start()
    {
        speedFier = setTimeFier;
       // Debug.Log("speedFier = " + speedFier);
    }

    void Update()
    {
            SpeedFire();
    }

    private void SpeedFire()
    {
        if (speedFier < 0)
        {
            Shoot();
            speedFier = setTimeFier;
        }

        speedFier -= Time.deltaTime;
        
    }
    
    public void Shoot()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(fierPoint.position, fierPoint.right);
        if (hitInfo)
        {
//           Debug.Log(hitInfo.transform.name);
            Instantiate(bullet, fierPoint.position, fierPoint.rotation);
        }
    }
}