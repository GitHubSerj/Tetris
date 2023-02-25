using UnityEngine;

public class GlobalController : MonoBehaviour
{
    [SerializeField] GameObject field ;
    [SerializeField] FieldController fieldController;


    void Awake()
    {
        EventController.GameStart += OnStartGame;
        EventController.GameRestart += OnGameRestart;
        EventController.gameOver += OnGameOver;
    }

    void OnStartGame()
    {
        field.SetActive(true);
        fieldController.gameObject.SetActive(true);

        fieldController.StartGameplay();
    }
    void OnGameRestart()
    {
        field.SetActive(true);
        fieldController.gameObject.SetActive(true);

        fieldController.StartGameplay();
    }
    void OnGameOver()
    {
        field.SetActive(false);
        fieldController.gameObject.SetActive(false);
    }
}
