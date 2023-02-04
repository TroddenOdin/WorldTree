using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WorldTree;

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

    public UnityEvent<Faction> OnFactionSelect;


    // Start is called before the first frame update
    void Start()
    {
        worldTreeCanvas.SetActive(false);
        vikingCanvas.SetActive(false);
        factionPickingCanvas.SetActive(false);
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

    public void ChooseWorldTree(bool worldTree = true)
    {
        worldTreeCanvas.SetActive(worldTree);
        vikingCanvas.SetActive(!worldTree);
        factionPickingCanvas.SetActive(false);

        OnFactionSelect.Invoke(worldTree ? Faction.Nature : Faction.Civilization);
    }

    public void ShowFactionDialog()
    {
        factionPickingCanvas.SetActive(true);
    }
}
