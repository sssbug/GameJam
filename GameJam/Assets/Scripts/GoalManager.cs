using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameObject hedef;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 100, Color.red);

        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            hedef.transform.position = hit.point+new Vector3(0f,2f,0f);
            if (hit.transform.CompareTag("building"))
            {
                hedef.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 0.3f);
            }
            else
            {
                hedef.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }
    }
    /*public void SpawnObject(GameObject gift)
    {
        Instantiate(gift, transform.position, Quaternion.identity);
    }*/
}
