using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //sahne ge�i�i
    public void LoadBattleScene()
    {
        Time.timeScale = 1f; //oyunu tekrar ba�lat�r
        SceneManager.LoadScene("BattleScene");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
