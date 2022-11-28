using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadScene(string name)
    {        
        SoundManager.SM.SfxPlay("SFXButton");
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        SoundManager.SM.SfxPlay("SFXButton");
        Application.Quit();
    }
}
