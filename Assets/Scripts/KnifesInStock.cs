using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifesInStock : MonoBehaviour
{
    private GameObject[] knifeIcons;
    [SerializeField] private GameObject knifeIconPrefab;
    private float yPositionMove = 0.40f;
    private Vector3 tempPos;
    public int numbersOfKnifes;
    private GameObject tempKnifeIcon;
    private SceneLoadMaster slm;
    LevelMaster levelNaster;

    private void DifficultyChange()
    {
        if (levelNaster.levelNumber < 3) numbersOfKnifes = 4;
        else if (levelNaster.levelNumber > 5) numbersOfKnifes = 9;
        else numbersOfKnifes = levelNaster.levelNumber * 2;
    }
    void Start()
    {
        levelNaster = FindObjectOfType<LevelMaster>();
        slm = FindObjectOfType<SceneLoadMaster>();
        DifficultyChange();
        tempPos = transform.position;
        knifeIcons = new GameObject[numbersOfKnifes];
        for (int i = 0; i < numbersOfKnifes; i++)
        {
            tempKnifeIcon = Instantiate(knifeIconPrefab, tempPos, new Quaternion(0, 0, 0, 0), transform.parent);
            tempKnifeIcon.transform.rotation *= Quaternion.Euler(0, 0, 45);
            tempKnifeIcon.transform.parent = transform;
            knifeIcons[i] = tempKnifeIcon;
            tempPos.y += yPositionMove;
        }
    }
    public void KnifeStockDecrease()
    {
        knifeIcons[numbersOfKnifes - 1].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        numbersOfKnifes--;
        if (numbersOfKnifes <= 0 && !GameOver.gameOver) slm.NextLevel();
    }
}
