using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip soundButton;

    public void soundBtn()
    {
        sound.PlayOneShot(soundButton);
    }
}

