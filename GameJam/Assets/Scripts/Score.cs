using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;

    UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        uiManager.WriteScore(score);
    }
}
