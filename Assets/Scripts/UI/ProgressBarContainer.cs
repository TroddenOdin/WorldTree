using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarContainer : MonoBehaviour
{
    public static ProgressBarContainer progressBarContainer;

    void Awake()
    {
        progressBarContainer = this;
    }

    public GameObject CreateProgressBar(GameObject progressBar)
    {
        return GameObject.Instantiate(progressBar, transform);
    }
}
