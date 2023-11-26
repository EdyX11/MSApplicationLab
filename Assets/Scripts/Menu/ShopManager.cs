using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame 
    public GameObject[] charModels;
    public int currentChar_index;
    void Start()
    {

        currentChar_index=PlayerPrefs.GetInt("Selected Charachter", 0);
        foreach(GameObject character in charModels)
            character.SetActive(false);

        charModels[currentChar_index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeNext(){
        charModels[currentChar_index].SetActive(false);
        currentChar_index++;
        if(currentChar_index==charModels.Length)
             currentChar_index=0;
        charModels[currentChar_index].SetActive(true);
        PlayerPrefs.SetInt("Selected Charachter", currentChar_index);
    }

     public void ChangePrev(){
        charModels[currentChar_index].SetActive(false);
        currentChar_index--;
        if(currentChar_index==-1)
             currentChar_index=charModels.Length-1;
        charModels[currentChar_index].SetActive(true);
        PlayerPrefs.SetInt("Selected Charachter", currentChar_index);
    }
}
