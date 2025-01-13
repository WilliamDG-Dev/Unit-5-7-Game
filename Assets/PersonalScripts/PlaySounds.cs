using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlaySounds : MonoBehaviour
{
    public Slider[] sliders;

    void Start()
    {
        GetPrefs();
        Music.instance.SetMasterVolume(sliders[0].value);
        Music.instance.SetBGMusicVolume(sliders[1].value);
        Music.instance.SetSFXVolume(sliders[2].value);
        Music.instance.PlayBGMusic();
    }
    private void GetPrefs()
    {
        if (PlayerPrefs.HasKey("Master") == true)
        {
            sliders[0].value = PlayerPrefs.GetFloat("Master");
        }
        if (PlayerPrefs.HasKey("Music") == true)
        {
            sliders[1].value = PlayerPrefs.GetFloat("Music");
        }
        if (PlayerPrefs.HasKey("SFX") == true)
        {
            sliders[2].value = PlayerPrefs.GetFloat("SFX");
        }
    }
    public void PlaySFX()
    {
        Music.instance.PlaySFX();
    }
    public void StopMusic()
    {
        Music.instance.StopBGMusic();
    }
    public void changeMasterVol()
    {
        Music.instance.SetMasterVolume(sliders[0].value);
    }
    public void changeMusicVol()
    {
        Music.instance.SetBGMusicVolume(sliders[1].value);
    }
    public void changeSFXVol()
    {
        Music.instance.SetSFXVolume(sliders[2].value);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("Master", sliders[0].value);
        PlayerPrefs.SetFloat("Music", sliders[1].value);
        PlayerPrefs.SetFloat("SFX", sliders[2].value);
    }
}
