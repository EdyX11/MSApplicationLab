using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame 
    public GameObject[] charModels;
    public int currentChar_index;

    public PlayerBlueprint[] players;
    public Button buyButton;




    void Start()
    {
        foreach(PlayerBlueprint player in players)
        {
            if (player.price == 0)
                player.isUnlocked = true;
            else
                player.isUnlocked = PlayerPrefs.GetInt(player.name, 0) == 0 ? false : true ;
        }



        currentChar_index=PlayerPrefs.GetInt("Selected Charachter", 0);
        foreach(GameObject character in charModels)
            character.SetActive(false);

        charModels[currentChar_index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

    }


    public void ChangeNext(){
        charModels[currentChar_index].SetActive(false);
        currentChar_index++;
        if(currentChar_index==charModels.Length)
             currentChar_index=0;
        charModels[currentChar_index].SetActive(true);
        PlayerBlueprint p = players[currentChar_index];
        if (!p.isUnlocked)
            return;


        PlayerPrefs.SetInt("Selected Charachter", currentChar_index);
    }

     public void ChangePrev(){
        charModels[currentChar_index].SetActive(false);
        currentChar_index--;
        if(currentChar_index==-1)
             currentChar_index=charModels.Length-1;
        charModels[currentChar_index].SetActive(true);

        PlayerBlueprint p = players[currentChar_index];
        if (!p.isUnlocked)
            return;
        PlayerPrefs.SetInt("Selected Charachter", currentChar_index);
    }


    public void UnlockPlayer()
    {
        PlayerBlueprint p = players[currentChar_index];
        PlayerPrefs.SetInt(p.name, 1);
        PlayerPrefs.SetInt("Selected Charachter", currentChar_index);
        p.isUnlocked = true;
        PlayerPrefs.SetInt("TotalCoinCount", PlayerPrefs.GetInt("TotalCoinCount", 0) - p.price);

    }
    private  void UpdateUI()
    {

        PlayerBlueprint p = players[currentChar_index];
        if (p.isUnlocked)
        {

            buyButton.gameObject.SetActive(false);

        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY- " + p.price;

            if(p.price <= PlayerPrefs.GetInt("TotalCoinCount", 0))
            {
                buyButton.interactable = true; 
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }
}
