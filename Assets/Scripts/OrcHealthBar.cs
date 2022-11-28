using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrcHealthBar : MonoBehaviour
{
    [SerializeField] const float maxHealth = 5f;
    [SerializeField] float health = maxHealth;
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

    public void LostLife(int damageTanken)
    {
        health -= damageTanken;
    }
}
