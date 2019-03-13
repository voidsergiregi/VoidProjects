using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CicleOfLife : MonoBehaviour {
    public Text textHealth;
    public Image imageHealth;
    [Range(0,1)]
    public float maxHealth=1;
    [Range(0,1)]
    public float health=0;
    public float oldHealth;
	// Use this for initialization
	void Start () {
        UpdateHealth();
        health = maxHealth;
      ///  oldHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
        if(health!=oldHealth)
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
        AutoRegenerateHealth();
	}

    private void AutoRegenerateHealth()
    {
        health += 0.01f * Time.deltaTime;
        if (health>maxHealth)
        {
            health = 1.0F;
        }
        if(health<0.0F)
        {
            health = 0.0f;
        }
    }

    public void ApplyDamage(float damage)
    {
        if(health>0.0f)
        health -= damage;
    }
    public void UpdateHealth()
    {
        if (health < 0.01f)
            textHealth.text = "0%";
        else
        textHealth.text = (health).ToString("#%") ;
        imageHealth.fillAmount = health;
    }
    public void RegenerateHealth(float healthToAdd)
    {
        if(health<1.0f)
        health += healthToAdd;
    }
    

}
