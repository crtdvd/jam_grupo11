using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BrightnessController : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBrightness;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, sliderValue);
    }

    public void changeSlider(float valueBrightness)
    {
        sliderValue = valueBrightness;
        PlayerPrefs.SetFloat("Brightness", sliderValue);
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, sliderValue);
    }
}
