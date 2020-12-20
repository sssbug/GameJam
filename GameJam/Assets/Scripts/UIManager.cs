using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text[] feetTexts;
    public Text[] nameTexts;
    public GameObject finishPanel;
    public Text scoreText;
    public Text timerText;

    public void WriteTimer(float time)
    {
        timerText.text ="00: "+ time.ToString("0");
    }

    public void WriteScore(int score)
    {
        scoreText.text = "x " + score.ToString();
    }
}
