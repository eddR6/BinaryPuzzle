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
    [SerializeField]
    private GameObject levelObject;
    [SerializeField]
    private Transform levelObjectParent;
    private List<GameObject> activeTiles;
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
        activeTiles = new List<GameObject>();
        LoadLevelsData();
        currentDifficulty = DefaultValues.DIFFICULTY;
        currentGrid = DefaultValues.GRIDSIZE;
        FilterLevels(currentGrid, currentDifficulty);
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
        List<LevelData> lv = levels.FindAll(delegate (LevelData temp)
        {
            return temp.gridSize == gridSize && temp.difficulty == difficulty;
        });
        //Debug.Log(gridSize + " " + difficulty);
        if (lv != null)
        {
            SetLevelTileData(lv);
        }

    }
    private void SetLevelTileData(List<LevelData> levelData)
    {
        if (activeTiles != null)
        {
            foreach(GameObject ob in activeTiles)
            {
                Destroy(ob);
            }
        }
        foreach (LevelData level in levelData)
        {
            GameObject obj = Instantiate(levelObject, levelObjectParent);
            activeTiles.Add(obj);
            LevelTileData data = obj.GetComponent<LevelTileData>();
            data.id = level.id;
            data.gridSize = level.gridSize;
            data.difficulty = level.difficulty;
            data.problem = level.problem;
            data.solution = level.solution;
        }
    }
}

