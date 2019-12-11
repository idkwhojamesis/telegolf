using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    public void Load0()
    {
        SceneManager.LoadSceneAsync("Scenes/testLvl0");
    }

    public void Load1()
    {
        SceneManager.LoadSceneAsync("Scenes/testLvl1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
