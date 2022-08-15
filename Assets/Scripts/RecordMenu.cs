using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecordMenu : MonoBehaviour
{     
    public TextMeshProUGUI recordGame1;
    public TextMeshProUGUI recordGame2;
    public TextMeshProUGUI recordGame3;
    private void Start()
    {
        float record = PlayerPrefs.GetFloat("score");
        recordGame1.text= "Walk: " + record.ToString();
        int record2 = PlayerPrefs.GetInt("Rscore");
        recordGame2.text= "Food: " + record2.ToString();
        float record3 = PlayerPrefs.GetFloat("Score");
        recordGame3.text = "Ball: " + record3.ToString();
    }   
    }
