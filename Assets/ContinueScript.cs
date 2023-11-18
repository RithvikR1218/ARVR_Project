using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("c")){
			SceneManager.LoadScene(0);
		}
	}

    void OnTriggerEnter(Collider other)
    {
        
    }
}
