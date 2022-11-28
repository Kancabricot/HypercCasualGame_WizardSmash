using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField] float speed = -2f;
    [SerializeField] int damage = 1;
    [SerializeField] float attackSpeed = 2f;
    [SerializeField] GameObject fxDeath;
    [SerializeField] GameObject fxGunShot;

    private bool canAttack = false;


    void Update()
    {
        if (canAttack == false)
        {
            GetComponent<Rigidbody>().velocity = new Vector2(0, speed);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector2.zero;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StopArcher"))
        {
            canAttack = true;
            CallDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("StopArcher"))
        {
            canAttack = false;
        }
    }

    private void CallDamage()
    {

        if (canAttack)
        {
            Instantiate(fxGunShot, transform.position, transform.rotation);
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
        if (speed < 0 && speed > -5f)
        {
            speed += 0.2f;
        }
    }
}
