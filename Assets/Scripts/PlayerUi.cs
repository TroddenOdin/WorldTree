using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public Player player;

    public Image healthFill;
    public Slider healthSlider;
    public Image manaFill;
    public Slider manaSlider;

    



    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = player.maxHealth;
        manaSlider.value = player.maxMana;
    }

    public void SetMaxHealth()
    {
        healthSlider.maxValue = player.maxHealth;
        healthSlider.value = player.currentHealth;
    }

    public void SetMaxMana()
    {
        manaSlider.maxValue = player.currentMana;
        manaSlider.value = player.currentMana;
    }

    public void SetHealth()
    {
        healthSlider.value = player.currentHealth;
    }

    public void SetMana()
    {
       
        manaSlider.value = player.currentMana;
    }

    

   
    // Update is called once per frame
    void Update()
    {
        
          
    }
}
