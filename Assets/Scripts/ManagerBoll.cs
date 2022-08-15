using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerBoll : MonoBehaviour
{
    public Button restartButton;
    public Button exitButton;
    public GameObject gameOverText;
    public TextMeshProUGUI recordText;
    public bool isGameActive;

    public void GameOver()
    {
        recordText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;      
    }   
}
