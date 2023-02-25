using UnityEngine;

public class FieldLogic
{
    public Cell[,] fieldCells {get; set; }

    static int width = 10;
    static int visibleHeight = 20;
    static int hidedLines = 3;

    public static int Width => width;
    public static int VisibleHeight => visibleHeight;
    public static int TrueHeight => visibleHeight + hidedLines;
    
    
    public void CreateStartFieldLogic()
    {
        fieldCells = new Cell[TrueHeight,width];

        for (int y = 0; y < fieldCells.GetLength(0); y++)
        {
            for (int x = 0; x < fieldCells.GetLength(1); x++)
            {
                fieldCells[y,x] = new Cell ();
                fieldCells[y,x].blockInCell = PoolManager.Instanse.SpawnFromPool("Block", SpritesLibrary.instance.sprites[(int)SpriteIndex.emptyGrid], new Vector3(x,y));
                fieldCells[y,x].hasObj = false;
                fieldCells[y,x].blockInCell.SetActive(true);
                fieldCells[y,x].blockInCell.GetComponent<Block>().empty = true;
            }
        } 
    }

    public Cell[,] UpdateLogic()
    {
        for (int y = visibleHeight; y >= 0; y--)
        {
            int notEmptyCellsInLine = 0;

            for (int x = 0; x < fieldCells.GetLength(1); x++)
            {
                if (fieldCells[y,x].hasObj)
                {
                   notEmptyCellsInLine++; 
                }
            }
            if (notEmptyCellsInLine == width)
            {
                
                DestroyLine(y);
            }
        }
        return fieldCells;
    }

    void DestroyLine(int lineIndex)
    {
        EventController.lineDestroing?.Invoke();
        AudioManager.instance.PlaySound2D("DestroingLine");

        for (int x = 0; x < fieldCells.GetLength(1); x++)
        {
            EventController.blockDestroing?.Invoke(new Vector2(x, lineIndex));
        }

        for (int y = lineIndex; y < fieldCells.GetLength(0) - 1; y++)
        {
            for (int x = 0; x < fieldCells.GetLength(1); x++)
            {
                fieldCells[y,x].hasObj = fieldCells[y + 1, x].hasObj;
                fieldCells[y,x].colorSprite = fieldCells[y + 1,x].colorSprite;
            }
        }
    }
}
