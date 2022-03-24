using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadMaster : MonoBehaviour
{
    private SaveLoad saveLoad;
    LevelMaster levelNaster;

    private void Start()
    {
        levelNaster = FindObjectOfType<LevelMaster>();
        saveLoad = FindObjectOfType<SaveLoad>();
    }
    public void NextLevel()
    {
        var beamBoom = FindObjectOfType<BeamBoom>();
        beamBoom.Boom();
        StartCoroutine(NextLevelCoroutine());
    }
    private IEnumerator NextLevelCoroutine()
    {
        yield return new WaitForSeconds(1.4f);
        ToGame();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    private void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ToGame()
    {
        saveLoad.SaveGameResults();
        levelNaster.levelNumber ++;
        SceneManager.LoadScene("Game");
        BeamBoom.beamBoom = false;
    }
    public void ToMainMenu()
    {
        var transit = FindObjectOfType<LevelMaster>();
        Destroy(transit);
        levelNaster.levelNumber = 0;
        SceneManager.LoadScene("StartScreen");
    }
    public void ToResult()
    {
        saveLoad.SaveGameResults();
        SceneManager.LoadScene("Result");
    }
}
