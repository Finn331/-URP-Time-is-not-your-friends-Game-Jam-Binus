using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private int firstPlayInt;
    public Slider musikSlider, soundEffectSlider;
    private float musikFloat, soundEffectFloat;
    public AudioSource mainMusicAudio;
    public AudioSource[] SoundEffectAudio;


    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            musikFloat = .125f;
            musikSlider.value = musikFloat;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(MusicPref, musikFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musikFloat = PlayerPrefs.GetFloat(MusicPref);
            musikSlider.value = musikFloat;
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectSlider.value = soundEffectFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicPref, musikSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        mainMusicAudio.volume = musikSlider.value;

        for (int i = 0; i < SoundEffectAudio.Length; i++)
        {
            SoundEffectAudio[i].volume = soundEffectSlider.value;
        }
    }
}
