
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

    public GameObject Background;
    public GameObject CloseButton;

    public GameObject Spawner;

    private bool menuOpen;
    

    private void Start()
    {
        menuOpen = true;
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
            CloseButton.SetActive(false);
            Background.SetActive(false);

            menuOpen = false;
        }

        else if(Input.GetKeyDown(KeyCode.Q) && menuOpen == false)
        {
            CloseButton.SetActive(true);
            Background.SetActive(true);

            menuOpen = true;
        }
   
    }

   

}
