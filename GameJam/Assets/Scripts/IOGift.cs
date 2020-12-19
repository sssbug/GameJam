using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOGift : MonoBehaviour
{
    [SerializeField] private GameObject gift;
    float time = 0f;
    float timeDelay = 1f;
    bool delay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (delay == true)
        {
            time = time + 1f * Time.deltaTime;
            if (time >= timeDelay)
            {
                time = 0f;
                delay = false;
            }
        }
        if (delay == false)
        {
            Instantiate(gift, transform.position, Quaternion.identity);
            delay = true;
        }
    }
}
