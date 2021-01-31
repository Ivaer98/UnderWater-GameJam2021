using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] bool resetHighScore = false;
    // This Script is called only the first time that runing
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        if (resetHighScore)
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    /* Update is called once per frame
    void Update()
    {

    }*/
    public void LoadMainMenu()
    {
        FindObjectOfType<ScoreBoard>().ResetScore();
        SceneManager.LoadScene(1);

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Atlantis");
        FindObjectOfType<ScoreBoard>().ResetScore();
    }
    public IEnumerator LoadGameOverAftherSeconds()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("GameOver");

    }
    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverAftherSeconds());

    }
    public void QuitGame()
    {
        Application.Quit();
    }



}
