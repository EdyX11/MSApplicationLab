using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject[] characters;
    public int currentChar_index;
    public AudioSource crashThud;
    public GameObject mainCam;
    public GameObject levelControl;

    void Start()
    {
        currentChar_index = PlayerPrefs.GetInt("Selected Charachter", 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with " + other.gameObject.name);

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        PlayerMove.canMove = false;

        thePlayer.GetComponent<PlayerMove>().enabled = false;

        Animator charAnimator = characters[currentChar_index].GetComponent<Animator>();
        if (charAnimator != null)
        {
            charAnimator.Play("Happy Idle"); // Replace "Idle" with your character's idle or stopped animation state
        }
        else
        {
            Debug.LogError("Animator component not found on character.");
        }
        if (PlayerMove.isJumping)
        {
            StartCoroutine(StumbleAfterFall());
        }
        else
        {
            PlayStumbleAnimation();
        }
    }

    IEnumerator StumbleAfterFall()
    {
        yield return new WaitForSeconds(0.2f); // Adjust the time as needed

        PlayStumbleAnimation();
    }

    void PlayStumbleAnimation()
    {
        if (characters[currentChar_index] != null)
        {
            Animator charAnimator = characters[currentChar_index].GetComponent<Animator>();
            if (charAnimator != null)
            {
                charAnimator.Play("Stumble Backwards");
                Debug.Log("Playing Stumble Backwards animation.");
            }
            else
            {
                Debug.LogError("Animator component not found on character.");
            }
        }
        else
        {
            Debug.LogError("Character GameObject not found.");
        }

        levelControl.GetComponent<LevelDistance>().enabled = false;
        crashThud.Play();
        
        mainCam.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}
