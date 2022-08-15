using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{      
    public GameObject gameOverText;
    public bool isGameActive;
    public Button restartButton;    
    public Button exitButton;
    public TextMeshProUGUI recordText;

    private PlayerController playerController;
    private Score score;
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        score = GetComponent<Score>();
    }
    public void GameOver()
    {
        recordText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true); 
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        isGameActive = true;                    
    }
   
}
