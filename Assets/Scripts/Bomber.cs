using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] float speed = -2f;
    [SerializeField] int damage = 5;
    [SerializeField] float attackSpeed = 1f;
    [SerializeField] int lifeAtStart = 2;
    private int life = 1;
    [SerializeField] int damageTaken = 1;
    [SerializeField] GameObject fxDeath;

    void Start()
    {
        life = lifeAtStart;
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector2(0, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barricade"))
        {
            Invoke("CallDamage", attackSpeed);
           
        }
    }

    private void CallDamage()
    {
        FindObjectOfType<Barricade>().Damage(damage);
        Destroy(gameObject);
    }

    private void CheckLife()
    {
        if (life <= 0)
        {
            Instantiate(fxDeath, transform.position, transform.rotation);
            enabled = false;
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        life -= damageTaken;

        CheckLife();
    }

    public void IncreaseSpeed()
    {
        if (speed < 0 && speed > -5f)
        {
            speed += 0.2f;
        }
    }
}
