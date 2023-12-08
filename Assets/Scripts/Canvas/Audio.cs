using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Audio : MonoBehaviour
{
    public static Audio source;

    [SerializeField]
    private AudioMixer Mixer;

    [SerializeField]
    private TextMeshProUGUI ValueTextMusic;

    [SerializeField]
    private TextMeshProUGUI ValueTextSFX;

    [SerializeField]
    private Slider volumeMusicSlider;

    [SerializeField]
    private Slider volumeSFXSlider;

    private void Awake()
    {
        source = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadMusicVolume();
        }

        SetMusicVolume();

        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            LoadSFXVolume();
        }

        SetSFXVolume();
    }

    public void SetMusicVolume()
    {
        float value = volumeMusicSlider.value;
        ValueTextMusic.SetText($"{value.ToString("N1")}");
        Mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSFXVolume()
    {
        float value = volumeSFXSlider.value;
        ValueTextSFX.SetText($"{value.ToString("N1")}");
        Mixer.SetFloat("SfxVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SfxVolume", value);
    }

    public void LoadMusicVolume()
    {
        volumeMusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        SetMusicVolume();
    }

    public void LoadSFXVolume()
    {
        volumeSFXSlider.value = PlayerPrefs.GetFloat("SfxVolume");

        SetMusicVolume();
    }

}
