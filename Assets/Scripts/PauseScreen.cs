using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public void DoForfeit()
    {
        SceneManager.LoadScene(0);
    }

    public void DoLeave()
    {
        SceneManager.LoadScene(0);
    }
}
