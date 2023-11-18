using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTrainingScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("t")){
            SceneManager.LoadScene(1);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        //StartCoroutine(LoadSceneTime());

    }

    void OnTriggerExit(Collider other) {
        
    }

}
