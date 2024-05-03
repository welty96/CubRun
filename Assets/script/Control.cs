using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public float time;
    private float timeStart;



    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            ScoreManager.score += 0.1f;

            time = timeStart;
        }
    }
}
