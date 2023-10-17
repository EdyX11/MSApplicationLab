using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    //public AudioSource coinFX;
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashThud;
    public GameObject mainCam;


    void OnTriggerEnter(Collider other)
    {
        //coinFX.Play();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        crashThud.Play();
        mainCam.GetComponent<Animator>().enabled = true;
    }
}
