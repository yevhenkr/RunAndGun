using UnityEngine;

public class Palisade : Enemy
{
    
    public int Health;
    public GameObject Coin;

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Hero.Instance.tag)
        {
            Hero.Instance.Damage(damegeForTouch);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
        }
    }
}