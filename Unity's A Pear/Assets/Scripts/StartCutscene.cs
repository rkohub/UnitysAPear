using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public Animator cameraAnimation;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Man" || collision.tag == "Player")
        {
            cameraAnimation.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 2f);
        }
    }

    void StopCutscene()
    {
        cameraAnimation.SetBool("cutscene1", false);
        Destroy(gameObject);
    }
}
