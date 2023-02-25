using UnityEngine;

public static class Data
{
    public static Block[] GetBlocksOnPosition(Figure figure)
    {
        Figure proxyFigure = PoolManager.Instanse.SpawnFromPool("Figure", figure.gameObject.transform.position, Quaternion.identity).GetComponent<Figure>();

        if (figure.FigureType == FigureType.I)
        {
            if (figure.figureRotateIndex == FigureRotate.First)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(0,2);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(2,2);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(3,2);
            }
            if (figure.figureRotateIndex == FigureRotate.Second)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(2,3);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(2,2);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,0);
            }
            if (figure.figureRotateIndex == FigureRotate.Third)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(3,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(0,1); 
            }
            if (figure.figureRotateIndex == FigureRotate.Fourth)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,0);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(1,3);
            }
        }

        if (figure.FigureType == FigureType.J)
        {
            if (figure.figureRotateIndex == FigureRotate.First)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(0,2);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(0,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,1);
            }
            if (figure.figureRotateIndex == FigureRotate.Second)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(2,2);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(1,0);
            }
            if (figure.figureRotateIndex == FigureRotate.Third)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(2,0);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(0,1); 
            }
            if (figure.figureRotateIndex == FigureRotate.Fourth)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(0,0);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,0);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(1,2);
            }
        }

        if (figure.FigureType == FigureType.L)
        {
            if (figure.figureRotateIndex == FigureRotate.First)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(0,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,2);
            }
            if (figure.figureRotateIndex == FigureRotate.Second)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,0);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,0);
            }
            if (figure.figureRotateIndex == FigureRotate.Third)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(0,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(0,0); 
            }
            if (figure.figureRotateIndex == FigureRotate.Fourth)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,0);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(0,2);
            }
        }
        
        if (figure.FigureType == FigureType.O)
        {
            if (figure.figureRotateIndex == FigureRotate.First)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,2);
            }
            if (figure.figureRotateIndex == FigureRotate.Second)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,2);
            }
            if (figure.figureRotateIndex == FigureRotate.Third)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,2);
            }
            if (figure.figureRotateIndex == FigureRotate.Fourth)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,2);
            }
        }

        if (figure.FigureType == FigureType.S)
        {
            if (figure.figureRotateIndex == FigureRotate.First)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(0,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,2);
            }
            if (figure.figureRotateIndex == FigureRotate.Second)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,0);
            }
            if (figure.figureRotateIndex == FigureRotate.Third)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,0);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(0,0); 
            }
            if (figure.figureRotateIndex == FigureRotate.Fourth)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,0);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(0,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(0,2);
            }
        }

        if (figure.FigureType == FigureType.T)
        {
            if (figure.figureRotateIndex == FigureRotate.First)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(0,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(1,2);
            }
            if (figure.figureRotateIndex == FigureRotate.Second)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,0);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,1);
            }
            if (figure.figureRotateIndex == FigureRotate.Third)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(0,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(1,0); 
            }
            if (figure.figureRotateIndex == FigureRotate.Fourth)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(1,0);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(0,1);
            }
        }

        if (figure.FigureType == FigureType.Z)
        {
            if (figure.figureRotateIndex == FigureRotate.First)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(0,2);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,2);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(2,1);
            }
            if (figure.figureRotateIndex == FigureRotate.Second)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(2,2);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(2,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(1,0);
            }
            if (figure.figureRotateIndex == FigureRotate.Third)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(2,0);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(1,0);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(0,1); 
            }
            if (figure.figureRotateIndex == FigureRotate.Fourth)
            {
                proxyFigure.blocks[0].transform.localPosition = new Vector3(0,0);
                proxyFigure.blocks[1].transform.localPosition = new Vector3(0,1);
                proxyFigure.blocks[2].transform.localPosition = new Vector3(1,1);
                proxyFigure.blocks[3].transform.localPosition = new Vector3(1,2);
            }
        }

        proxyFigure.gameObject.SetActive(false);
        return proxyFigure.blocks;
    }
   
    public static void SetBlocksOnPosition(Figure figure, Block[] proxyBlocks)
    {
        figure.blocks[0].transform.localPosition = proxyBlocks[0].transform.localPosition;
        figure.blocks[1].transform.localPosition = proxyBlocks[1].transform.localPosition;
        figure.blocks[2].transform.localPosition = proxyBlocks[2].transform.localPosition;
        figure.blocks[3].transform.localPosition = proxyBlocks[3].transform.localPosition;
    }
}
