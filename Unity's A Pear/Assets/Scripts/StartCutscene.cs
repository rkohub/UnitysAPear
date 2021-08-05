using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public Animator cameraAnimation;
    public Animator duck;
    public BasketDie kill;
    public LevelLoader next;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Man" || collision.tag == "Player")
        {
            cameraAnimation.SetBool("cutscene1", true);
            duck.SetTrigger("DuckRun");
            duck.SetTrigger("DuckSteal");
            Invoke(nameof(StopCutscene), 7.5f);
        }
    }

    void StopCutscene()
    {
        cameraAnimation.SetBool("cutscene1", false);
        Destroy(gameObject);
        next.Switch();
    }
}
