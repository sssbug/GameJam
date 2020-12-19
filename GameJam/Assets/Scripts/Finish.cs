using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Finish : MonoBehaviour //düzenleme yapılacak skor
{
    List<string> allAINames;
    List<int> usedIndexs;
    string[] randomNames = new string[6];


    UIManager uIManager;
    Score score;

    WaypointProgressTracker[] bots;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
        uIManager = FindObjectOfType<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bots = FindObjectsOfType<WaypointProgressTracker>();
    }

    public void FinishGame()
    {
        foreach (var item in bots)
        {
            item.gameObject.SetActive(false);
        }
        Time.timeScale = 0;
        uIManager.scoreText.gameObject.SetActive(false);
        uIManager.timerText.gameObject.SetActive(false);
        uIManager.finishPanel.SetActive(true);

        SetRandomBotScore();

        GetRandomNames();

        WriteRandomNames();
    }

    private void SetRandomBotScore()
    {
        List<int> randomFeets = new List<int>();

        for (int i = 0; i < uIManager.feetTexts.Length; i++)
        {
            randomFeets.Add(UnityEngine.Random.Range(0, score.score));
        }

        randomFeets.Sort();
        randomFeets.Reverse();

        uIManager.feetTexts[0].text = (score.score).ToString() + " p";

        for (int i = 1; i < uIManager.feetTexts.Length; i++)
        {
            uIManager.feetTexts[i].text = randomFeets[i].ToString() + " p";
        }
    }

    private void WriteRandomNames()
    {
        uIManager.nameTexts[0].text = "You";

        for (int i = 1; i < uIManager.nameTexts.Length; i++)
        {
            uIManager.nameTexts[i].text = randomNames[i - 1];
        }
    }

    private void GetRandomNames()
    {
        allAINames = new List<string>();
        usedIndexs = new List<int>();

        foreach (var item in Enum.GetValues(typeof(AINames)))
        {
            allAINames.Add(item.ToString());
        }

        for (int i = 0; i < randomNames.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, allAINames.Count);

            if (!usedIndexs.Contains(randomIndex))
            {
                randomNames[i] = allAINames[randomIndex];
                usedIndexs.Add(randomIndex);
            }
            else
            {
                i--;
            }
        }
    }
}

