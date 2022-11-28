using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orc : MonoBehaviour
{
    [SerializeField] float speed = -2f;
    [SerializeField] int damage = 2;
    [SerializeField] float attackSpeed = 2f;
    [SerializeField] int lifeAtStart = 3;
    private int life = 1;
    [SerializeField] int damageTaken = 1;
    [SerializeField] GameObject fxDeath;


    private bool canAttack = false;

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
            canAttack = true;
            CallDamage();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barricade"))
        {
            canAttack = false;
        }
    }

    private void CallDamage()
    {

        if (canAttack)
        {
            FindObjectOfType<Barricade>().Damage(damage);
            Invoke("CallDamage", attackSpeed);
        }

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
        FindObjectOfType<OrcHealthBar>().LostLife(damageTaken);
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
