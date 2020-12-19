using UnityEngine;

public class IO : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 2;
    private Quaternion rotationY;
    protected Touch touch;
    [SerializeField] public float rotatespeed = 5f;
    // Rigidbody rigidbody;

    // Update is called once per frame
    private void FixedUpdate()
    {
        //rigidbody.velocity = transform.forward * speed;
        if (Input.touchCount > 0)
        {
            DirectUpdate();
        }
        transform.position += -transform.up * m_moveSpeed * Time.deltaTime;
    }
    private void DirectUpdate()
    {
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotatespeed * Time.deltaTime, 0f);

            transform.rotation = rotationY * transform.rotation;
        }

    }

}
