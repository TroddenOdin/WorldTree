using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerUi playerUi;

    public int currentHealth;
    public int maxHealth = 100;
    public int minHealth = 0;
    public int playerDamage = 25;

    public int currentMana;
    public int maxMana = 100;
    public int minMana = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        playerUi.SetMaxHealth();
        playerUi.SetMaxMana();

    }
}
