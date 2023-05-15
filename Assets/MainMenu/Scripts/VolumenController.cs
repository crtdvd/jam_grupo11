using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenController : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imageMute;
    public Image imageSound;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f); //Cambiar aqui en donde iniciara el sonido(modificar el 0.5)
        AudioListener.volume = slider.value;
        ifMute();
    }

    public void changeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        ifMute();
    }
    public void ifMute()
    {
        if(sliderValue == 0)
        {
            imageMute.enabled = true;
            imageSound.enabled = false;
        }
        else
        {
            imageMute.enabled = false;
            imageSound.enabled = true;
        }
    }
}
