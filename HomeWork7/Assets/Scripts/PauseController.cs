using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public AudioSource Sound;

    private bool paused;
    public void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            Sound.Play();
        }
        else
        {
            Time.timeScale = 0;
            Sound.Pause();
        }

        paused = !paused;
    }
}
