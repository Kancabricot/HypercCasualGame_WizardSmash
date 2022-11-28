using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(90,0,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("£",PlayerPrefs.GetInt("£") + 1);
        Debug.Log("coin +1");
        Destroy(gameObject);
    }
}
