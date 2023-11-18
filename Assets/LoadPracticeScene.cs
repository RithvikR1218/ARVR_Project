using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPracticeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("p")){
            SceneManager.LoadScene(2);
        }
	}

    void OnTriggerExit(Collider other) {
    }
}
