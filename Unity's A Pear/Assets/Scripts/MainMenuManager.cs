using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Loading the sample scene!");
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Debug.Log("yo i'm out, quit this mans");
        Application.Quit();
    }
}
