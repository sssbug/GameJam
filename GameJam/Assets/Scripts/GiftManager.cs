using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftManager : MonoBehaviour
{
    public float timeLeft = 5.0f;
    Score score;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "building")
        {
            score.score += 10;
        }
    }
}


