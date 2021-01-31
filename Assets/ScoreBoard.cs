using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int scoreValue;

    private void Awake()
    {
        //Singleton Paternon
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreValue.ToString();
    }

    //ScoreBoard Functionality

    public int GetScore()
    {
        return scoreValue;
    }

    public void AddScore(int score)
    {
        scoreValue += score;
    }
    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
