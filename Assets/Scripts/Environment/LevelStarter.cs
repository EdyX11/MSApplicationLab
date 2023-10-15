using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject CountDownGO;
    public GameObject FadeIn;
    public AudioSource readyFX;
    public AudioSource goFX;


    void Start()
    {
        StartCoroutine(CountDownSequence());
    }

    IEnumerator CountDownSequence () 
    {
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        CountDownGO.SetActive(true);
        goFX.Play();
        PlayerMove.canMove =true;
    }
}
