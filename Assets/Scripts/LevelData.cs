using UnityEngine;

[CreateAssetMenu(fileName ="NewData", menuName ="New Level Data" )]
public class LevelData : ScriptableObject
{
    public int gridSize;
    public RowData[] rows;
    [System.Serializable]
    public class RowData
    {
        public int[] rowValue;
    }
}
