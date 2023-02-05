using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;
    private GameObject healthBar = null;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = HealthBarContainer.container.CreateHealthBar(healthBarPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            healthBar.SetActive(true);
            healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position) + Vector3.up * 25f;
        }
        else
        {
            healthBar.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Destroy(healthBar);
    }
}
