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

    [SerializeField]
    private AnimationCurve fillTweeningCurve;

    public GameObject worldTreeCanvas;
    public GameObject vikingCanvas;
    public GameObject factionPickingCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject optionsMenuCanvas;

    public UnityEvent<Faction> OnFactionSelect;

    


    // Start is called before the first frame update
    private void Start()
    {
        worldTreeCanvas.SetActive(false);
        vikingCanvas.SetActive(false);
        factionPickingCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(false);
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
        worldTreeHealthSlider.value = fillTweeningCurve.Evaluate((player.currentHealth - player.minHealth) / (player.maxHealth - player.minHealth)) * player.maxHealth;

        vikingHealthSlider.value = fillTweeningCurve.Evaluate((player.currentHealth - player.minHealth) / (player.maxHealth - player.minHealth)) * player.maxHealth;
    }

    public void SetMana()
    {
       
        worldTreeManaSlider.value = fillTweeningCurve.Evaluate((player.currentMana - player.minMana) / (player.maxMana - player.minMana)) * player.maxMana;

        vikingManaSlider.value = fillTweeningCurve.Evaluate((player.currentMana - player.minMana) / (player.maxMana - player.minMana)) * player.maxMana;
    }

    public void ChooseWorldTree(bool worldTreeSelected = true)
    {
        factionPickingCanvas.SetActive(false);
        Faction faction;

        if (GameState.instance.selectedFaction == Faction.Nature)
        {
            faction = Faction.Civilization;
        }    
        else if (GameState.instance.selectedFaction == Faction.Civilization)
        {
            faction = Faction.Nature;
        }
        else
            faction = worldTreeSelected ? Faction.Nature : Faction.Civilization;


        worldTreeCanvas.SetActive(faction == Faction.Nature);
        vikingCanvas.SetActive(faction != Faction.Nature);

        OnFactionSelect.Invoke(faction);
    }

    public void ShowFactionDialog()
    {
        factionPickingCanvas.SetActive(true);
        // Supposed to hide buttons, but doesn't work
        //Debug.Log(GameState.instance.selectedFaction);
        //if (GameState.instance.selectedFaction != Faction.Neutral)
        //    factionPickingCanvas.transform.GetChild(0).GetChild(GameState.instance.selectedFaction == Faction.Nature ? 1 : 2).gameObject.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        pauseMenuCanvas.SetActive(!pauseMenuCanvas.activeSelf);
    }

    public void ResumeButton()
    {
        pauseMenuCanvas.SetActive(false);
    }

    public void OptionsButton()
    {
        optionsMenuCanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }    

    public void Forfeit()
    {

    }

    public void BackButton()
    {
        optionsMenuCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPauseMenu();
        }
        SetHealth();
        SetMana();
    }   
    
    
}
