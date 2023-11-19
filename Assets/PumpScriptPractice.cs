using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpScriptPractice : MonoBehaviour {
    public int countPump = 0;
    float time = 0;

    public int timeInSec = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            countPump++;
        }
        else if (timeInSec == 6)
        {
            time = 0;
            timeInSec = 0;
            countPump = 0;
            Debug.Log("Testing");
        }
        else if (countPump >= 1)
        {
            time += Time.deltaTime;
            timeInSec = (int)time;
            Debug.Log(timeInSec);
        }
    }
}
