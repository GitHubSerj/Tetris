using UnityEngine;

public class SpritesLibrary : MonoBehaviour
{
    public Sprite[] sprites;
    
    public static SpritesLibrary instance;


    void Awake() 
    {
        instance = this;
    }
}
