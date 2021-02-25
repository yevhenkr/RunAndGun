using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float HealthMax;
    public Texture2D healthTexture;
    public float  xOffSet, yOffSet, maxBarWidth ,barBGWidth, barHeight = 5;
    private float currentHealth;
    void Start()
    {
        HealthMax = GetComponent<Palisade>().Health;
        currentHealth = HealthMax;
        
        barBGWidth = maxBarWidth+2;
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {  GetDamage(collision.gameObject.GetComponent<Bullet>().damage);
            ChangeBarLives();
        }
    }

    private void OnGUI()
    {
        Vector3 posScr = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        GUI.Box(new Rect(posScr.x -xOffSet, Screen.height - posScr.y - yOffSet, barBGWidth, barHeight), "");
        GUI.DrawTexture(new Rect(posScr.x, Screen.height - posScr.y - yOffSet, maxBarWidth, barHeight), healthTexture);
    }

    private void GetDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void ChangeBarLives()
    {
        var p = currentHealth / HealthMax;
        maxBarWidth = maxBarWidth * p;
    }
}