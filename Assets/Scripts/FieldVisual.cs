using UnityEngine;

public class FieldVisual
{
    public void SetFieldVisual(Cell[,] fieldCells)
    {
        for (int y = 0; y < fieldCells.GetLength(0); y++)
        {
            for (int x = 0; x < fieldCells.GetLength(1); x++)
            {
                if (fieldCells[y,x].hasObj)
                {
                    fieldCells[y,x].blockInCell.GetComponent<Block>().squareSprite = fieldCells[y,x].colorSprite;
                    fieldCells[y,x].blockInCell.GetComponent<Block>().empty = false;
                    
                }
                else
                {
                    fieldCells[y,x].blockInCell.GetComponent<Block>().empty = true;
                }
                fieldCells[y,x].blockInCell.GetComponent<Block>().SetSprite();
            }
        }
    }

    public void SetBlockParticleOnDestroy(Vector2 position)
    {
        BlockParticle blockParticle = PoolManager.Instanse.SpawnFromPool("BlockParticle", new Vector3 (position.x, position.y),Quaternion.identity).GetComponent<BlockParticle>();
        
        blockParticle.particle.Play();
    } 
}
