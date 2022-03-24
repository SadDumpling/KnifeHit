using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    GameObject recordSlot;
    GameObject appleSlot;
    GameObject levelSlot;
    LevelMaster levelNaster;

    private void Start()
    {
        levelNaster = FindObjectOfType<LevelMaster>();
        recordSlot = GameObject.Find("RecordSlot");
        appleSlot = GameObject.Find("AppleSlot");
        levelSlot = GameObject.Find("LevelSlot");
        UpdateUI();
    }
    public void UpdateUI()
    {
        if (recordSlot != null)
        {
            Text recordSlotTemp = recordSlot.GetComponent<Text>();
            recordSlotTemp.text = levelNaster.maxLevel.ToString();
        }
        if (appleSlot != null)
        {
            Text appleSlotTemp = appleSlot.GetComponent<Text>();
            appleSlotTemp.text = levelNaster.applesScore.ToString();
        }
        if (levelSlot != null)
        {
            Text levelSlotTemp = levelSlot.GetComponent<Text>();
            levelSlotTemp.text = levelNaster.levelNumber.ToString();
        }
    }
}
