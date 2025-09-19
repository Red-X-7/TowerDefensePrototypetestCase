using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //sahne geçiþi
    public void LoadBattleScene()
    {
        Time.timeScale = 1f; //oyunu tekrar baþlatýr
        SceneManager.LoadScene("BattleScene");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
