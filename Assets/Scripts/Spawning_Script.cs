using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spawning_Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject[] enemies;




    public Transform[] spawnPoint;

    private int RandEnemy;
    private int randPosition;

    

    public float StartTimeBetweenSpawns;

    private float TimeBetwSpawns;

    public float timer;

    private int ResetTime;




    void Start()
    {
        TimeBetwSpawns = StartTimeBetweenSpawns;
        timer = ResetTime;
     
       // RandEnemy = Random.Range(0, enemies.Length);
       // randPosition = Random.Range(0, spawnPoint.Length);

        

        

    }
    // Update is called once per frame

    void Update()
    {
        timer += Time.deltaTime;
       



        if (TimeBetwSpawns <= 0)
        {

           // if (timer >= 10 && timer < 20)
           // {
           //     SpawnRandEnemy();
           //
           //     if (timer >= 40 && EnemyActive == true)
           //     {
           //         this.gameObject.SetActive(false);
           //         timer = ResetTime;
           //     }

              
         //   }

           // else if (timer >= 20)
           // {
           //     SpawnCurvedEnemy();
           // }

            SpawnRandEnemy();

        }
        else
        {
            TimeBetwSpawns -= Time.deltaTime;
        }


    }

    private void SpawnEnemy()
    {
        GameObject enemyClone = Instantiate(enemies[0], spawnPoint[3].transform.position, Quaternion.identity);
        enemyClone.SetActive(true);
        TimeBetwSpawns = StartTimeBetweenSpawns;
    }

    private void SpawnCurvedEnemy()
    {
        GameObject curveEnemyClone = Instantiate(enemies[1], spawnPoint[0].transform.position, Quaternion.identity);
        curveEnemyClone.SetActive(true);
        TimeBetwSpawns = StartTimeBetweenSpawns;
    }

    private void SpawnFlashEnemy()
    {
        GameObject flashEnemyClone = Instantiate(enemies[2], spawnPoint[2].transform.position, Quaternion.identity);
        flashEnemyClone.SetActive(true);
        TimeBetwSpawns = StartTimeBetweenSpawns;
    }


    private void SpawnRandEnemy()
    {
        var RandomSpawn = spawnPoint[Random.Range(0, spawnPoint.Length)];
        var RandomEnemy = enemies[Random.Range(0, enemies.Length)];

       GameObject RandomEnemyClone = Instantiate(RandomEnemy.gameObject, RandomSpawn.transform.position, Quaternion.identity);
        RandomEnemyClone.SetActive(true);
        TimeBetwSpawns = StartTimeBetweenSpawns;
    }
   

}




