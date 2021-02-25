using System.Collections;
using UnityEngine;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private RectTransform GameOverImage;
    [SerializeField] private float timeShowGameOver;
    
    public LevelController levelController;

    private void Awake()
    {
        OpenMainMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CloseMainMenu();
        }
    }

    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
    }

    private void CloseMainMenu()
    {
        MainMenu.SetActive(false);
        levelController.LevelStart();
    }

    public void ShowGameOver()
    {
        var y = GameOverImage.anchoredPosition.y;
        GameOverImage.DOAnchorPos(Vector2.zero, timeShowGameOver);
        StartCoroutine(OnObj());
        IEnumerator OnObj()
        {
            yield return new WaitForSeconds(timeShowGameOver);
            GameOverImage.DOAnchorPos(new Vector2(0,-y), timeShowGameOver);
            yield return new WaitForSeconds(timeShowGameOver);
            GameOverImage.DOAnchorPos(new Vector2(0,y), 0);

            
        }
    }
}