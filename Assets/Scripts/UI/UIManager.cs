using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject healthBarChar = null;
    [SerializeField] private GameObject healthBarBoss = null;
    [SerializeField] private GameObject staminaBar = null;
    [SerializeField] private GameObject potionField = null;
    [SerializeField] private GameObject winMessage = null;
    [SerializeField] private GameObject deathMessage = null;
    [SerializeField] private GameObject bossName = null;
    [SerializeField] private BossController bossController = null;
    [SerializeField] private CharController charController = null;
    [SerializeField] private AudioManager audioManager = null;

    private Slider healthBarBossSlider = null;
    private Slider healthBarCharSlider = null;
    private Slider staminaBarSlider = null;
    private string potionCount = "0";

    private bool soundPlaying = false;

    private void Start()
    {
        healthBarBossSlider = healthBarBoss.GetComponentInChildren<Slider>();
        healthBarCharSlider = healthBarChar.GetComponentInChildren<Slider>();
        staminaBarSlider = staminaBar.GetComponentInChildren<Slider>();
        healthBarBossSlider.maxValue = bossController.Health;
        healthBarCharSlider.maxValue = charController.GetCurrentHealth();
        staminaBarSlider.maxValue = charController.GetCurrentStamina();
    }

    private void Update()
    {
        if(bossController.Health >= 0)
        {
            healthBarBossSlider.value = bossController.Health; 
        }

        if(charController.GetCurrentHealth() >= 0)
        {
            healthBarCharSlider.value = charController.GetCurrentHealth();
        }

        if(charController.GetCurrentStamina() >= 0)
        {
            staminaBarSlider.value = charController.GetCurrentStamina();
        }

        if(charController.GetCurrentPotions() >= 0)
        {
            potionField.GetComponentInChildren<TextMeshProUGUI>().text = charController.GetCurrentPotions().ToString();
        }

        if(charController.GetCurrentHealth() <= 0 && soundPlaying == false)
        {
            soundPlaying = true;
            EnableDeathMessage();
            audioManager.PlayDeathMessageSound();
            audioManager.StopBackgroundMusic();
        }
        else if(bossController.Health <= 0 && soundPlaying == false)
        {
            soundPlaying = true;
            EnableWinMessage();
            audioManager.PlayWinMessageSound();
            audioManager.StopBackgroundMusic();
        }
    }

    public void EnableHealthBarChar()
    {
        healthBarChar.SetActive(true);
    }

    public void DisableHealthBarChar()
    {
        healthBarChar.SetActive(false);
    }

    public void EnableHealthBarBoss()
    {
        healthBarBoss.SetActive(true);
    }

    public void DisableHealthBarBoss()
    {
        healthBarBoss.SetActive(false);
    }

    public void EnableStaminaBar()
    {
        staminaBar.SetActive(true);
    }

    public void DisableStaminaBar()
    {
        staminaBar.SetActive(false);
    }

    public void EnablePotionField()
    {
        potionField.SetActive(true);
    }

    public void DisablePotionField()
    {
        potionField.SetActive(false);
    }

    public void EnableWinMessage()
    {
        winMessage.SetActive(true);
    }

    public void DisableWinMessage()
    {
        winMessage.SetActive(false);
    }

    public void EnableDeathMessage()
    {
        deathMessage.SetActive(true);
    }

    public void DisableDeathMessage()
    {
        deathMessage.SetActive(false);
    }

    public void EnableBossName()
    {
        bossName.SetActive(true);
    }

    public void DisableBossName()
    {
        bossName.SetActive(false);
    }
}
