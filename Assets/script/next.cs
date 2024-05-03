using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next : MonoBehaviour
{
    public GameObject panel;

    public void nextgame()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
    }
}
