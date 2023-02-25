using UnityEngine;

public class FigureManager : MonoBehaviour
{
    public Figure[] figures;

    void Start() 
    {
        EventController.FigureChanged += OnFigureChanged;
    }
    void OnFigureChanged()
    {
        for (int i = 0; i < figures.Length; i++)
        {
            if(!figures[i].gameObject.activeSelf)
            {
                figures[i].transform.parent = transform;
                figures[i].figureRotateIndex = FigureRotate.First;
            }
        }
    }
}
