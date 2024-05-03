using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text HighScoreText;
    [SerializeField] Text ScoreText;

    public static float score;
    public static int highscore;

    void Start()
    {
        score = 0;
     
     
    }


    void Update()
    {
        highscore = (int)score;
        ScoreText.text = "" + highscore.ToString();
        if (PlayerPrefs.GetInt("score") <= highscore)
        {
            PlayerPrefs.SetInt("score", highscore);
        }

        HighScoreText.text = "" + PlayerPrefs.GetInt("score").ToString();

    }


}
