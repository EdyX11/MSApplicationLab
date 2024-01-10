using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text totalCoinCountText;

    void Start()
    {
        // Load the total coin count from PlayerPrefs
        int totalCoinCount = PlayerPrefs.GetInt("TotalCoinCount", 0);
        // Display the total coin count on the main menu
        totalCoinCountText.text = "" + totalCoinCount;
    }

    // Call this method when the player finishes a run to update the total coin count
    public void UpdateTotalCoinCount()
    {
        // Get the current total coin count
        int currentTotalCoinCount = PlayerPrefs.GetInt("TotalCoinCount", 0);
        // Add the coins collected in the last run
        currentTotalCoinCount += CollectableControl.coinCount;
        // Save the updated total coin count to PlayerPrefs
        PlayerPrefs.SetInt("TotalCoinCount", currentTotalCoinCount);
        // Display the updated total coin count on the main menu
        totalCoinCountText.text = "" + currentTotalCoinCount;
        // Reset the coin count for the next run
        CollectableControl.ResetCoinCount();
    }
}