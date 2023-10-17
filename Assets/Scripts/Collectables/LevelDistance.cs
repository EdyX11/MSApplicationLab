using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelDistance : MonoBehaviour
{
    
    public GameObject distDisplay;
    public int distRun;
    public bool addingDist = false;
    public GameObject distEndDisplay;

    public float distDelay = 0.35f;
    
    void Update()
    {
        if(addingDist == false)
        {
            addingDist = true;
            StartCoroutine(AddingDist());
        }    
    }

    IEnumerator AddingDist()
    {
        distRun += 1;
        distDisplay.GetComponent<Text>().text = ""+distRun;
        distEndDisplay.GetComponent<Text>().text = "" + distRun;
        yield return new WaitForSeconds(distDelay);
        addingDist = false;
    }
}
