using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class SoundFx : MonoBehaviour
{
    public AudioSource attack;
    public AudioSource death;
    public AudioSource spawn;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayOnDeath()
    {
        

        attack.Play();
    }

    public void PlayOnSpawn()
    {
        spawn.Play();
    }

    public void PlayOnAttack()
    {
        attack.Play();
    }

}
