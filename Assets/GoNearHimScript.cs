using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNearHimScript : MonoBehaviour {


    public GameObject Camera;
    public GameObject newTarget;
    public GameObject goThereBox;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w"))
        {
            goThereBox.SetActive(false);
            Camera.transform.localPosition = newTarget.transform.localPosition;
            Camera.transform.localRotation = newTarget.transform.localRotation;
            player.transform.localPosition = player.transform.localPosition + new Vector3(0,0.70f,0);

        }
	}
    void OnTriggerExit(Collider other)
    {
    }
}
