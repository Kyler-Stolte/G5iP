using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    // Start is called before the first frame update


    public string[] Names;
    public string[] Description;
    private int tally;
    private UI_Manager manager;
    public GameObject objectiveMenu;
    private bool menuOpen;
    void Start()
    {
        manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && menuOpen == true)
        { 

            objectiveMenu.SetActive(false);

            menuOpen = false;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && menuOpen == false)
        {
        

            objectiveMenu.SetActive(true);

            menuOpen = true;
        }
    }
}
