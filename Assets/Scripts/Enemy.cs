using UnityEngine;

public class Enemy : MonoBehaviour
{
//    public int health ;
    public int damegeForTouch;
    public string tagHero = "Hero";

    public virtual void TakeDamage(int damage)
    {
//        health -= damage;
//        if (health <= 0)
//        {
//            Die();
//        }
    }

    public virtual void Die()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.Damage(1);
        }
    }
}
