using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 2;
    private Quaternion rotationY;
    protected Touch touch;
    [SerializeField] public float rotatespeed = 5f;
    [SerializeField] private GameObject gift;
    //[SerializeField] private GameObject geyik;
    //[SerializeField] private GameObject geyik1;
    GoalManager gifts;
    float time = 0f;
    float timeDelay = 0.5f;
    bool delay = false;

    Finish finish;

    // Rigidbody rigidbody;
    void Start()
    {
        finish = FindObjectOfType<Finish>();
        // rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //rigidbody.velocity = transform.forward * speed;
        if (Input.touchCount > 0)
        {
            DirectUpdate();
        }
        transform.position += -transform.up * m_moveSpeed * Time.deltaTime;
        if (delay == true)
        {
            time = time + 1f * Time.deltaTime;
            if (time >= timeDelay)
            {
                time = 0f;
                delay = false;
            }
        }
    }

    private void DirectUpdate()
    {
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            rotationY = Quaternion.Euler(0f, touch.deltaPosition.x * rotatespeed * Time.deltaTime, 0f);

            transform.rotation = rotationY * transform.rotation;
            /*if (geyik.transform.rotation.x < 103 || geyik.transform.rotation.x > 77)
            {
                geyik.transform.rotation = rotationY * geyik.transform.rotation;
                geyik1.transform.rotation = rotationY * geyik1.transform.rotation;
            }*/
        }
        if (touch.phase == TouchPhase.Ended)
        {
            if (delay == false)
            {
                Instantiate(gift, transform.position, Quaternion.identity);
                delay = true;
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("gameArea"))
        {
            finish.FinishGame();
        }
    }
}
