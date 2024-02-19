
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;//need to set the text for the ammo

    [SerializeField]
    private Text _special;//special ammo

    [SerializeField]
    private Text _lifeText;//lives

    float currentTime = 60f; //starting time
    [SerializeField]
    private Text _timeText;//time

    [SerializeField]
    GameObject gameOver; //game over screen
    public void UpdateAmmo (int count)//updates the ammo counter takes in the int amount of the ammo
    {
        _ammoText.text = "Ammo:" + count;//updates the count of the ammo
    }

    public void UpdateSpecial(int counts)
    {
        _special.text = "Special Ammo:" + counts;
    }

    public void UpdateLife(int lives)
    {
        _lifeText.text = "Lives:" + lives;
    }

    public void UpdateTime(float secondsDisplay)
    {
        float seconds = Mathf.FloorToInt(secondsDisplay % 60); //places time in the correct format
        _timeText.text = "Time:" + seconds;
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

        if(currentTime == 0)//if time reaches 0 then game over
        {
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
        }
    }

   
}
