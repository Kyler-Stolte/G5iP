using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawning_Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject[] enemies;

    public Transform spawnPoint;

    private int Rand;
    private int randPosition;

    public float StartTimeBetweenSpawns;

    private float TimeBetwSpawns;
    void Start()
    {
        TimeBetwSpawns = StartTimeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeBetwSpawns <=0)
        {
            Rand = Random.Range(0, enemies.Length);
            randPosition = Random.Range(0, randPosition);
            Instantiate(enemies[Rand],transform.position, Quaternion.identity);
            TimeBetwSpawns = StartTimeBetweenSpawns;
        }
        else
        {
            TimeBetwSpawns -= Time.deltaTime;
        }

       
    }
}

