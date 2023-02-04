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

    public Button worldTreeAbility1;
    public Button worldTreeAbility2;
    public Button worldTreeAbility3;
    public Button worldTreeAbility4;
    public Button worldTreeAbility5;
    public Button worldTreeAbility6;
    public Button worldTreeAbility7;
    public Button worldTreeAbility8;

    public Button vikingAbility1;
    public Button vikingAbility2;
    public Button vikingAbility3;
    public Button vikingAbility4;
    public Button vikingAbility5;
    public Button vikingAbility6;
    public Button vikingAbility7;
    

    private int manaUsage;



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

    public void Dead()
    {
        if(currentHealth <= minHealth)
        {
            Debug.Log("YouLose!");
            currentHealth = 0;
        }
    }

    public void WorldTreeAbility1()
    {
        manaUsage = 10;

        if (currentMana >= manaUsage)
        {
            
            currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);

        
        
    }

    public void WorldTreeAbility2()
    {
        manaUsage = 15;

        if (currentMana >= manaUsage)
        {
            
            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);

    }
    public void WorldTreeAbility3()
    {
        manaUsage = 15;
        if (currentMana >= manaUsage)
        {
            
            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);

    }
    public void WorldTreeAbility4()
    {
        manaUsage = 5;
        if (currentMana >= manaUsage)
        {
            
            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);

    }
    public void WorldTreeAbility5()
    {
        manaUsage = 10;
        if (currentMana >= manaUsage)
        {
            
            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);

    }
    public void WorldTreeAbility6()
    {
        manaUsage = 15;
        if (currentMana >= manaUsage)
        {
            
            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);

    }
    public void WorldTreeAbility7()
    {
        manaUsage = 15;
        if (currentMana >= manaUsage)
        {
            
            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);

    }
    public void WorldTreeAbility8()
    {
        manaUsage = 15;
        if (currentMana >= manaUsage)
        {
            
            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);

    }

    public void VikingAbility1()
    {
        manaUsage = 5;
        if (currentMana >= manaUsage)
        {

            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);
    }
    public void VikingAbility2()
    {
        manaUsage = 15;
        if (currentMana >= manaUsage)
        {

            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);
    }
    public void VikingAbility3()
    {
        manaUsage = 15;
        if (currentMana >= manaUsage)
        {

            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);
    }
    public void VikingAbility4()
    {
        manaUsage = 10;
        if (currentMana >= manaUsage)
        {

            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);
    }
    public void VikingAbility5()
    {
        manaUsage = 15;
        if (currentMana >= manaUsage)
        {

            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);
    }
    public void VikingAbility6()
    {
        manaUsage = 10;
        if (currentMana >= manaUsage)
        {

            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);
    }
    public void VikingAbility7()
    {
        manaUsage = 15;
        if (currentMana >= manaUsage)
        {

            currentMana = currentMana -= manaUsage;
            playerUi.SetMana();
        }
        Debug.Log(currentMana);
    }
    


    public void AbilityCooldown()
    {
        
    }

    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerDamage();
            Dead();
            
        }

        

        
           

        

    }

   

}
