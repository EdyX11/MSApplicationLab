using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctionality : MonoBehaviour
{
    // This method is called when the "Play" button is clicked in the main menu
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

}
