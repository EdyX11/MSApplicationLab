using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{

    public GameObject liveCoins;
    public GameObject liveDist;
    public GameObject endScreen;
    public GameObject fadeOut;
    public  AudioSource BGM;
    void Start()

    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {

        yield return new WaitForSeconds(3);
        liveCoins.SetActive(false);
        liveDist.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
        BGM.Stop();

    }
}
