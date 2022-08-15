using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerGameTo : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public Button exitButton;
    public TextMeshProUGUI recordText;

    private float spawnRate = 1.0f;
    private int score = 0;  
    private void Start()
    {
        isGameActive = true;        
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {          
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);           
        }
    }
    public void UpdateScore(int scoreToAdd)
    {             
            score += scoreToAdd;
            scoreText.text = "Score" + score.ToString();
            if (PlayerPrefs.GetInt("Rscore") <= score)
                PlayerPrefs.SetInt("Rscore", score);        
        recordText.text = "Record: " + PlayerPrefs.GetInt("Rscore");
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
        SceneManager.LoadScene(2);
    } 
}
