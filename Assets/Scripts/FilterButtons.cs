using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterButtons : MonoBehaviour
{   
    [SerializeField]
    private int gridSize;
    [SerializeField]
    private int difficulty;

    public void OnButtonClick()
    {
        if (gridSize != 0)
        {
            GameManager.Instance.FilterLevels(gridSize,GameManager.Instance.currentDifficulty);
        }
        else
        {
            GameManager.Instance.FilterLevels(GameManager.Instance.currentGrid,difficulty);
        }
    }
}
