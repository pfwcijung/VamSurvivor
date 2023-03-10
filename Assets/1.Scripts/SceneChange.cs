using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GoToMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoToChooseScene()
    {
        SceneManager.LoadScene("Choose");
    }

    public void GoToGameScene_Player0()
    {
        SceneManager.LoadScene("Game");
        PlayerInfo.instance.Data(0);
    }
    public void GoToGameScene_Player1()
    {
        SceneManager.LoadScene("Game");
        PlayerInfo.instance.Data(1);
    }
    public void GoToGameScene_Player2()
    {
        SceneManager.LoadScene("Game");
        PlayerInfo.instance.Data(2);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
