using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpScript : MonoBehaviour {
    public int countPump = 0;
    public GameObject handAnim;
    float time = 0;

    public int timeInSec = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (countPump >= 1)
        {
            time += Time.deltaTime;
            timeInSec=(int)time;
            Debug.Log(timeInSec);
        }
        if (timeInSec == 6)
        {
            time = 0;
            countPump = 0;
        }
        Debug.Log("Hi:"+countPump);
        if (Input.GetKeyDown("y"))
        {
            countPump++;
            Debug.Log("PumpCount:"+countPump);
        }
    }
}
