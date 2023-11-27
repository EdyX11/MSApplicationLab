using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    //public AudioSource coinFX;
    public GameObject thePlayer;
    //public GameObject charModel;
    public GameObject[] characters;
    public int currentChar_index;
    public AudioSource crashThud;
    public GameObject mainCam;
    public GameObject levelControl;

    void Start()
    {

        currentChar_index=PlayerPrefs.GetInt("Selected Charachter", 0);

    }

    void OnTriggerEnter(Collider other)
    {
        //coinFX.Play();
        Debug.Log("charname: " + characters[currentChar_index]); 
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        characters[currentChar_index].GetComponent<Animator>().Play("Stumble Backwards");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        crashThud.Play();
        mainCam.GetComponent<Animator>().enabled = true;
       levelControl.GetComponent<EndRunSequence>().enabled = true;
       
    }
}
