using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float scaleX;
    private float scaleY;

    public Transform posA;
    public Transform posB;

    public float speed;

    Vector3 TargetPos;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        TargetPos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f)
        {
            TargetPos = posB.position;
            
        }
        if (Vector2.Distance(transform.position, posB.position) < .1f)
        {
            TargetPos = posA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,posB.position) > Vector2.Distance(transform.position, posA.position))
        {
            transform.localScale += new Vector3(0.001f, 0.001f, 0f);
        }

        if (Vector2.Distance(transform.position, posB.position) < Vector2.Distance(transform.position, posA.position))
        {
            transform.localScale += new Vector3(-0.001f, -0.001f, 0f);
        }




    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
