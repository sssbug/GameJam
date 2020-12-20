using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOGiftTimer : MonoBehaviour
{
    public float timeLeft = 5.0f;
     
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
