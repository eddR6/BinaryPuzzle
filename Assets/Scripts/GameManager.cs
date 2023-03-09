using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private List<LevelData> levels;
    [HideInInspector]
    public int currentGrid;
    [HideInInspector]
    public int currentDifficulty;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

   
    void Start()
    {
        LoadLevelsData();
        currentDifficulty = DefaultValues.DIFFICULTY;
        currentGrid = DefaultValues.GRIDSIZE;

    
        List<LevelData> lv = levels.FindAll(delegate (LevelData temp)
          {
              return temp.gridSize == 6;
          });
        

    }

    private void LoadLevelsData()
    {
        string data = File.ReadAllText(Application.dataPath + "/LevelData/LevelCollection.json");
        levels = JsonConvert.DeserializeObject<List<LevelData>>(data);
    }

    public void FilterLevels(int gridSize,int difficulty)
    {
        currentGrid = gridSize;
        currentDifficulty = difficulty;

        Debug.Log(gridSize + " " + difficulty);
    }
}

