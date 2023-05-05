using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMangerScript : MonoBehaviour
{
    public AudioSource hurtSound;
    public AudioSource gameOverSound;
    public AudioSource winSound;
    public static SoundMangerScript instance;
    // Start is called before the first frame update
     void Start()
    {
        instance = this;    
    }
    public void HurtSoundStatus(bool status) {
        if (status)
            hurtSound.Play();
        else {
            hurtSound.Stop();

        }
    }
    public void PlayGameOvertSound()
    {
        gameOverSound.Play();
    }
    public void PlayWinSound()
    {
        winSound.Play();
    }
}
