using UnityEngine;

public static class EventController
{
    public static System.Action GameStart;
    public static System.Action GameRestart;
    public static System.Action SwitchMusicInBackMenu;
    public static System.Action BackToMenuFromGameplay;
    public static System.Action gameOver;
    public static System.Action rotateImpossible;
    public static System.Action FigureChanged;
    public static System.Action lineDestroing;
    public static System.Action <Vector2> blockDestroing;
    public static System.Action LeaderboardOpening;
    public static System.Action <string, int> PlayerAdded;
}
