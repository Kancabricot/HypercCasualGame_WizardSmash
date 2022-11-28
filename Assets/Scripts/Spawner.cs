using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPointSkeleton;
    [SerializeField] Transform[] spawnPointOrc;
    [SerializeField] Transform[] spawnPointBomber;
    [SerializeField] Transform[] spawnPointArcher;
    [SerializeField] Transform[] spawnPointCoin;

    [SerializeField] GameObject Coin;

    [SerializeField] TextMesh txtWave;

    [SerializeField] GameObject Skeleton;
    [SerializeField] GameObject Orc;
    [SerializeField] GameObject bomber;
    [SerializeField] GameObject archer;

    [SerializeField] float cooldownManager;
    [SerializeField] float cooldownCManager;
    private float cooldown = 0;
    private float cooldownC = 0;

    private float cooldownStartWave = 2;
    private bool canModify = false;

    private int wave = 1;
    private int oldWave = 0;

    private int nbOrc = 0;
    private int nbOldOrc = 0;
    
    private int nbBomber = 0;
    private int nbOldBomber = 0;

    private int nbSkeleton = 0;
    private int nbOldSkeleton = 0;

    private int nbArcher = 0;
    private int nbOldArcher = 0;

    public GameObject[] Ennemy;

    void Start()
    {
        cooldown = cooldownManager;
        cooldownC = cooldownCManager;

        nbSkeleton = 5;

        oldWave = wave;

        nbOldOrc = nbOrc;
        nbOldSkeleton = nbSkeleton;

        txtWave.text = "Wave : " + wave.ToString();
        txtWave.gameObject.SetActive(true);
    }

    void Update()
    {
       
        Ennemy = GameObject.FindGameObjectsWithTag("Ennemy");

        if (oldWave == wave && 2 == 2)
        {
            SpawnEnnemy();
        }
        else
        {
            if (Ennemy.Length == 0)
            {
                Incrementation();
            }
        }

        if (cooldownC < 0)
        {
            if (Random.Range(1, 100) < 60)
            {
                int randSpawnPoint = Random.Range(0, spawnPointCoin.Length);

                Instantiate(Coin, spawnPointCoin[randSpawnPoint].position, transform.rotation);
            }
            cooldownC = cooldownCManager;
        }
        else
        {
            cooldownC -= Time.deltaTime;
        }
           
        

    }

    private void SpawnEnnemy()
    {
        if (cooldown < 0)
        {
            if (nbOrc > 0 && Random.Range(1, 10) == 5)
            {
                int randSpawnPoint = Random.Range(0, spawnPointOrc.Length);

                Instantiate(Orc, spawnPointOrc[randSpawnPoint].position, transform.rotation);

                nbOrc--;

                cooldown = cooldownManager;
            }
            else if (nbArcher > 0 && Random.Range(1, 5) == 2)
            {
                int randSpawnPoint = Random.Range(0, spawnPointArcher.Length);

                Instantiate(archer, spawnPointArcher[randSpawnPoint].position, transform.rotation);

                nbArcher--;

                cooldown = cooldownManager;
            }
            else if (nbBomber > 0 && Random.Range(1, 5) == 2)
            {
                int randSpawnPoint = Random.Range(0, spawnPointBomber.Length);

                Instantiate(bomber, spawnPointBomber[randSpawnPoint].position, transform.rotation);

                nbBomber--;

                cooldown = cooldownManager;
            }
            else if (nbSkeleton > 0)
            {
                int randSpawnPoint = Random.Range(0, spawnPointSkeleton.Length);

                Instantiate(Skeleton, spawnPointSkeleton[randSpawnPoint].position, transform.rotation);

                nbSkeleton--;

                cooldown = cooldownManager;
            }
            else if (nbOrc > 0)
            {

                int randSpawnPoint = Random.Range(0, spawnPointOrc.Length);

                Instantiate(Orc, spawnPointOrc[randSpawnPoint].position, transform.rotation);

                nbOrc--;

                cooldown = cooldownManager;
            }
            else
            {
                wave++;
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void Incrementation()
    {

        if (wave >= 6 && canModify == true && cooldownManager >= 0.2f)
        {
            cooldownManager -= 0.02f;
            canModify = false;
        }

        nbSkeleton = nbOldSkeleton + Random.Range(2, 6);
        
        if (wave >= 5 && wave % 2 == 1)
        {
            nbOrc = nbOldOrc + 1;
            
            nbSkeleton = nbSkeleton - 1 * nbOrc;
        }

        if (wave >= 4)
        {
            nbArcher = nbOldArcher + 1;

            nbSkeleton = nbSkeleton - 1 * nbArcher;
        }

        if (wave >= 2)
        {
            nbBomber = nbOldBomber + 1;
            
            nbSkeleton = nbSkeleton - 1 * nbBomber;
        }

        if (cooldownStartWave < 0)
        {
            cooldownStartWave = 2;
            nbOldBomber = nbBomber;
            nbOldArcher = nbArcher;
            nbOldOrc = nbOrc;
            nbOldSkeleton = nbSkeleton;
            StartWave();
            canModify = true;
        }
        else
        {
            cooldownStartWave -= Time.deltaTime;
        }

    
    }

    private void StartWave()
    {
        oldWave = wave;

        txtWave.text = "Wave : " + wave.ToString();
    }

    public void KillAll()
    {
        for (int i = 0; i < Ennemy.Length; i++)
        {
            Destroy(Ennemy[i].gameObject);
        }
    }

}
