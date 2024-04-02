
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;//need to set the text for the ammo

    [SerializeField]
    private Text _lifeText;//lives

   public float currentTime = 60f; //starting time
    [SerializeField]
    private Text _timeText;//time

    [SerializeField]
    GameObject gameOver; //game over screen

    [SerializeField]
    private Text _comboCounter;

    public GameObject objectiveMenu;

    public GameObject Spawner;
    public GameObject pauseMenu;

    private bool menuOpen;
    private bool pauseOpen;

    [SerializeField] private AudioClip[] UISounds;
    private AudioSource audioSource;
    

    private void Start()
    {
       audioSource = GetComponent<AudioSource>();
        menuOpen = false;
        pauseOpen = false;
    }

    public void UpdateAmmo (int count)//updates the ammo counter takes in the int amount of the ammo
    {
        _ammoText.text = "Ammo:" + count;//updates the count of the ammo
    }


    public void UpdateLife(int lives)
    {
        _lifeText.text = "Lives:" + lives;
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

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; //time counts down in seconds
        }
        else
        {
            currentTime = 0f;
        }
        UpdateTime(currentTime);

        if (currentTime == 0)//if time reaches 0 then game over
        {
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q) && menuOpen == true)
        {
            audioSource.clip = UISounds[1];
            audioSource.Play();

            objectiveMenu.SetActive(false);

            menuOpen = false;
        }

        else if(Input.GetKeyDown(KeyCode.Q) && menuOpen == false)
        {
            audioSource.clip = UISounds[1];
            audioSource.Play();

            objectiveMenu.SetActive(true);

            menuOpen = true;
        }

        if(Input.GetKeyDown(KeyCode.P) && pauseOpen == true) 
        {
            audioSource.clip = UISounds[0];
            audioSource.Play();
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            pauseOpen = false;       
        }

        else if (Input.GetKeyDown(KeyCode.P) && pauseOpen == false)
        {
            audioSource.clip = UISounds[0];
            audioSource.Play();
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            pauseOpen = true;
        }

    }

   

}
