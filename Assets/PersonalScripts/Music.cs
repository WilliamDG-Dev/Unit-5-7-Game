using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    public static Music instance;
    public AudioSource[] audioSources;
    public AudioClip[] audioclips;
    public AudioMixer audioMixer;
    const string mixerMaster = "MasterVol";
    const string mixerMusic = "MusicVol";
    const string mixerSFX = "SFXVol";
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSources[1].clip = audioclips[2];
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "FrontEnd")
        {
            audioSources[0].clip = audioclips[0];
        }
        else if (SceneManager.GetActiveScene().name == "Game" && LevelManager.instance.NameEntered() == true)
        {
            audioSources[0].clip = audioclips[1];
        }
        else
        {
            audioSources[0].clip = null;
        }
        if(Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Game")
        {
            audioSources[0].Play();
        }
    }
    public void PlaySFX()
    {
        audioSources[0].Play();
    }
    public void PlayBGMusic()
    {
        audioSources[1].Play();
    }
    public void StopBGMusic()
    {
        audioSources[1].Stop();
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(mixerMaster, Mathf.Log10(volume)* 20);
    }
    public void SetBGMusicVolume(float volume)
    {
        audioMixer.SetFloat(mixerMusic, Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(mixerSFX, Mathf.Log10(volume) * 20);
    }
}
