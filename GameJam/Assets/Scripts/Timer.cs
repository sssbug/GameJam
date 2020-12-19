using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft = 30.0f;

    bool isGameFinished;

    UIManager uiManager;
    Finish finish;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        finish = FindObjectOfType<Finish>();
    }

    void Update()
    {
        if (isGameFinished)
        {
            return;
        }

        timeLeft -= Time.deltaTime;

        uiManager.WriteTimer(timeLeft);

        if (timeLeft <= 0)
        {
            isGameFinished = true;
            finish.FinishGame();
        }
    }
}
