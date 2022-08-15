using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{ 
    private float timeStart = 0;
    private PlayerController playerController;
    private GameManager gameManager;

    public TextMeshProUGUI timerText;    
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        Timer();
    }
    private void Timer()
    {
        if (!playerController.gameOver)
        {
            timeStart += Time.deltaTime;
            timerText.text = timeStart.ToString("F2");
            if (PlayerPrefs.GetFloat("score") <= timeStart)
                PlayerPrefs.SetFloat("score", timeStart);
        }
        gameManager.recordText.text ="Record:"+ PlayerPrefs.GetFloat("score").ToString("F2");      
    }
}
