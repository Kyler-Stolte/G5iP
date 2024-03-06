using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillEnemy : MonoBehaviour
{
   
    private Rigidbody rb;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DespawnWall")
        {
            Destroy(gameObject);
        }
    }
}
