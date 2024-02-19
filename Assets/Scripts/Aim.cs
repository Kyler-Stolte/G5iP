
using System.Collections.Generic;

using UnityEngine;


public class Aim : MonoBehaviour
{

    private int maxAmmo = 10;//maximum ammo allows
    private int currentAmmo;// current ammo of the weapon

    private int specialAmmo = 5;
    private int currentSpecialAmmo;

    private int lifeCount = 3;
    private int currentLife;

    private UI_Manager ui_manager;//need to call the UI manager set it to ui_manager

    public GameObject Cam;
   
    public float CamSpeed;

    private Vector3 StartPos;

    public Transform AimPos;

    private int OutBounds = 9;

    private void Start()
    {
        UnityEngine.Cursor.visible = false; // makes mouse cursor invisible. For some reason you need to click for it to work

        currentAmmo = maxAmmo;
        currentSpecialAmmo = specialAmmo;
        currentLife = lifeCount;

        StartPos = AimPos.position;

        ui_manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();//needs to find the canvas object in the UI component



    }



    private void Update()
    {
        
        Vector2 mousePosition = Input.mousePosition; //provides a value for the mouse position in pixels
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //translates mouse pixel position into co-ordinates relative to the scene
        Vector2 position = new Vector2(mousePosition.x, mousePosition.y); //crosshair can track the mouse
        transform.localPosition = position; // crosshair follows mouse

        if (transform.localPosition.x >= OutBounds || transform.localPosition.x <= -OutBounds)
        {
            Cam.transform.position = new Vector3(transform.position.x, 0, -10) * CamSpeed;
        }
        if (lifeCount == 0)
        {
            this.gameObject.SetActive(false);
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //sends out a ray from the camera to the mouse position

            List<RaycastHit2D> hits = new List<RaycastHit2D>();// make a list containing what the ray contacts with

            if (Physics2D.Raycast(ray.origin, ray.direction, new ContactFilter2D(), hits) > 0) //adds ray collisions to the list
           {
                currentAmmo--;//takes away our current ammo
                ui_manager.UpdateAmmo(currentAmmo);//updates the UI manager of our current ammo

                for (int i = 0; i < hits.Count; i++)
                {
                    RaycastHit2D pit = hits[i];   //makes the value from the hit list into a Raycast value via pits
                    if (pit.collider.gameObject.tag == ("Enemy"))
                    {
                        Destroy(pit.collider.gameObject);  //if pits contains the Enemy tag it destroys the Enemy Object
                    }
                    else if(pit.collider.gameObject.tag == ("Special"))
                    {
                        lifeCount--;
                        ui_manager.UpdateLife(lifeCount);//if pits contains the special tag it removes a life
                    }
                    
                   // if(hits.Count == 1)//if you click on nothing you will lose a life
                   // {
                   //     lifeCount--;
                   //     ui_manager.UpdateLife(lifeCount);
                   // }
                   
                }
               
            }
        }else if (currentAmmo == 0)//if we are out of ammo player cant shoot
        {
            this.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //sends out a ray from the camera to the mouse position

            List<RaycastHit2D> hitting = new List<RaycastHit2D>();// make a list containing what the ray contacts with

            if (Physics2D.Raycast(ray.origin, ray.direction, new ContactFilter2D(), hitting) > 0) //adds ray collisions to the list
            {
                specialAmmo--;
                ui_manager.UpdateSpecial(specialAmmo);

                for (int i = 0; i < hitting.Count; i++)
                {
                    RaycastHit2D pits = hitting[i];   //makes the value from the hit list into a Raycast value via pits
                    if (pits.collider.gameObject.tag == ("Special"))
                    {
                        Destroy(pits.collider.gameObject);  //if pits contains the Special tag it destroys the Enemy Object
                    }
                    else if(pits.collider.gameObject.tag == ("Enemy"))// if pits contains the enemy tag it removes a life
                    {
                        lifeCount--;
                        ui_manager.UpdateLife(lifeCount);
                    }
                   // if (hitting.Count == 1) //if you click on nothing you will lose a life
                   // {
                   //     lifeCount--;
                   //     ui_manager.UpdateLife(lifeCount);
                   // }

                }
            }

        }else if(currentSpecialAmmo == 0)
        {
            this.gameObject.SetActive(false);
        }
        
        


    }
}

