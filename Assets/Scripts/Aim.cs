using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Aim: MonoBehaviour
{
    public KeyCode Shoot
   

    private void Start()
    {
       UnityEngine.Cursor.visible = false; // makes mouse cursor invisible. For some reason you need to click for it to work
    }

    private void FixedUpdate()
    {
        Vector2 mousePosition = Input.mousePosition; //provides a value for the mouse position in pixels
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //translates mouse pixel position into co-ordinates relative to the scene
        Vector2 position = new Vector2(mousePosition.x, mousePosition.y); //crosshair can track the mouse
        transform.localPosition = position; // crosshair follows mouse
        
    }
}