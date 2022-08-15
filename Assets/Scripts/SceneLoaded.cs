using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoaded : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartGameMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void StartGame2()
    {
        SceneManager.LoadScene(2);
    }
    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame3()
    {
        SceneManager.LoadScene(3);
    }
}
