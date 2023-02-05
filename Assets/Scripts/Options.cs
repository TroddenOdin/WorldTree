using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer musicAudioMixer;
    public AudioMixer soundAudioMixer;

    public Slider musicSlider;
    public Slider soundSlider;

    private void Start()
    {
        //PlayerPrefs.GetFloat("Volume");
        PlayerPrefs.GetFloat("Music");
        PlayerPrefs.GetFloat("Sound");

        SetVolume();

    }



    /*public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);

        PlayerPrefs.SetFloat("Volume", volume);



    }*/

    public void setMusic(float music)
    {
        musicAudioMixer.SetFloat("Music", music);
        
        PlayerPrefs.SetFloat("Music", music);
        PlayerPrefs.Save();       


    }

    

    public void setSound(float sound)
    {
        soundAudioMixer.SetFloat("Sound", sound);
        PlayerPrefs.SetFloat("Sound", sound);
        
        

    }
    public void SetVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        
    }







}
