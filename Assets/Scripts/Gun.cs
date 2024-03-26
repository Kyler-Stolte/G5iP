using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    public Animator animator;

    public Transform Tracker;
    private void Start()
    {
        
        Tracker.position = transform.position;
    }
    private void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //gun tracks mouse
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
       // transform.up = direction;
      

    }
    private void Update()
    {

       // Vector3 Angle = new Vector3(0, 0, transform.rotation.z);
       // animator.SetFloat("Angle", transform.rotation.eulerAngles.z);
        if (Input.GetMouseButtonDown(0) == true)
        {
            animator.SetBool("IsClicked", true);
            animator.SetBool("IsNotClicked", false);
        }
        else
        {
            animator.SetBool("IsNotClicked", true);
            animator.SetBool("IsClicked", false);
        }


        
    }
}

    

       