using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion
    #region Variables
    private GameObject scoreText;
    private int score;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {

            score = value;
            if (ScoreText != null)
                ScoreText.GetComponent<Text>().text = Score.ToString();
        }
    }
    public GameObject ScoreText
    {
        get
        {
            if (scoreText == null)
            {
                scoreText = GameObject.FindGameObjectWithTag("Score");
            }

            return scoreText;
        }
    }
    #endregion
    #region MonoBehaviour
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        score = 0;
    }
    #endregion
}
