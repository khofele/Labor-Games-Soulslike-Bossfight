using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject healthBarChar = null;
    [SerializeField] private GameObject healthBarBoss = null;
    [SerializeField] private GameObject staminaBar = null;
    [SerializeField] private GameObject potionField = null;
    [SerializeField] private GameObject winMessage = null;
    [SerializeField] private GameObject deathMessage = null;
    [SerializeField] private GameObject bossName = null;
    
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
