using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CicleOfLife : MonoBehaviour {
    public Text textHealth;
    public Image imageHealth;
    //[Range(0,1)]
    public float maxHealth=1;
  //  [Range(0,1)]
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            ApplyDamage(0.5f);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            RegenerateHealth(0.25f);
        }
        oldHealth = health;
	}
    public void ApplyDamage(float damage)
    {
        if(health>0.0f)
        health -= damage;
    }
    public void UpdateHealth()
    {
        imageHealth.fillAmount = health;
    }
    public void RegenerateHealth(float healthToAdd)
    {
        if(health<0.9999f)
        health += healthToAdd;
    }
    

}
