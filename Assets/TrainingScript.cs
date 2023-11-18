using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingScript : MonoBehaviour {


    string message = "Hello, we will be learning how to perform CPR today.\nPlease touch button below to continue.";
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
    public AudioClip source4;
    


    bool isHandAnimationShownOnce = false;
    bool audio2Played = false;

    bool audio3Played = false;

    bool audio4Played = false;

    // Use this for initialization
    void Start () {
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
            message = "Check the victim for unresponsiveness. \nIf the person is not responsive and \nnot breathing or not breathing normally.\n" +
                "Call 911 and return to the victim.\n If possible bring the phone next to the person\nand place on speaker mode.\n " +
                "In most locations the emergency dispatcher can\nassist you with CPR instructions.\n";
            if (!audio2Played)
            {
                audioSource.clip = source2;
                audioSource.Play();
                audio2Played = true;
            }

        } else if (Input.GetKey("2"))
        {
            cprImage.SetActive(true);
            flag = 1;
            message = "If the victim is still not breathing normally, coughing\n or moving, begin chest compressions.\n" +
                "Push down in the center of the chest as shown\n in the image 2-2.4 inches 30 times.\n" +
                "Pump hard and fast at the rate of\n 100-120/minute, faster than once per second.";
            pumpBox.SetActive(true);
            if (!audio3Played)
            {
                audioSource.clip = source3;
                audioSource.Play();
                audio3Played = true;
            }
            if (!isHandAnimationShownOnce && !handAnim.activeInHierarchy)
            {
                handAnim.SetActive(true);
                StartCoroutine(PlayHandAnimation());
            }
            // Debug.Log("Receiving" + pumpBox.GetComponent<PumpScript>().countPump);
            // compressionRateText.GetComponent<TextMesh>().text = "Your Pump Rate=" + pumpBox.GetComponent<PumpScript>().countPump * 3.0f + "/18 seconds\n" +
            //         "Recommended = 30 pumps / 18 sec";

            // message = "Start Performing CPR \n\n"+"Press continue when done.";
            if (!audio4Played)
            {
                audioSource.clip = source4;
                audioSource.Play();
                audio4Played = true;
            }
        }
        else if (Input.GetKey("3"))
        {
            SceneManager.LoadScene(0);
        }
        if(flag == 1){
            Debug.Log("Receiving" + pumpBox.GetComponent<PumpScript>().countPump);
            compressionRateText.GetComponent<TextMesh>().text = "Your Pump Rate=" + pumpBox.GetComponent<PumpScript>().countPump * 3.0f + "/18 seconds\n" +
                    "Recommended = 30 pumps / 18 sec";

            message = "Start Performing CPR \n\n"+"Press continue when done.";
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
