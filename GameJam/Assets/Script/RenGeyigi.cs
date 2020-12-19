using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenGeyigi : MonoBehaviour
{
    Animator anime;
    
    void Update()
    {
        anime.SetBool("Reindeer", true);
    }
}
