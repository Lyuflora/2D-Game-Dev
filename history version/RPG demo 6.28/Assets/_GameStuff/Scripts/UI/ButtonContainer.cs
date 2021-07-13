using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonContainer : MonoBehaviour
{
    // Game Scenes: Start->Charactor Creator->Game

    // Press Start
    public void OnGameStart()
    {
        PlayerPrefs.SetInt("DataFromSave", 0);
        // Load >> Charactor Creator
        SceneManager.LoadScene("1_CharactorCreator");
    }

    // Press Load
    public void OnGameLoad()
    {
        PlayerPrefs.SetInt("DataFromSave", 1);
        // Load >> Game
        SceneManager.LoadScene("1_CharactorCreator");
    }
}
