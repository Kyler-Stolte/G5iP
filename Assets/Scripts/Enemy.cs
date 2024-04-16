using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float scaleX;
    private float scaleY;

    public Transform posA;
    public Transform posB;

    private float speed = 7f;

    Vector3 TargetPos;

    private Rigidbody rb;

    public GameObject parent;

    private Spawning_Script spawner;

    private bool IsOn;

    private float Fast = 14f;

    private UI_Manager manager;

   

  

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();


        rb = GetComponent<Rigidbody>();

        TargetPos = posB.position;

        spawner = GetComponent<Spawning_Script>();


    

        

        StartCoroutine(Despawn());

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOn)
        {
            IsOn = Input.GetKeyDown(KeyCode.H);
        }


           if (Vector2.Distance(transform.position, posA.position) < .1f)
           {
               TargetPos = posB.position;
               
           }
           if (Vector2.Distance(transform.position, posB.position) < .1f)
           {
               TargetPos = posA.position;
           }
          if (IsOn == true)
          {
           
                transform.position = Vector3.MoveTowards(transform.position, TargetPos, Fast * Time.deltaTime);
            

           if (Fast < 14f || Fast > 14f)
           {
                Fast = 14;
           }
        }
          else if(IsOn == false)
          {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
          }
        
 

       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(posA.position, posB.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DespawnWall")
        {
            Destroy(parent);
        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(10f);
        Destroy(parent.gameObject);
    }
}
