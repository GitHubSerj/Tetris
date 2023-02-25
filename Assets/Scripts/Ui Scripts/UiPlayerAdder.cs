using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UiPlayerAdder : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Button backButton;
    [SerializeField] TMP_Text invalidName;

    Text userNameInputText;
    string playerName;

    public string PlayerName => playerName;

    public bool animationPlaying;
    
    void Start() 
    {
        userNameInputText = GetComponent<Text>();

        inputField.onEndEdit.AddListener(InputPlayerName);
        backButton.onClick.AddListener(UiManager.instance.BackGameOver);
        backButton.onClick.AddListener(NulledField);
        
    }

    void InputPlayerName(string name)
    {
        if (name != null && Input.GetKeyDown(KeyCode.Return))
        {
            if (name.Contains(" "))
            {
                InvalidName();
                return;
            }

            playerName = name;
            Debug.Log(playerName);
            EventController.PlayerAdded?.Invoke(name, ScoreKeeper.score);
            UiManager.instance.OpenLeaderboard();
            NulledField();
        }
    }
    void InvalidName()
    {
        if (!animationPlaying)
        {
            animationPlaying = true;
            invalidName.DOFade(1f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).OnComplete(() => {animationPlaying = false;});
        } 
    }
    void NulledField()
    {
        inputField.text = null;
    }
}
