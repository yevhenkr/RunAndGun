using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private LevelController LevelController;
    
    private void OnCollisionEnter2D(Collision2D collider)
    {
       
        if (collider.gameObject.tag == "Hero")
        {
            LevelController.playerWin = true;
            GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>().Die();
           LevelController.LevelFinish();
        }
    }
}
