using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    public int levelNumber;
    public int maxLevel;
    public int applesScore;
    void Start()
    {
        Vibration.Init();
        SaveLoad sl = FindObjectOfType<SaveLoad>();
        maxLevel = sl.maxLevelSaveData;
        applesScore = sl.applesSaveData;
        DontDestroyOnLoad(this);
        levelNumber = 0;
        var ui = FindObjectOfType<UI>();
        ui.UpdateUI();
    }
}
