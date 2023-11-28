using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectableControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;

    void Start()
    {
        // Reset the coin count at the beginning of each run
        ResetCoinCount();
    }

    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
        coinEndDisplay.GetComponent<Text>().text = "" + coinCount;
    }

    // Function to reset the coin count
    public static void ResetCoinCount()
    {
        coinCount = 0;
    }
}
