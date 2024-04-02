
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering; 


public class Aim : MonoBehaviour
{

    private int maxAmmo = 6;//maximum ammo allows
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

    private int comboCounter;

    private Animator enemyAnimator;

    [SerializeField] private AudioClip[] crossHairSounds;
    private AudioSource audioSource;

   



    private void Start()
    {
        UnityEngine.Cursor.visible = false; // makes mouse cursor invisible. For some reason you need to click for it to work

        currentAmmo = maxAmmo;
        currentSpecialAmmo = specialAmmo;
        currentLife = lifeCount;

        StartPos = AimPos.position;

        ui_manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();//needs to find the canvas object in the UI component
       // enemyAnimator = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = crossHairSounds[2];
        audioSource.Play();
 

        comboCounter = 0;



    }



    private void Update()
    {
        
        Vector2 mousePosition = Input.mousePosition; //provides a value for the mouse position in pixels
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //translates mouse pixel position into co-ordinates relative to the scene
        Vector2 position = new Vector2(mousePosition.x, mousePosition.y); //crosshair can track the mouse
        transform.localPosition = position; // crosshair follows mouse

        if (Input.mousePosition.x >= Screen.width || Input.mousePosition.x <= Screen.width)
        {
            Cam.transform.position = new Vector3(transform.position.x, 0, -10) * CamSpeed;
        }

        if (lifeCount == 0)
        {
            this.gameObject.SetActive(false);
        }

        if(comboCounter == 5)
        {
            currentAmmo += 6;
            ui_manager.UpdateAmmo(currentAmmo);
            comboCounter = 0;
            ui_manager.UpdateCombo(comboCounter);
        }

        if(currentAmmo >= maxAmmo)
        {
            currentAmmo = 6;
            ui_manager.UpdateAmmo(currentAmmo);
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
                        // enemyAnimator.SetBool("IsDead", true);
                        // StartCoroutine(AnimationDelay());

                        audioSource.clip = crossHairSounds[0];
                        audioSource.Play();

                        Destroy(pit.collider.gameObject);  //if pits contains the Enemy tag it destroys the Enemy Object
                        comboCounter++;
                        ui_manager.UpdateCombo(comboCounter);
                    }
                    else if(pit.collider.gameObject.tag == ("Special"))
                    {
                        lifeCount--;
                        ui_manager.UpdateLife(lifeCount);//if pits contains the special tag it removes a life
                    }

                    else if(hits.Count == 1)
                    {
                        comboCounter = 0;
                        ui_manager.UpdateCombo(comboCounter);
                        
                    }
                }
               
            }
        }else if (currentAmmo == 0)//if we are out of ammo player cant shoot
        {
            this.gameObject.SetActive(false);
        }

        
    }

 //IEnumerator AnimationDelay()
 //   {
 //       yield return new WaitForSeconds(1f);
 //   }
   
}


