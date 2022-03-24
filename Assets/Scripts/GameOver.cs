using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private SceneLoadMaster slm;
    private float pause = 0.4f;
    [SerializeField] private GameObject LosePanel;
    public static bool gameOver = false;

    public void Lose()
    {
        gameOver = true;
        StartCoroutine(GameLoseCoroutine());
    }
    private IEnumerator GameLoseCoroutine()
    {
        slm = FindObjectOfType<SceneLoadMaster>();
        yield return new WaitForSeconds(pause);
        LosePanel.SetActive(true);
        yield return new WaitForSeconds(pause * 1.5f);
        gameOver = false;
        Vibration.Cancel();
        slm.ToResult();
    }
}
