using UnityEngine;
using TMPro;
using DG.Tweening;

public class UiGameplay : MonoBehaviour
{
    [SerializeField] TMP_Text rotateImpossible;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text time;

    float currentGameplayTime;
    bool animationPlaying;

    public void SetGameplayTime() 
    {
        time.text = "Time: "  + (int)currentGameplayTime;
    }
    public void UpdateScore()
    {
        score.text = "Score: " + ScoreKeeper.score;
    }
    public void UpdateGameplayTime()
    {
        currentGameplayTime += Time.deltaTime;
    }
    public void TimeReset()
    {
        currentGameplayTime = 0;
    }
    
    void Start()
    {
        EventController.rotateImpossible += OnRotateImpossible;
        UpdateScore();
    }

    void OnRotateImpossible()
    {
        if (!animationPlaying)
        {
            animationPlaying = true;
            rotateImpossible.DOFade(1f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).OnComplete(() => {animationPlaying = false;});
        } 
    }
}
