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
    public AudioSource BGM;
    public GameObject buttonMoveLeft;  // Reference to ButtonMoveLeft
    public GameObject buttonMoveRight; // Reference to ButtonMoveRight
    public GameObject pauseButton;


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

        // Set the movement buttons to invisible
        buttonMoveLeft.SetActive(false);  // Hide ButtonMoveLeft
        buttonMoveRight.SetActive(false);  // Hide ButtonMoveRight
        pauseButton.SetActive(false); // Hide PauseButton
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);

        // Update the total coin count before loading the main menu scene
        UpdateTotalCoinCount();

        SceneManager.LoadScene(0); // Assuming your main menu scene is at build index 0
        BGM.Stop();
    }

    // Function to update the total coin count in PlayerPrefs
    private void UpdateTotalCoinCount()
    {
        // Get the current total coin count
        int currentTotalCoinCount = PlayerPrefs.GetInt("TotalCoinCount", 0);
        // Add the coins collected in the last run
        currentTotalCoinCount += CollectableControl.coinCount;
        // Save the updated total coin count to PlayerPrefs
        PlayerPrefs.SetInt("TotalCoinCount", currentTotalCoinCount);
    }
}
