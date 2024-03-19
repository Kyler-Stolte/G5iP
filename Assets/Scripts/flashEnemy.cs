using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashEnemy : MonoBehaviour
{

    private float flashOutTimer;
    private float flashInTimer;
    private bool active;

    public GameObject child;

    private void Start()
    {
        flashOutTimer = 2f;
        flashInTimer = 1f;
        active = true;
        StartCoroutine(Despawn());
    }
    void Update()
    {
       if(active == true)
        {
            if(flashOutTimer <= 2f)
            {
                flashOutTimer -= Time.deltaTime;
            }

            if(flashOutTimer <= 0)
            {
                child.gameObject.SetActive(false);
                flashInTimer = 1f;
                active = false;
            }

        } 
       

        if(active == false)
        {
            

            if(flashInTimer <= 1)
            {
                flashInTimer -= Time.deltaTime;
            }


            if(flashInTimer <= 0)
            {
                child.gameObject.SetActive(true);
                flashOutTimer = 2f;
                active = true;

            }
        }

 
    }


    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }


}
