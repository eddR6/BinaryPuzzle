using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelsGroup Levels;

    void Start()
    {
       LevelData lv;
       for (int i = 0; i < Levels.levels.Length; i++)
        {
            lv = Levels.levels[i];
            Debug.Log("id= "+lv.id);
            
            for(int j = 0; j < lv.rows.Length; j++)
            {
                Debug.Log("row= " + j);
                for(int k = 0; k < lv.rows[j].rowValue.Length; k++)
                {
                    Debug.Log("val= " + lv.rows[j].rowValue[k]);
                }
            }
        }
    }

}
