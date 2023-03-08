using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelGroup", menuName = "New Level Group")]
public class LevelsGroup : ScriptableObject
{
    public LevelData[] levels;
}
