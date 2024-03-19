using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CurveEnemy : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public Transform posC;
    public Transform posD;

    public Transform posA_1;
    public Transform posB_1;
    public Transform posC_1;
    public Transform posD_1;


    [SerializeField]
    private Transform[] routes; 

    private Vector2 enemyPos;

    private bool coroutineAllowed;

    private int routeToGo;

    private Rigidbody2D rb;

    public float speed;
   
    private float tcount;

    private Vector2 gizmosPosition;

    public GameObject parent;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tcount = 0f;
        routeToGo = 0;
        coroutineAllowed = true;
      
    }

    void Update()
    {

        if(coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }

        StartCoroutine(Despawn());

    }

    private void OnDrawGizmos() 
    {
        for(float t=0; t<=1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * posA.position + 3 * Mathf.Pow(1 - t, 2) * t * posB.position +
                3 * Mathf.Pow(1 - t, 1) * Mathf.Pow(t, 2) * posC.position + Mathf.Pow(t, 3) * posD.position;

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * posA_1.position + 3 * Mathf.Pow(1 - t, 2) * t * posB_1.position +
                3 * Mathf.Pow(1 - t, 1) * Mathf.Pow(t, 2) * posC_1.position + Mathf.Pow(t, 3) * posD_1.position;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }


        Gizmos.DrawLine(new Vector2(posA.position.x, posA.position.y), new Vector2(posB.position.x, posB.position.y));
        Gizmos.DrawLine(new Vector2(posC.position.x, posC.position.y), new Vector2(posD.position.x, posD.position.y));
        
    }

  private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        for (tcount = 0; tcount<1; tcount+=speed)
        {

            enemyPos = Mathf.Pow(1 - tcount, 3) * p0 + 3 * Mathf.Pow(1 - tcount, 2) * tcount * p1 +
                3 * Mathf.Pow(1 - tcount, 1) * Mathf.Pow(tcount, 2) * p2 + Mathf.Pow(tcount, 3) * p3;

           

            transform.position = enemyPos;
            yield return new WaitForEndOfFrame();
        }


        tcount = 0f;
        routeToGo += 1;

        if(routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

       

        coroutineAllowed = true;

    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(10f);
        Destroy(parent.gameObject);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DespawnWall")
        {
            Destroy(parent);
        }
    }



}
