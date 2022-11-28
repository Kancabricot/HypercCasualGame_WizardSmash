using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    [SerializeField] GameObject FXnuke;
       public void PowerH()
    {
        if (PlayerPrefs.GetInt("£") >= 10)
        {
            var pc = PlayerPrefs.GetInt("PH");
            pc++;
            PlayerPrefs.SetInt("PH", pc);

            PlayerPrefs.SetInt("£", PlayerPrefs.GetInt("£") - 10);

            Debug.Log("Buy");
            Debug.Log(pc);
            Debug.Log(PlayerPrefs.GetInt("PH"));
        }
        else
        {
            Debug.Log("Not Buy");
        }
    }

    public void PowerN()
    {
        if (PlayerPrefs.GetInt("£") >= 15)
        {
            var pc = PlayerPrefs.GetInt("PN");
            pc++;
            PlayerPrefs.SetInt("PN", pc);

            PlayerPrefs.SetInt("£", PlayerPrefs.GetInt("£") - 15);

            Debug.Log("Buy");
            Debug.Log(pc);
            Debug.Log(PlayerPrefs.GetInt("PN"));
        }
        else
        {
            Debug.Log("Not Buy");
        }
    }

    public void ActivePH()
    {
        if (PlayerPrefs.GetInt("PH") >= 1)
        {
            PlayerPrefs.SetInt("PH", PlayerPrefs.GetInt("PH") - 1);
            FindObjectOfType<HealthBar>().LifeUp();
            FindObjectOfType<Barricade>().LifeUp();
        }
    }

    public void ActivePN()
    {
        if (PlayerPrefs.GetInt("PN") >= 1)
        {
            PlayerPrefs.SetInt("PN", PlayerPrefs.GetInt("PN") - 1);
            FindObjectOfType<Spawner>().KillAll();
            Instantiate(FXnuke);
        }
    }
}
