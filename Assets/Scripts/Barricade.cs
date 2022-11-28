using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    [SerializeField] int lifePoint = 20;

    public void Damage(int damageTaken)
    {
        lifePoint -= damageTaken;
        FindObjectOfType<HealthBar>().LostLife(damageTaken);
        if (lifePoint <= 0)
        {
            GameOver();
        }

    }

    private void GameOver()
    {
        FindObjectOfType<GameManager>().GameOver();
    }

    public void LifeUp()
    {
        lifePoint += 5;
    }
}
