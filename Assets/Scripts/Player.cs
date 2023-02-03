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

    public float abilityCooldown;

    private int manaUsageAmount;


    public Button[] worldTreeAbilities;
    



    // Start is called before the first frame update
    void Start()
    {
        playerUi.SetMaxHealth();
        playerUi.SetMaxMana();

        
        

    }

    public void PlayerDamage()
    {
        currentHealth = currentHealth -= playerDamage;
        playerUi.SetHealth();
    }

    public void ManaUsage()
    {
        if (currentMana <= maxMana && currentMana > minMana)
        {
            if (worldTreeAbilities[0])
            {
                manaUsageAmount = 10;
                currentMana = currentMana -= manaUsageAmount;
                playerUi.SetMana();
            }
            else if(worldTreeAbilities[1])
            {
                manaUsageAmount = 2;
                currentMana = currentMana -= manaUsageAmount;
                playerUi.SetMana();
            }
            else if (worldTreeAbilities[2])
            {
                manaUsageAmount = 15;
                currentMana = currentMana -= manaUsageAmount;
                playerUi.SetMana();
            }
            else if (worldTreeAbilities[3])
            {
                manaUsageAmount = 15;
                currentMana = currentMana -= manaUsageAmount;
                playerUi.SetMana();
            }
            else if (worldTreeAbilities[4])
            {
                manaUsageAmount = 15;
                currentMana = currentMana -= manaUsageAmount;
                playerUi.SetMana();
            }
            else if (worldTreeAbilities[5])
            {
                manaUsageAmount = 15;
                currentMana = currentMana -= manaUsageAmount;
                playerUi.SetMana();
            }
            else if (worldTreeAbilities[6])
            {
                manaUsageAmount = 15;
                currentMana = currentMana -= manaUsageAmount;
                playerUi.SetMana();
            }
            else if (worldTreeAbilities[7])
            {
                manaUsageAmount = 15;
                currentMana = currentMana -= manaUsageAmount;
                playerUi.SetMana();
            }

            

        }

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerDamage();

        }

        

        
           

        

    }

   

}
