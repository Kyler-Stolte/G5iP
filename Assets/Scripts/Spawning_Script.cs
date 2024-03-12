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

    [SerializeField] public List<GameObject> currentEnemy;

    public Transform spawnPoint;

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
  

        if (TimeBetwSpawns <=0)
        {
            Rand = Random.Range(0, enemies.Length);
            randPosition = Random.Range(0, randPosition);

            if (timer >= 10 && timer < 20)
            {
                Instantiate(enemies[0], transform.position, Quaternion.identity);
                currentEnemy.Add(enemies[0]);
                TimeBetwSpawns = StartTimeBetweenSpawns;
                
                if (timer >= 40 && EnemyActive == true)
                {
                    this.gameObject.SetActive(false);
                    timer = ResetTime;
                }
            } else if (timer >= 20)
            {
                Instantiate(enemies[1], transform.position, Quaternion.identity);
                currentEnemy.Add(enemies[1]);
                TimeBetwSpawns = StartTimeBetweenSpawns;
                //if (timer >= 40 && EnemyActive == true)
                //{
                //    this.gameObject.SetActive(false);
                //    timer = ResetTime;
                    
               // }
            }

        }
        else
        {
            TimeBetwSpawns -= Time.deltaTime;
        }
  
       
    }
}




