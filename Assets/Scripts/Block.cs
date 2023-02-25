using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject square;
    public Sprite squareSprite;
    public Sprite emptySprite;
    public bool empty;
    public int sortingOrderWithBlock;
    
    public void SetSprite()
    {
        if (empty)
        {
            square.GetComponent<SpriteRenderer>().sprite = emptySprite;
            square.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Sliced;
            square.GetComponent<SpriteRenderer>().size = new Vector2(1,1);

            SetSortingOrder(-1);
        }
        else
        {
            square.GetComponent<SpriteRenderer>().sprite = squareSprite;
            square.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Sliced;
            square.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
            
            SetSortingOrder(sortingOrderWithBlock);
        }
    }
    
    void Start()
    {
        if (transform.parent.GetComponent<Figure>())
        {
            squareSprite = transform.parent.GetComponent<Figure>().figureSprite;
        }
    }

    void SetSortingOrder(int sortingOrder)
    {
        square.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
    }
}
