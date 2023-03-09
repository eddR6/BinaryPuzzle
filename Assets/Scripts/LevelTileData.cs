using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTileData : MonoBehaviour
{
    public int id;
    public int gridSize;
    public int difficulty;
    public int[,] problem;
    public int[,] solution;

    public void OnTileClick()
    {
        Debug.Log("id" + id);
        Debug.Log("grid" + gridSize);
        Debug.Log("difi" + difficulty);

    }

}
