using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Audio : MonoBehaviour
{
    public static Audio source;

    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private TextMeshProUGUI ValueTextMusic;
    /*
    [SerializeField]
    private TextMeshProUGUI ValueTextSFX;
    [SerializeField]
    private AudioMixMode MixMode;
    [SerializeField]
    public AudioMixerGroup musicMixerGroup;
    [SerializeField]
    public AudioMixerGroup sfxMixerGroup;
    */

    private void Awake()
    {
        source = this;
    }

    public void onChangeSliderMusic(float value)
    {
        ValueTextMusic.SetText($"{value.ToString("N1")}");
        PlayerPrefs.SetFloat("MusicVolume", value);
        Mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);

        /*
        switch (MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = value;
                break;
            case AudioMixMode.LinearMixerVolume:
                Mixer.SetFloat("MusicVolume", (-80 + value * 100));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
            Mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
                break;
        }
        */
    }

    /*
    public void onChangeSliderSFX(float value)
    {
        ValueTextSFX.SetText($"{value.ToString("N1")}");
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
    */

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }

    // Start is called before the first frame update
    void Start()
    {
        //Mixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 1) * 20));
        //Mixer.SetFloat("SFXVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume", 1) * 20));

    }

    public void Save()
    {
        PlayerPrefs.Save();
    }
}
