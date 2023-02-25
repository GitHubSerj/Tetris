using UnityEngine;

public class Figure : MonoBehaviour
{
    [SerializeField] FigureType figureType;
    public FigureRotate figureRotateIndex;
    public Sprite figureSprite;
    public Block[] blocks;

    public FigureType FigureType => figureType;

    public Vector2Int[] cells { get; private set; }
    public Vector2Int[,] wallKicks { get; private set; }


    public void Start()
    {
        Data.SetBlocksOnPosition(this, Data.GetBlocksOnPosition(this));

        if (figureType == FigureType.ghost)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].sortingOrderWithBlock = 0;
            }
        }
        else
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].sortingOrderWithBlock = 1;
            }
        }
    }
}
