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

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //sends out a ray from the camera to the mouse position

            List<RaycastHit2D> hits = new List<RaycastHit2D>();// make a list containing what the ray contacts with

            if (Physics2D.Raycast(ray.origin, ray.direction, new ContactFilter2D(), hits) > 0) //adds ray collisions to the list
           {
               
                for(int i = 0; i < hits.Count; i++)
                {
                    RaycastHit2D pit = hits[i];   //makes the value from the hit list into a Ratcast value via pits
                    if(pit.collider.gameObject.tag == ("Enemy"))
                    {
                        Destroy(pit.collider.gameObject);  //if pits contains the Enemy tag it destroys the Enemy Object
                    }
                }
               
            }
        }


    }
}

