using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTileData : MonoBehaviour
{
    public LevelData tileData;

    public void OnTileClick()
    {
        Debug.Log("id" + tileData.id);
        Debug.Log("grid" +tileData. gridSize);
        Debug.Log("difi" +tileData. difficulty);
        GameManager.Instance.currentLevel = tileData;
        MultiSceneValues.Instance.levelValue = tileData;
        MultiSceneValues.Instance.id = tileData.id;
        SceneManager.LoadScene(1);

    }

}
