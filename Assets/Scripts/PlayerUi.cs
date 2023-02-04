using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public Player player;

    public Image worldTreeHealthFill;
    public Slider worldTreeHealthSlider;
    public Image worldTreeManaFill;
    public Slider worldTreeManaSlider;

    public Image vikingHealthFill;
    public Slider vikingHealthSlider;
    public Image vikingManaFill;
    public Slider vikingManaSlider;

    public GameObject worldTreeCanvas;
    public GameObject vikingCanvas;
    public GameObject factionPickingCanvas;

    public GameObject game;



    // Start is called before the first frame update
    void Start()
    {
        worldTreeCanvas.SetActive(false);
        vikingCanvas.SetActive(false);
        factionPickingCanvas.SetActive(true);
        game.SetActive(false);
    }

    public void SetMaxHealth()
    {
        worldTreeHealthSlider.maxValue = player.maxHealth;
        worldTreeHealthSlider.value = player.currentHealth;

        vikingHealthSlider.maxValue = player.maxHealth;
        vikingHealthSlider.value = player.currentHealth;
    }

    public void SetMaxMana()
    {
        worldTreeManaSlider.maxValue = player.maxMana;
        worldTreeManaSlider.value = player.currentMana;

        vikingManaSlider.maxValue = player.maxMana;
        vikingManaSlider.value = player.currentMana;
    }

    public void SetHealth()
    {
        worldTreeHealthSlider.value = player.currentHealth;

        vikingHealthSlider.value = player.currentHealth;
    }

    public void SetMana()
    {
       
        worldTreeManaSlider.value = player.currentMana;

        vikingManaSlider.value = player.currentMana;
    }

    public void ChooseWorldTree()
    {
        worldTreeCanvas.SetActive(true);
        vikingCanvas.SetActive(false);
        factionPickingCanvas.SetActive(false);
        game.SetActive(true);
    }
    public void ChooseVikings()
    {
        worldTreeCanvas.SetActive(false);
        vikingCanvas.SetActive(true);
        factionPickingCanvas.SetActive(false);
        game.SetActive(true);
    }






    // Update is called once per frame
    void Update()
    {
        
          
    }
}
