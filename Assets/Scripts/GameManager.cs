using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI loseText;
    public Button restartButton;

    // Called if the player dies and freezes game while also showing the losing text and restart buttom
    public void GameOver()
    {
        Time.timeScale = 0;
        loseText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // Restarts the game if the player clicks the restart button
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
