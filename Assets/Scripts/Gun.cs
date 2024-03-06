using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    public Animator animator;
    private void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //gun tracks mouse
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        if (Input.GetMouseButtonDown(0) == true)
        {
            animator.SetBool("IsClicked", true);
            animator.SetBool("IsNotClicked", false);
        }
        else if (Input.GetMouseButtonDown(0) != true)
        {
            animator.SetBool("IsClicked", false);
            animator.SetBool("IsNotClicked", true);
        }


        if (transform.rotation.z > 45 || transform.rotation.z > 75)
        {
            animator.SetFloat("posRot", 45);
        }


       
    }
}

    

       