using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSceneValues : MonoBehaviour
{
    public static MultiSceneValues Instance;
    public LevelData levelValue;
    public int id;
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
        DontDestroyOnLoad(this.gameObject);
    }


}
