using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OverallTimer : MonoBehaviour
{
    float timer;
    public float threshold2;
    public float threshold3;
    public float threshold4;
    public float threshold5;
    public float threshold6;
    public TargetSpawner[] targetSpawner;

    //used for dealing with time clashes
    bool timeResetHasRun1;
    bool timeResetHasRun2;


    public void Update()
    {
        timer += Time.deltaTime;

        //changes the threshold bools in the spawner as time passes
        if (timer >= threshold2 && timer <= threshold3)
        {
            targetSpawner[0].threshold1 = false;
            targetSpawner[0].threshold2 = true;
            targetSpawner[0].threshold3 = false;
            targetSpawner[0].threshold4 = false;
            targetSpawner[0].threshold5 = false;
            targetSpawner[0].threshold6 = false;

            targetSpawner[1].threshold1 = false;
            targetSpawner[1].threshold2 = true;
            targetSpawner[1].threshold3 = false;
            targetSpawner[1].threshold4 = false;
            targetSpawner[1].threshold5 = false;
            targetSpawner[1].threshold6 = false;
        }

        if (timer >= threshold3 && timer <= threshold4)
        {   
            targetSpawner[0].threshold1 = false;
            targetSpawner[0].threshold2 = false;
            targetSpawner[0].threshold3 = true;
            targetSpawner[0].threshold4 = false;
            targetSpawner[0].threshold5 = false;
            targetSpawner[0].threshold6 = false;

            targetSpawner[1].threshold1 = false;
            targetSpawner[1].threshold2 = false;
            targetSpawner[1].threshold3 = true;
            targetSpawner[1].threshold4 = false;
            targetSpawner[1].threshold5 = false;
            targetSpawner[1].threshold6 = false;
        }

        if (timer >= threshold4 && timer <= threshold5)
        {
            targetSpawner[0].threshold1 = false;
            targetSpawner[0].threshold2 = false;
            targetSpawner[0].threshold3 = false;
            targetSpawner[0].threshold4 = true;
            targetSpawner[0].threshold5 = false;
            targetSpawner[0].threshold6 = false;

            targetSpawner[1].threshold1 = false;
            targetSpawner[1].threshold2 = false;
            targetSpawner[1].threshold3 = false;
            targetSpawner[1].threshold4 = true;
            targetSpawner[1].threshold5 = false;
            targetSpawner[1].threshold6 = false;
        }

        if (timer >= threshold5 && timer <= threshold6)
        {
            targetSpawner[0].threshold1 = false;
            targetSpawner[0].threshold2 = false;
            targetSpawner[0].threshold3 = false;
            targetSpawner[0].threshold4 = false;
            targetSpawner[0].threshold5 = true;
            targetSpawner[0].threshold6 = false;

            targetSpawner[1].threshold1 = false;
            targetSpawner[1].threshold2 = false;
            targetSpawner[1].threshold3 = false;
            targetSpawner[1].threshold4 = false;
            targetSpawner[1].threshold5 = true;
            targetSpawner[1].threshold6 = false;
        }

        if (timer >= threshold6)
        {
            targetSpawner[0].threshold1 = false;
            targetSpawner[0].threshold2 = false;
            targetSpawner[0].threshold3 = false;
            targetSpawner[0].threshold4 = false;
            targetSpawner[0].threshold5 = false;
            targetSpawner[0].threshold6 = true;

            targetSpawner[1].threshold1 = false;
            targetSpawner[1].threshold2 = false;
            targetSpawner[1].threshold3 = false;
            targetSpawner[1].threshold4 = false;
            targetSpawner[1].threshold5 = false;
            targetSpawner[1].threshold6 = true;
        }

        //Handles spawning timing clashes from the threshold change


        if (timer >= threshold3 && timer <= threshold4 && timeResetHasRun1 == false)
        {
            timeResetHasRun1 = true;

            targetSpawner[0].timer = 0;
            targetSpawner[1].timer = 0;
        }

        if (timer >= threshold5 && timer <= threshold6 && timeResetHasRun2 == false)
        {
            timeResetHasRun2 = true;

            targetSpawner[0].timer = 0;
            targetSpawner[1].timer = 0;
        }
    }
}
