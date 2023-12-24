using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Interface;
    public GameObject Roster;
    public GameObject Settings;
    public GameObject Tutorial;
    public AudioClip test;
    public AudioClip Click;
    public AudioClip Back;
    public AudioClip Reset;
    public AudioSource Music;
    public AudioSource SFX;
    private int progress1;
    private int progress2;
    private int progress3;
    private int progress4;
    private int progress5;
    private int progress6;
    private int progress7;
    private int progress8;
    private int progress9;
    private int progress10;
    // Start is called before the first frame update
    void Start()
    {
        Interface.SetActive(true);
        Roster.SetActive(false);
        Settings.SetActive(false);
        Tutorial.SetActive(false);
        progress1 = PlayerPrefs.GetInt("Progress1", progress1);
        progress2 = PlayerPrefs.GetInt("Progress2", progress2);
        progress3 = PlayerPrefs.GetInt("Progress3", progress3);
        progress4 = PlayerPrefs.GetInt("Progress4", progress4);
        progress5 = PlayerPrefs.GetInt("Progress5", progress5);
        progress6 = PlayerPrefs.GetInt("Progress6", progress6);
        progress7 = PlayerPrefs.GetInt("Progress7", progress7);
        progress8 = PlayerPrefs.GetInt("Progress8", progress8);
        progress9 = PlayerPrefs.GetInt("Progress9", progress9);
        progress10 = PlayerPrefs.GetInt("Progress10", progress10);
    }

    // Update is called once per frame
    void Update()
    {
        progress1 = PlayerPrefs.GetInt("Progress1", progress1);
        progress2 = PlayerPrefs.GetInt("Progress2", progress2);
        progress3 = PlayerPrefs.GetInt("Progress3", progress3);
        progress4 = PlayerPrefs.GetInt("Progress4", progress4);
        progress5 = PlayerPrefs.GetInt("Progress5", progress5);
        progress6 = PlayerPrefs.GetInt("Progress6", progress6);
        progress7 = PlayerPrefs.GetInt("Progress7", progress7);
        progress8 = PlayerPrefs.GetInt("Progress8", progress8);
        progress9 = PlayerPrefs.GetInt("Progress9", progress9);
        progress10 = PlayerPrefs.GetInt("Progress10", progress10);
    }
    public void SoundTest()
    {
        SFX.PlayOneShot(test);
    }
    public void OpenPanel(GameObject panel)
    {
        SFX.PlayOneShot(Click);
        Interface.SetActive(false);
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject closer)
    {
        SFX.PlayOneShot(Back);
        closer.SetActive(false);
        Interface.SetActive(true);
    }
    public void Reset_Data()
    {
        SFX.PlayOneShot(Reset);
        progress1 = 0;
        progress2 = 0;
        progress3 = 0;
        progress4 = 0;
        progress5 = 0;
        progress6 = 0;
        progress7 = 0;
        progress8 = 0;
        progress9 = 0;
        progress10 = 0;
        PlayerPrefs.SetInt("Progress1", progress1);
        PlayerPrefs.SetInt("Progress2", progress2);
        PlayerPrefs.SetInt("Progress3", progress3);
        PlayerPrefs.SetInt("Progress4", progress4);
        PlayerPrefs.SetInt("Progress5", progress5);
        PlayerPrefs.SetInt("Progress6", progress6);
        PlayerPrefs.SetInt("Progress7", progress7);
        PlayerPrefs.SetInt("Progress8", progress8);
        PlayerPrefs.SetInt("Progress9", progress9);
        PlayerPrefs.SetInt("Progress10", progress10);
    }
}
