
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _ammoText;//need to set the text for the ammo

   

   public float currentTime = 60f; //starting time
    [SerializeField]
    private TMP_Text _timeText;//time

    [SerializeField]
    GameObject gameOver; //game over screen

    [SerializeField]
    private TMP_Text _comboCounter;

    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private TMP_Text _ScoreTXT;


    public GameObject objectiveMenu;

    public GameObject Spawner;
    public GameObject pauseMenu;

    public GameObject Tutorial;

    private bool menuOpen;
    private bool pauseOpen;

    [SerializeField] private AudioClip[] UISounds;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource audioSource3;

    private Aim aim;

    public int endScore;


    

    private void Start()
    {
       audioSource1 = GetComponent<AudioSource>();
       audioSource2 = GetComponent<AudioSource>();
       audioSource3 = GetComponent<AudioSource>();

        aim = GameObject.Find("Crosshair").GetComponent<Aim>();

        menuOpen = false;
        pauseOpen = false;

        
        audioSource3.PlayOneShot(UISounds[2]);
        audioSource3.volume = 0.067f;
        audioSource3.Play();

        Tutorial.gameObject.SetActive(true);

      

      


    }

    public void UpdateAmmo (int count)//updates the ammo counter takes in the int amount of the ammo
    {
        
        _ammoText.text = "Ammo:" + count;//updates the count of the ammo
       
       
    }



   

    public void UpdateTime(float secondsDisplay)
    {
        float seconds = Mathf.FloorToInt(secondsDisplay % 999); //places time in the correct format
        _timeText.text = "Time:" + seconds;
    }

    public void UpdateCombo(int combo)
    {
        _comboCounter.text = "Combo:" + combo;
    }

    public void UpdateScore(int score)
    {
       _scoreText.text = "Score: " + score;
    }

    public void UpdateEndScore(int score)
    {
        _ScoreTXT.text = _scoreText.text;
    }

    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.T))
        {
            Tutorial.gameObject.SetActive(false);
        }


        if (currentTime > 0)
        {
            Time.timeScale = 1;
            currentTime -= Time.deltaTime; //time counts down in seconds
        }
        else
        {
            currentTime = 0f;
           
        }
        UpdateTime(currentTime);

        if (currentTime <= 0)//if time reaches 0 then game over
        {
            endScore = aim.CurrentScore;
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
            UpdateEndScore(endScore);
            UnityEngine.Cursor.visible = true;
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Q) && menuOpen == true)
        {
            audioSource2.clip = UISounds[1];
            audioSource2.Play();

            objectiveMenu.SetActive(false);

            menuOpen = false;
        }

        else if(Input.GetKeyDown(KeyCode.Q) && menuOpen == false)
        {
            audioSource2.clip = UISounds[1];
            audioSource2.Play();

            objectiveMenu.SetActive(true);

            menuOpen = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && pauseOpen == true) 
        {
            audioSource1.clip = UISounds[0];
            audioSource1.Play();
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            pauseOpen = false;
            UnityEngine.Cursor.visible = false;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pauseOpen == false)
        {
            audioSource1.clip = UISounds[0];
            audioSource1.Play();
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            pauseOpen = true;
            UnityEngine.Cursor.visible = true;
        }

    }

  

}

