using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    

    private void Awake()
    {
        
        

        GameObject[] objs = GameObject.FindGameObjectsWithTag("MenuMusic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        

        


    



    }

    

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            Destroy(this.gameObject);
        }
    }


}
