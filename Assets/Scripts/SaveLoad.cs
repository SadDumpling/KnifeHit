using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public int maxLevelSaveData;
    public int applesSaveData;
    LevelMaster levelMaster;
    private void Awake()
    {
        levelMaster = FindObjectOfType<LevelMaster>();
        LoadGameResults();
    }
    private void CheckMaxLevel()
    {
        if (levelMaster.maxLevel < levelMaster.levelNumber) maxLevelSaveData = levelMaster.levelNumber;
        else maxLevelSaveData = levelMaster.maxLevel;
        applesSaveData = levelMaster.applesScore;
    }
    public void SaveGameResults()
    {
        CheckMaxLevel();
        PlayerPrefs.SetInt("MaxLevel", maxLevelSaveData);
        PlayerPrefs.SetInt("Apples", applesSaveData);
    }
    void LoadGameResults()
    {
        if (PlayerPrefs.HasKey("Apples"))
        {
            maxLevelSaveData = PlayerPrefs.GetInt("MaxLevel");
            applesSaveData = PlayerPrefs.GetInt("Apples");
        }
        else
        {
            maxLevelSaveData = 0;
            applesSaveData = 0;
        }
    }    
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
