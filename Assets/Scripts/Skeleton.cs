using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] float speed = -2f;
    [SerializeField] int damage = 1;
    [SerializeField] float attackSpeed = 2f;
    [SerializeField] GameObject fxDeath;

    private bool canAttack = false;


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

    private void OnMouseDown()
    {
        Instantiate(fxDeath, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void IncreaseSpeed()
    {
        if(speed < 0 && speed > -5f)
        {
            speed += 0.2f;
        }
    }

}
