using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;
    // when build + play coins stack up 
    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollectableControl.coinCount +=  1;
        this.gameObject.SetActive(false);

    }
}
