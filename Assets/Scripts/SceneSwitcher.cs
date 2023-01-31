using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LobbyScene()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
