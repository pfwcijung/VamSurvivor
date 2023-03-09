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

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
        PlayerInfo.instance.Data(0);
    }
}
