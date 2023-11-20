using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingScript : MonoBehaviour {
    string message;
    public GameObject triggerBox;
    //private int countPump = 0;
    public GameObject pumpBox;
    public GameObject instructionBox;
    public GameObject cprImage;
    public GameObject handAnim;
    public GameObject compressionRateText;
    public AudioSource audioSource;
    public AudioClip source1;
    public AudioClip source2;
    public AudioClip source3;

    bool isHandAnimationShownOnce = false;
    bool audio2Played = false;

    bool audio3Played = false;

    bool audio4Played = false;

    // Use this for initialization
    void Start () {
        message = "Welcome to the CPR Training room\n" + 
        "Here you will be learning everything\n"+ 
        "there is to know about CPR\n" + 
        "Everything on what to do if someone has fainted\n" +
        "to maximize the victims chance of survival\n" +
        "<b>Press 1 to start the simulation</b>\n";
        pumpBox.SetActive(false);
        cprImage.SetActive(false);
        handAnim.SetActive(false);
        audioSource.clip = source1;
        audioSource.Play();
    }
    public int flag = 0;

    // Update is called once per frame
    void Update () {

        if(Input.GetKey("1"))
        {
            message = "Check the victim for unresponsiveness. \n"+
            "If the person is not responsive\n"+
            "and/or not breathing normally,\n" +
            "call 911 and return to the victim.\n"+
            "In most locations the emergency dispatcher can\nassist you with CPR instructions.\n" +
            "<b>Press 2 to continue</b>";
            if (!audio2Played)
            {
                audioSource.clip = source2;
                audioSource.Play();
                audio2Played = true;
            }

        } else if (Input.GetKey("2"))
        {
            cprImage.SetActive(true);
            message = "If the victim is still not breathing normally, coughing\n" +
            "or moving, begin chest compressions.\n" +
            "Push down in the center of the chest as shown\n" +
            "in the image 2-2.4 inches 30 times.\n" +
            "Pump hard and fast at the rate of\n"+
            "100-120/minute, faster than once per second.\n" + 
            "<b>Start Performing CPR </b>\n";
            flag = 1;
            pumpBox.SetActive(true);
            // if (!audio3Played)
            // {
            //     audioSource.clip = source3;
            //     audioSource.Play();
            //     audio3Played = true;
            // }
            if (!isHandAnimationShownOnce && !handAnim.activeInHierarchy)
            {
                handAnim.SetActive(true);
                StartCoroutine(PlayHandAnimation());
            }
        }
        else if (Input.GetKey("3"))
        {
            SceneManager.LoadScene(0);
        }
        if(flag == 1){
            Debug.Log("Receiving" + pumpBox.GetComponent<PumpScript>().countPump);
            compressionRateText.GetComponent<TextMesh>().text = "Your Pump Rate=" + pumpBox.GetComponent<PumpScript>().countPump * 3.0f + "/18 seconds\n" +
                    "Recommended = 30 pumps / 18 sec\n" + "Pump along with the beat of the song";
            if (pumpBox.GetComponent<PumpScript>().countPump * 3.0f >= 30)
            {
                compressionRateText.GetComponent<TextMesh>().color = Color.blue;
            }
            else if (pumpBox.GetComponent<PumpScript>().countPump == 0)
            {
                compressionRateText.GetComponent<TextMesh>().color = Color.black;
                compressionRateText.GetComponent<TextMesh>().text = "Press Y to begin";
            }
            else {
                compressionRateText.GetComponent<TextMesh>().color = Color.red;
            }
        }
        instructionBox.GetComponent<TextMesh>().text = message;
    }


    public IEnumerator PlayHandAnimation()
    {
        yield return new WaitForSeconds(10);
        handAnim.SetActive(false);
        isHandAnimationShownOnce = true;
    }
}
