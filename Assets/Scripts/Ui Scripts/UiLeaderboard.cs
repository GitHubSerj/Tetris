using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UiLeaderboard : MonoBehaviour
{
    [SerializeField] Button backToMainMenu;
    [SerializeField] TMP_Text [] players;
    [SerializeField] TMP_Text bestPlayersTitle;

    int showedNames;

    public void ShowPlayers()
    {
        if(JSONSaving.instance.Leaderboard.playersInLeaderboard.Count >= 5)
        {
            showedNames = 5;

            bestPlayersTitle.text = "Top " + showedNames + " players!";
        }
        else
        {
            showedNames = JSONSaving.instance.Leaderboard.playersInLeaderboard.Count;
            
            if (showedNames > 1)
            {
                bestPlayersTitle.text = "Top " + showedNames + " players!";
            }
            else if(showedNames == 1)
            {
                bestPlayersTitle.text = "Best player!";
            }
            else
            {
                bestPlayersTitle.text = "Leaderboard are empty. Change it! :)";
            }
        }

        JSONSaving.instance.Leaderboard.playersInLeaderboard = JSONSaving.instance.Leaderboard.playersInLeaderboard.OrderByDescending((p => p.score)).ToList();

        for (int i = 0; i < showedNames; i++)
        {
            string playerName = JSONSaving.instance.Leaderboard.playersInLeaderboard[i].name;
            int playerScore = JSONSaving.instance.Leaderboard.playersInLeaderboard[i].score;
            int position = i + 1;
            players[i].text = position.ToString() + " " + playerName + ", score: " + playerScore.ToString();
            players[i].gameObject.SetActive(true);
        }
    }

    void Start()
    {
        backToMainMenu.onClick.AddListener(UiManager.instance.BackToMainMenu);
    }
}
