using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoll : MonoBehaviour
{
    private float timeStart = 0;
    private PlayerControllerBoll playerControllerBoll;
    private ManagerBoll managerBoll;

    public TextMeshProUGUI timerText;
    private void Start()
    {
        playerControllerBoll =GameObject.Find("Player").GetComponent<PlayerControllerBoll>();    
        managerBoll =GameObject.Find("Game Manager").GetComponent<ManagerBoll>();
    }
    private void Update()
    {
        Timer();
    }
    private void Timer()
    {
        if (!playerControllerBoll.gameOver)
        {
            timeStart += Time.deltaTime;
            timerText.text = timeStart.ToString("F2");
            if (PlayerPrefs.GetFloat("Score") <= timeStart)
                PlayerPrefs.SetFloat("Score", timeStart);
        }       
        managerBoll.recordText.text = "Record: " + PlayerPrefs.GetFloat("Score").ToString("F2");
    }
}
