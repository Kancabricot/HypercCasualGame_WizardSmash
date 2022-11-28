using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const float maxHealth = 20f;
    public float health = maxHealth;
    private Image healthBar;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void LostLife(int damageTaken)
    {
        health -= damageTaken;
    }

    public void LifeUp()
    {
        health += 5;
    }
}
