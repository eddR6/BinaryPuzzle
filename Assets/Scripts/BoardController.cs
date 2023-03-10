using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private Transform boardParent;
    private GridLayoutGroup grid;
    private LevelData levelData;
    private void Start()
    {
        levelData = MultiSceneValues.Instance.levelValue;
        grid = this.gameObject.GetComponent<GridLayoutGroup>();
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
                }
                else if (levelData.problem[i, j] == 1)
                {
                    tileController.textMesh.text = "1";
                    tileController.tileButton.interactable = false;
                }
                else if (levelData.problem[i, j] == 0)
                {
                    tileController.textMesh.text = "0";
                    tileController.tileButton.interactable = false;
                }
            }
        }

    }
}
