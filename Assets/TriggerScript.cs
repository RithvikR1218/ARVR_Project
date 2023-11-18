using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    public int step = 0;
    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

    }


    void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "palm" && !audioSource.isPlaying)
        {
            step = step + 1;
        }

    }
    void Update()
    {
    }

}
