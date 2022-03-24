using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AppleData", menuName = "AppleData", order = 51)]
public class AppleData : ScriptableObject
{
    [SerializeField] private int appleChance;
    public int AppleChance
    {
        get
        {
            return appleChance;
        }
        set
        {
            if (value > 100) appleChance = 100;
            else if (value < 0) appleChance = 0;
            else appleChance = value;
        }
    }
    public void OnEnable()
    {
        if (appleChance > 100) appleChance = 100;
        else if (appleChance < 0) appleChance = 0;
    }
}
