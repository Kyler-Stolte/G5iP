using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Aim : MonoBehaviour
{


    private void Start()
    {
        UnityEngine.Cursor.visible = false; // makes mouse cursor invisible. For some reason you need to click for it to work
    }



    private void Update()
    {


        Vector2 mousePosition = Input.mousePosition; //provides a value for the mouse position in pixels
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //translates mouse pixel position into co-ordinates relative to the scene
        Vector2 position = new Vector2(mousePosition.x, mousePosition.y); //crosshair can track the mouse
        transform.localPosition = position; // crosshair follows mouse


        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            if (Physics2D.Raycast(ray.origin, ray.direction, new ContactFilter2D(), hits) > 0)
            {
                print("Success");
                // if(hit.collider.tag == "Enemy")
                // {
                //     Destroy(hit.collider.gameObject);
                // }
            }
        }


    }
}

