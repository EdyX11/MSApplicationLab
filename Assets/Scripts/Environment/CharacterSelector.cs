/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    // Start is called before the first frame 
    public GameObject[] characters;
    public int currentChar_index;
    void Start()
    {

        currentChar_index=PlayerPrefs.GetInt("Selected Charachter", 0);
        foreach(GameObject character in characters)
            character.SetActive(false);

        characters[currentChar_index].SetActive(true);
    }

   
}
*/