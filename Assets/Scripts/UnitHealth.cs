using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public float health;

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
        healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position) + Vector3.up * 2f;
    }

    private void OnDestroy()
    {
        Destroy(healthBar);
    }
}
