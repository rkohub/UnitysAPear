using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public string nextLevelName;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Man")
        {
            Debug.Log("Switching to Tutorial 2");
            SceneManager.LoadScene(nextLevelName);
        }
    }
}

