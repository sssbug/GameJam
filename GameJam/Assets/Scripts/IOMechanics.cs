using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class IOMechanics : MonoBehaviour
    {
        [SerializeField] GameObject planePrefab;
        [SerializeField] GameObject waypointPrefab;

        GameObject plane;
        List<int> usedIndexs = new List<int>();

        // Start is called before the first frame update
        void Start()
        {
            CreateBot();
        }

        private void CreateBot()
        {
            for (int i = 0; i < 5; i++)
            {
                int randomIndex = Random.Range(0, waypointPrefab.transform.childCount);

                if (usedIndexs.Contains(randomIndex))
                {
                    i--;
                }
                else
                {
                    usedIndexs.Add(randomIndex);
                    plane = Instantiate(planePrefab);
                    plane.GetComponent<WaypointProgressTracker>().circuit = waypointPrefab.transform.GetChild(randomIndex).GetComponent<WaypointCircuit>();
                }
            }
        }
    }
}
