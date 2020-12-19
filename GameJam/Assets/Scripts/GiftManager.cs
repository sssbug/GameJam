using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftManager : MonoBehaviour
{

    Score score;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "building")
        {
            score.score += 10;
        }
    }
}


