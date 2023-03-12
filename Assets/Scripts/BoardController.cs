using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BoardController : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private Transform boardParent;
    private TileController[,] currentTileSet;
    [SerializeField]
    private GridLayoutGroup grid;
    private LevelData levelData;
    [SerializeField]
    private TextMeshProUGUI levelInfo;
    public static BoardController Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        
        levelData = MultiSceneValues.Instance.levelValue;
        currentTileSet = new TileController[levelData.gridSize, levelData.gridSize];
        SetBoard();

    }

    private void SetBoard()
    {
        grid.constraintCount = levelData.gridSize;
        if (levelData.gridSize == 6)
        {
            grid.cellSize = new Vector2(140,140);
        }
        else if(levelData.gridSize == 8)
        {
            grid.cellSize = new Vector2(110, 110);
        }

        for(int i = 0; i < levelData.gridSize; i++)
        {
            for (int j = 0; j < levelData.gridSize; j++)
            { 
                GameObject obj = Instantiate(tile, boardParent);
                TileController tileController = obj.GetComponent<TileController>();
                if (levelData.problem[i, j] == -1)
                {
                    tileController.textMesh.text = "";
                    tileController.tileValue = -1;
                }
                else if (levelData.problem[i, j] == 1)
                {
                    tileController.textMesh.text = "1";
                    tileController.tileValue = 1;
                    tileController.tileButton.interactable = false;
                }
                else if (levelData.problem[i, j] == 0)
                {
                    tileController.textMesh.text = "0";
                    tileController.tileValue = 0;
                    tileController.tileButton.interactable = false;
                }
                tileController.tileValue = levelData.problem[i, j];
                currentTileSet[i, j] = tileController;

            }
        }
        levelInfo.text = "#" + levelData.id + " | " + levelData.gridSize + "x" + levelData.gridSize + " | dif= " + levelData.difficulty;
    }

    public void CheckForWin()
    {
        bool flag = true;
        for (int i = 0; i < levelData.gridSize; i++)
        {
            for (int j = 0; j < levelData.gridSize; j++)
            {
                if (currentTileSet[i, j].tileValue != levelData.solution[i, j])
                {
                    flag = false;
                    break;
                }       
            }
            if (!flag)
            {
                break;
            }
        }
        if (flag)
        {
            Debug.Log("win");
        } 
    }

    public void HintSystem()
    {
        for (int i = 0; i < levelData.gridSize; i++)
        {
            for (int j = 0; j < levelData.gridSize; j++) 
            {
                if (currentTileSet[i, j].tileValue == -1)
                {
                    currentTileSet[i, j].tileValue = levelData.solution[i, j];
                    currentTileSet[i, j].textMesh.text = levelData.solution[i, j].ToString();
                    CheckForWin();
                    return;
                }
            }
        }
    }

    public void ResetBoard()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
