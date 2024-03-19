using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spawning_Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject[] enemies;




    public Transform[] spawnPoint;

    private int Rand;
    private int randPosition;

    public float StartTimeBetweenSpawns;

    private float TimeBetwSpawns;

    public float timer;

    private int ResetTime;

    private bool EnemyActive;



    void Start()
    {
        TimeBetwSpawns = StartTimeBetweenSpawns;
        timer = ResetTime;
        EnemyActive = true;


    }
    // Update is called once per frame

    void Update()
    {
        timer += Time.deltaTime;



        if (TimeBetwSpawns <= 0)
        {
            Rand = Random.Range(0, enemies.Length);
            randPosition = Random.Range(0, randPosition);

            if (timer >= 10 && timer < 20)
            {
                SpawnEnemy();

                if (timer >= 40 && EnemyActive == true)
                {
                    this.gameObject.SetActive(false);
                    timer = ResetTime;
                }

              
            }

            else if (timer >= 20)
            {
                SpawnCurvedEnemy();
            }

        }
        else
        {
            TimeBetwSpawns -= Time.deltaTime;
        }


    }

    private void SpawnEnemy()
    {
        GameObject enemyClone = Instantiate(enemies[0], transform.position, Quaternion.identity);
        enemyClone.SetActive(true);
        TimeBetwSpawns = StartTimeBetweenSpawns;
    }

    private void SpawnCurvedEnemy()
    {
        GameObject curveEnemyClone = Instantiate(enemies[1], transform.position, Quaternion.identity);
        curveEnemyClone.SetActive(true);
        TimeBetwSpawns = StartTimeBetweenSpawns;
    }

    private void SpawnFlashEnemy()
    {
        GameObject flashEnemyClone = Instantiate(enemies[2], transform.position, Quaternion.identity);
        flashEnemyClone.SetActive(true);
        TimeBetwSpawns = StartTimeBetweenSpawns;
    }

}




