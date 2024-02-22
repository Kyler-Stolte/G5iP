using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawning_Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject Enemy1;
    [SerializeField] public GameObject Enemy2;
    [SerializeField] public GameObject Enemy3;


    public float SpawnTimer = 0f;
    public float Delay = 0f;
    public int NumSpawns = 0;
    public int MaxSpawns;
    void Start()
    {
        NumSpawns = MaxSpawns;
        SpawnTimer = Time.time;
        Random.Range(0, MaxSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        if (NumSpawns >1){
            if (SpawnTimer <= 0)
            {
                Instantiate(Enemy1, transform.position, Quaternion.identity);
            }
            while (Delay > 0f)
            {
                    gameObject.SetActive(false);

                    Instantiate(Enemy2, transform.position, Quaternion.identity);
                    Instantiate(Enemy3, transform.position, Quaternion.identity);
            }
            }
        }
    }

