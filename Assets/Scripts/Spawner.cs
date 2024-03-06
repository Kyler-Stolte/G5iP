using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] targets1;
    public GameObject[] targets2;
    public GameObject[] targets3;
    public GameObject[] targets4;
    public GameObject[] targets5;
    public GameObject[] targets6;

    
    
    //Handles the current target in the array
    public int current = 0;

    //This isn't in use right now
    public int maxUniqueTargets;
    
    //Used for if statements for time thresholds
    public bool threshold1;
    public bool threshold2;
    public bool threshold3;
    public bool threshold4;
    public bool threshold5;
    public bool threshold6;
   
    //used for triggering a spawn
    public bool spawnTargetsEnabled;

    public float timer;

    //used for triggering despawn
    public GameObject despawnWall;

    private void Start()
    {
        threshold1 = true;
        threshold2 = false;
        threshold3 = false;
        threshold4 = false;
        threshold5 = false;
        threshold6 = false;
        spawnTargetsEnabled = true;
    }

    public void Update()
    {
        //Resets the current to loop the target spawns
        if (current > 5)
        {
            current = 0;
        }


        //If statement for each threshold spawn
        if (threshold1 == true && spawnTargetsEnabled == true)
            SpawnWave1();

        if (threshold2 == true && spawnTargetsEnabled == true)
            SpawnWave2();

        if (threshold3 == true && spawnTargetsEnabled == true)
            SpawnWave3();

        if (threshold4 == true && spawnTargetsEnabled == true)
            SpawnWave4();

        if (threshold5 == true && spawnTargetsEnabled == true)
            SpawnWave5();

        if (threshold6 == true && spawnTargetsEnabled == true)
            SpawnWave6();

        //Handles the timer trigerring spawns for each threshold
        
        //Whenever an objective is cleared, have that reset timer to 0 so we don't get multiple spawns
        timer += Time.deltaTime;

        if (timer >= 17 && threshold1 == true)
        {
            spawnTargetsEnabled = true;
            despawnWall.SetActive(false);
        }

        if (timer >= 17 && threshold2 == true)
        {
            spawnTargetsEnabled = true;
            despawnWall.SetActive(false);
        }

        if (timer >= 12 && threshold3 == true)
        {
            spawnTargetsEnabled = true;
            despawnWall.SetActive(false);
        }

        if (timer >= 12 && threshold4 == true)
        {
            spawnTargetsEnabled = true;
            despawnWall.SetActive(false);
        }

        if (timer >= 7 && threshold5 == true)
        {
            spawnTargetsEnabled = true;
            despawnWall.SetActive(false);
        }

        if (timer >= 7 && threshold6 == true)
        {
            spawnTargetsEnabled = true;
            despawnWall.SetActive(false);
        }

        //Handles despawning
        if (timer >= 15 && timer <= 16 && threshold1 == true)
        {
            despawnWall.SetActive(true);
        }

        if (timer >= 15 && timer <= 16 && threshold2 == true)
        {
            despawnWall.SetActive(true);
        }

        if (timer >= 10 && timer <= 11 && threshold3 == true)
        {
            despawnWall.SetActive(true);
        }

        if (timer >= 10 && timer <= 11 && threshold4 == true)
        {
            despawnWall.SetActive(true);
        }

        if (timer >= 5 && timer <= 6 && threshold5 == true)
        {
            despawnWall.SetActive(true);
        }

        if (timer >= 5 && timer <= 6 && threshold6 == true)
        {
            despawnWall.SetActive(true);
        }

    }

    //Are called on to spawn for their corresponding threshold
    public virtual void SpawnWave1()
    {
        GameObject wave = Instantiate(targets1[current], transform.position, transform.rotation);
        current++;
        spawnTargetsEnabled = false;
        timer = 0;
    }

    public virtual void SpawnWave2()
    {
        GameObject wave = Instantiate(targets2[current], transform.position, Quaternion.identity);
        current++;
        spawnTargetsEnabled = false;
        timer = 0;
    }

    public virtual void SpawnWave3()
    {
        GameObject wave = Instantiate(targets3[current], transform.position, Quaternion.identity);
        current++;
        spawnTargetsEnabled = false;
        timer = 0;
    }

    public virtual void SpawnWave4()
    {
        GameObject wave = Instantiate(targets4[current], transform.position, Quaternion.identity);
        current++;
        spawnTargetsEnabled = false;
        timer = 0;
    }

    public virtual void SpawnWave5()
    {
        GameObject wave = Instantiate(targets5[current], transform.position, Quaternion.identity);
        current++;
        spawnTargetsEnabled = false;
        timer = 0;
    }

    public virtual void SpawnWave6()
    {
        GameObject wave = Instantiate(targets6[current], transform.position, Quaternion.identity);
        current++;
        spawnTargetsEnabled = false;
        timer = 0;
    }
}
