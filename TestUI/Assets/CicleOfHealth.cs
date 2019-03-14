﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CicleOfHealth : MonoBehaviour
{
    #region Variables Public
    public Text textHealth;
    public Image imageShield;
    public Image imageHealth;
    [Range(0, 1)]
    public float maxHealth = 1;
    [Range(0, 1)]
    public float health = 0;
    public bool isShieldActive;
    public float coolDownShield = 1.0f;
    #endregion
    #region Variables Private
    private float oldHealth;
    private bool isShieldReset;
    #endregion
    #region UnityMethods
    // Use this for initialization
    void Start()
    {
        UpdateHealth();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health != oldHealth)
        {
            UpdateHealth();
        }
        oldHealth = health;
        if (Input.GetKeyDown(KeyCode.A))
        {
            ApplyDamage(0.1f);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            RegenerateHealth(0.2f);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetShieldActive();  
        }
        AutoRegenerateHealth();
      
        ResetCoolDownShield();
    }
    #endregion
    #region HelperMethods
    private void AutoRegenerateHealth()
    {
        health += 0.01f * Time.deltaTime;
        if (health > maxHealth)
        {
            health = 1.0F;
        }
        if (health < 0.0F)
        {
            health = 0.0f;
        }
    }
    public void ApplyDamage(float damage)
    {
        if (health > 0.0f)
            health -= damage;
    }
    public void UpdateHealth()
    {
        textHealth.text = (health).ToString("#0%");
        imageHealth.fillAmount = health;
    }
    public void RegenerateHealth(float healthToAdd)
    {
        if (health < 1.0f)
            health += healthToAdd;
    }
    public void SetShieldActive()
    {
        if (!isShieldActive)
        {
            isShieldActive = true;
            imageShield.fillAmount = 1.0f;
            StartCoroutine(HealthFade(coolDownShield));
        }
    }
    public void ResetCoolDownShield()
    {
        if (isShieldActive && imageShield.fillAmount <= 0.01f)
        {
            isShieldActive = false;
        }
    }
    IEnumerator CoolDown(float duration)
    {
        if (isShieldActive)
        {
            Debug.Log("shul");
            float startTime = Time.time;
            while (Time.time - startTime <= duration + 0.1F)
            {
                imageShield.fillAmount = (Time.time - startTime / duration);
                yield return null;
            }
        }
    }

    IEnumerator HealthFade(float duration)
    {
              float currentTime = 0f; // the time passed 
        while (currentTime < duration)
        {
            imageShield.fillAmount = Mathf.Lerp(1f, 0f, currentTime / duration); // 0f = 0% hp 1f = 100% Hp, currentTime/time  give you a number between 0 and 1  = the amount of health you want to put inside the bar.
            currentTime += Time.deltaTime;
            yield return null;
        }

    }
}
    #endregion
