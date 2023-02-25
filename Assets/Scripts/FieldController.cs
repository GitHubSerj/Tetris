using UnityEngine;

public class FieldController : MonoBehaviour
{
    
    [SerializeField] float stepDelay;
    [SerializeField] Figure figureGhost;

    FieldLogic fieldLogic = new FieldLogic();
    FieldVisual fieldVisual = new FieldVisual();
    FigureManager figureManager;
    Sprite spriteColor;
    Figure currentFigure;
    float stepTime;
    float firstStepDelay = 0.4f;
    Vector3 startPosition;
    bool gameContinuing;


    public void StartGameplay()
    {
        NullingFigure();
        fieldLogic.CreateStartFieldLogic();

        figureManager = FindObjectOfType<FigureManager>();

        stepTime = Time.time + firstStepDelay;
        gameContinuing = true;
        startPosition = new Vector3((int)((FieldLogic.Width/2) - 2), FieldLogic.VisibleHeight - 1);
    }

    

    void Start()
    {
        EventController.blockDestroing += fieldVisual.SetBlockParticleOnDestroy;
        EventController.BackToMenuFromGameplay += GameStopContinuing;
    }

    void Update()
    {
        if (!gameContinuing )
        {
            return;
        }
        
        if (currentFigure == null)
        {
            SetNewCurrentFigure();
        }
        
        GameplayInputs();

        if (Time.time >= stepTime)
        {
            StepDown();
        }
        if (currentFigure != null)
        {
            DisplayGhost(currentFigure);
        }

        fieldVisual.SetFieldVisual(fieldLogic.UpdateLogic());
        CheckGameOver();


        void SetNewCurrentFigure()
        {
            currentFigure = figureManager.figures[Random.Range(0, figureManager.figures.Length)];

            currentFigure.gameObject.SetActive(true);
            if (currentFigure.FigureType == FigureType.I)
            {
                currentFigure.gameObject.transform.position = new Vector3(startPosition.x, startPosition.y - 1);
            }
            else
            {
                currentFigure.gameObject.transform.position = startPosition;
            }
            
            currentFigure.figureRotateIndex = FigureRotate.First;
            Data.SetBlocksOnPosition(currentFigure, Data.GetBlocksOnPosition(currentFigure));
            figureGhost.gameObject.SetActive(true);
        }

        void GameplayInputs()
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryToMove(Vector3.left, currentFigure);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryToMove(Vector3.right, currentFigure);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                TryStepDown();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fall();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                TryToRotate(rotateIndex: -1);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                TryToRotate(rotateIndex: 1);
            }
        }

        void CheckGameOver()
        {
            for (int x = 0; x < FieldLogic.Width; x++)
            {
                if (fieldLogic.fieldCells[FieldLogic.VisibleHeight,x].hasObj)
                {
                    GameOver();
                }
            }
        }
        
    }

    void NullingFigure()
    {
        if (currentFigure != null)
        {
            currentFigure.gameObject.SetActive(false);
        }
        currentFigure = null;
    }

    void GameOver()
    {
        GameStopContinuing();
        PoolManager.Instanse.Deactive("Block");
        EventController.gameOver?.Invoke();
    }

    void GameStopContinuing()
    {
        gameContinuing = false;
    }

    void DisplayGhost(Figure currentFigure)
    {
        for (int i = 0; i < figureGhost.blocks.Length; i++)
        {
            figureGhost.blocks[i].gameObject.transform.position = currentFigure.blocks[i].gameObject.transform.position;
        }

        while(TryToMove(Vector3.down,figureGhost)) {}
    }

    void TryToRotate(int rotateIndex)
    {
        FigureRotate oldIndex = currentFigure.figureRotateIndex;
        currentFigure.figureRotateIndex = (FigureRotate)Wrap((int)currentFigure.figureRotateIndex + rotateIndex, 0 , 4);
        
        Block[] proxyBlocks = Data.GetBlocksOnPosition(currentFigure);
        for (int i = 0; i < proxyBlocks.Length; i++)
        {
            Vector3 posToCheck = proxyBlocks[i].transform.position;
            if (posToCheck.y < 0 || posToCheck.x < 0 || posToCheck.y >= fieldLogic.fieldCells.GetLength(0) || 
                posToCheck.x >= fieldLogic.fieldCells.GetLength(1) || fieldLogic.fieldCells[(int)posToCheck.y,(int)posToCheck.x].hasObj)
            {
                EventController.rotateImpossible?.Invoke();
                currentFigure.figureRotateIndex = oldIndex;
            }
        }

        Data.SetBlocksOnPosition(currentFigure, Data.GetBlocksOnPosition(currentFigure));
    }

    void StepDown()
    {
        stepTime = Time.time + stepDelay;
        TryStepDown();
        
    }
    void TryStepDown()
    {
        if(!TryToMove(Vector3.down, currentFigure))
        {
            AudioManager.instance.PlaySound2D("Fall");
            NextFigure();
        }
    }

    void Fall()
    {
        while(TryToMove(Vector3.down, currentFigure)){}

        AudioManager.instance.PlaySound2D("Fall");
        NextFigure();
    }

    void NextFigure()
    {
        
        for (int i = 0; i < currentFigure.blocks.Length; i++)
        {
            int yPos = (int)currentFigure.blocks[i].gameObject.transform.position.y;
            int xPos = (int)currentFigure.blocks[i].gameObject.transform.position.x;
            
            fieldLogic.fieldCells[yPos, xPos].hasObj = true;
            fieldLogic.fieldCells[yPos, xPos].colorSprite = currentFigure.figureSprite;
            
            
        }
        currentFigure.gameObject.SetActive(false);
        figureGhost.gameObject.SetActive(false);
        currentFigure = null;
        EventController.FigureChanged?.Invoke();
        stepTime = Time.time + firstStepDelay;
    }

    int Wrap(int input, int min, int max)
    {
        if (input < min) 
        {
            return max - (min - input) % (max - min);
        } 
        else 
        {
            return min + (input - min) % (max - min);
        }
    }

    bool TryToMove(Vector3 move, Figure figure)
    {
        for (int i = 0; i < figure.blocks.Length; i++)
        {
            Vector3 posToCheck = figure.blocks[i].transform.position + move;

            if (posToCheck.y < 0 || posToCheck.x < 0 || posToCheck.y >= fieldLogic.fieldCells.GetLength(0) || 
                posToCheck.x >= fieldLogic.fieldCells.GetLength(1) || fieldLogic.fieldCells[(int)posToCheck.y,(int)posToCheck.x].hasObj)
            {
                return false;
            }
        }
        figure.gameObject.transform.position += move;
        return true;
    }
}
