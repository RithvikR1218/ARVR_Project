using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectScript : MonoBehaviour {
    public GameObject player;
    private Animator thisAnimator;
    public GameObject phone;
    public bool is911Called = false;
    public bool didHeGoThere = false;
    public GameObject instructionBox;
    public GameObject instructionBackground;
    public GameObject pumpBox;
    private string message = "";
    private bool screamAudioPlayed = false;
    private AudioSource thisAudioSource;
    public GameObject goThereBox;
    public GameObject compressionRateText;
    public GameObject cprImage;
    public GameObject background1;
    public GameObject continueButton;
    public GameObject MobileText;
    public AudioSource playerAudio;
    public AudioClip stayingAlive;
    public AudioSource cprBoard;

    public bool mobileMsgShown=false;
    public AudioClip source1;

	// Use this for initialization
	void Start () {

        message = "Today you will be practicing performing CPR in real life scenarios. " + 
        "Look around and see if somebody needs your help.";
        playerAudio.clip = source1;
        playerAudio.Play();
        thisAnimator = this.gameObject.GetComponent<Animator>();
        phone.SetActive(false);
        instructionBox.transform.parent.gameObject.SetActive(false);
        thisAudioSource = this.gameObject.GetComponent<AudioSource>();
        goThereBox.SetActive(false);
        cprImage.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        {
            if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) > 5.0f && !(thisAnimator.GetCurrentAnimatorStateInfo(0).IsName("fall") || thisAnimator.GetCurrentAnimatorStateInfo(0).IsName("laying")))
            {
                this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
            }
            else
            {
                thisAnimator.SetFloat("walkdone", 1.0f);
            }
            if (thisAnimator.GetCurrentAnimatorStateInfo(0).IsName("fall") && !screamAudioPlayed)
            {
                thisAudioSource.time = 2.0f;
                thisAudioSource.Play();
                screamAudioPlayed = true;
            }
            if (thisAnimator.GetCurrentAnimatorStateInfo(0).IsName("laying") && !didHeGoThere)
            {
                goThereBox.SetActive(true);
                didHeGoThere = true;
            }
            if (thisAnimator.GetCurrentAnimatorStateInfo(0).IsName("laying") && !is911Called && didHeGoThere)
            {
                Debug.Log("Logged " + phone.GetComponent<PhoneTriggerScript>().isPhonePicked);
                phone.SetActive(true);
                is911Called = phone.GetComponent<PhoneTriggerScript>().isPhonePicked;
            }
            else if (didHeGoThere && !phone.activeInHierarchy && !mobileMsgShown)
            {
                mobileMsgShown = true;
                StartCoroutine(ShowMessageGood());
            }
            else
            {
                phone.SetActive(false);
                instructionBox.transform.parent.gameObject.SetActive(false);
            }
            if (!is911Called && pumpBox.GetComponent<PumpScriptPractice>().countPump > 0 && !mobileMsgShown)
            {
                mobileMsgShown = true;
                StartCoroutine(ShowMessageBad());
            }
            else if (is911Called && pumpBox.GetComponent<PumpScriptPractice>().countPump == 0)
            {
                cprBoard.clip = stayingAlive;
                cprBoard.Play();
                cprImage.SetActive(true);
                continueButton.SetActive(true);
                compressionRateText.SetActive(true);
                background1.GetComponent<TextMesh>().color = Color.black;
                compressionRateText.GetComponent<TextMesh>().text = "Press Space to Begin";
            }
            else if (is911Called && pumpBox.GetComponent<PumpScriptPractice>().countPump > 0)
            {
                compressionRateText.GetComponent<TextMesh>().text = "Your Pump Rate=" + pumpBox.GetComponent<PumpScriptPractice>().countPump * 3.0f + "/18 seconds\n" +
                        "Recommended = 30 pumps / 18 sec\n" + "Pump along with the beat of the song";
                if (pumpBox.GetComponent<PumpScriptPractice>().countPump * 3.0f >= 30)
                    background1.GetComponent<TextMesh>().color = Color.green;
                else
                    background1.GetComponent<TextMesh>().color = Color.red;
            }
        }
	}

    IEnumerator ShowMessageGood()
    {
        MobileText.SetActive(true);
        MobileText.GetComponentInChildren<TextMesh>().color = Color.green;
        MobileText.GetComponentInChildren<TextMesh>().text = "Good, you called 911";
        yield return new WaitForSeconds(2);
        MobileText.SetActive(false);

    }
    IEnumerator ShowMessageBad()
    {
        MobileText.SetActive(true);
        MobileText.GetComponentInChildren<TextMesh>().color = Color.red;
        MobileText.GetComponentInChildren<TextMesh>().text = "You forgot to call 911!";
        yield return new WaitForSeconds(2);
        MobileText.SetActive(false);

    }
}
