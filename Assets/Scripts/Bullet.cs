﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
     public int damage = 1;

    public Rigidbody2D rb;//todo privet

    // Start is called before the first frame update;;kkkllkkff
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.parent.gameObject);
    }

}
