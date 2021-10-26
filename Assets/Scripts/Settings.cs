using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{

    GameObject mainMenu;
    GameObject settings;

    public AudioMixer audioMixer;

    private void Start()
    {
        mainMenu = GameObject.FindGameObjectsWithTag("MainMenu")[1];
        settings = GameObject.FindGameObjectsWithTag("MainMenu")[0];
        settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void SwitchToMainMenu()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
