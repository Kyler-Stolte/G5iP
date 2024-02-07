using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //gun tracks mouse
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            print("Shoot");
        }

    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.tag == "Enemy")
        {
            Object.Destroy(gameObject);
        }
    }


}
