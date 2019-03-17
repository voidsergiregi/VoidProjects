using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
    public Image imageHealth;
    public Image imagDamage;
    public Text textHealth;
    public float health=0.5f;
    public float maxHealth=1f;
    public float oldHealth;
    public float currentDamage;
    public bool autoRegenerateHealth;
    public float regenerationHealthAmount;

    
    void Start()
    {
        UpdateHealth();
        health = maxHealth;
    }
    void Update()
    {
        if (health != oldHealth)
        {
            UpdateHealth();
        }
        oldHealth = health;
        if (Input.GetKeyDown(KeyCode.A))
        {
            ApplyDamage(Random.Range(0.1f,0.5f));
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            RegenerateHealth(0.01f);
        }
        AutoRegenerateHealth();
    }
    
  
    private void AutoRegenerateHealth()
    {
        if (autoRegenerateHealth)
        {
            health += regenerationHealthAmount * Time.deltaTime;
            health = Mathf.Clamp01(health);
            if (imagDamage.fillAmount < health)
            {
                imagDamage.fillAmount = health;
            }
        }
    }
    public void ApplyDamage(float damage)
    {
        float curHealt= health;
        if (health > 0.0f)
        {
            health -= damage;
           StartCoroutine(CoolDownDamage(curHealt, health));
        }
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
   
    IEnumerator CoolDownDamage(float init, float end)
    {
        float fillration = 0;
        while (init >= end)
        {
            fillration += Time.deltaTime * 0.002f;
            init-= fillration;
            imagDamage.fillAmount -= fillration;
            yield return null;
        }
    }
}
