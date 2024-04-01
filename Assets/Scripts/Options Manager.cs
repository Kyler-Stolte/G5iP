using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Dropdown resDropdown;
    public Toggle fullScreenToggle;

    private int screenInt;
    private bool isFullScreen = false;

    Resolution[] resolutions;
    const string resName = "resolutionoption";
    
    private void Awake()
    {
        screenInt = PlayerPrefs.GetInt("toggle");
        if(screenInt == 1)
        {
            isFullScreen = true;
            fullScreenToggle.isOn = true;
        }
        else
        {
            fullScreenToggle.isOn=false;
        }
        resDropdown.onValueChanged.AddListener(new UnityAction<int>(indexer =>
        {
            PlayerPrefs.SetInt(resName, resDropdown.value);
            PlayerPrefs.Save();
        }));

    }

    private void Start()
    {
        // Gets all the avalible screen resolutions and refresh rate's and places them into the dropdown box to be selected
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        } 
        resDropdown.AddOptions(options);
        resDropdown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resDropdown.RefreshShownValue();
    }
    // Sets the resolution of the game to the selected one in the dropdown
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    // Sets screen to fullscreen when the toggle is active and windowed when toggle is inactive
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if (isFullScreen == false)
        {
            PlayerPrefs.SetInt("toggle", 0);
        }
        else
        {
            isFullScreen = true;
            PlayerPrefs.SetInt("toggle", 1);
        }
    }
}
