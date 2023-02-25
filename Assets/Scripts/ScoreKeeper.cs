using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static int score {get; private set; }


    void Start()
    {
        EventController.GameStart += SetScoreZero;
        EventController.GameRestart += SetScoreZero;
        EventController.lineDestroing += IncreaseScore;
    }
    void SetScoreZero()
    {
        score = 0;
    }

    void IncreaseScore()
    {
        score++;
    }
}
