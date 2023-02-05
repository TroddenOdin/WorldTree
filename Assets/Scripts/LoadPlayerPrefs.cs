using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadPlayerPrefs : MonoBehaviour
{
    public AudioMixer musicAudioMixer;
    public AudioMixer soundAudioMixer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("Music");
        PlayerPrefs.GetFloat("Sound");

        musicAudioMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));
        soundAudioMixer.SetFloat("Sound", PlayerPrefs.GetFloat("Sound"));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
