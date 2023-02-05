using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBarContainer : MonoBehaviour
{
    public static HealthBarContainer container;

    void Awake()
    {
        container = this;
    }

    public GameObject CreateHealthBar(GameObject healthBar)
    {
        return GameObject.Instantiate(healthBar, transform);
    }
}
