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
    public GameObject Shop;
    public GameObject NotEnough;
    public AudioClip test;
    public AudioClip Click;
    public AudioClip Back;
    public AudioClip Reset;
    public AudioClip Buy;
    public AudioClip CantBuy;
    public AudioSource Music;
    public AudioSource SFX;
    public Text coin_UI;
    public Text Shield_Have;
    public Text Shield_Cost;
    public Text Magnet_Have;
    public Text Magnet_Cost;
    private int balance;
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
    private int Shield_Price = 15;
    private int Magnet_Price = 30;
    private int Shield_Num = 3;
    private int Magnet_Num = 1;
    // Start is called before the first frame update
    void Start()
    {
        Interface.SetActive(true);
        Roster.SetActive(false);
        Settings.SetActive(false);
        Tutorial.SetActive(false);
        Shop.SetActive(false);
        NotEnough.SetActive(false);
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
        balance = PlayerPrefs.GetInt("Earnings");
        Magnet_Num = PlayerPrefs.GetInt("Total Magnets", Magnet_Num);
        Magnet_Price = PlayerPrefs.GetInt("Magnet Price", Magnet_Price);
        Shield_Num = PlayerPrefs.GetInt("Total Shields", Shield_Num);
        Shield_Price = PlayerPrefs.GetInt("Shield Price", Shield_Price);
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
        coin_UI.text = balance.ToString();
        Shield_Have.text = "You have:" + Shield_Num.ToString();
        Shield_Cost.text = Shield_Price.ToString();
        Magnet_Cost.text = Magnet_Price.ToString();
        Magnet_Have.text = "You have:" + Magnet_Num.ToString();

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
    public void ClosePopup(GameObject popup)
    {
        SFX.PlayOneShot(Back);
        popup.SetActive(false);
    }
    public void buyShield()
    {
        if(balance >= Shield_Price)
        {
            balance = balance - Shield_Price;
            Shield_Price += 10;
            Shield_Num++;
            SFX.PlayOneShot(Buy);
            PlayerPrefs.SetInt("Shield Price", Shield_Price);
            PlayerPrefs.SetInt("Total Shields", Shield_Num);
        }
        else
        {
            NotEnough.SetActive(true);
            SFX.PlayOneShot(CantBuy);
        }
    }
    public void buyMagnet()
    {
        if(balance >= Magnet_Price)
        {
            balance = balance - Magnet_Price;
            Magnet_Price += 20;
            Magnet_Num++;
            SFX.PlayOneShot(Buy);
            PlayerPrefs.SetInt("Magnet Price", Magnet_Price);
            PlayerPrefs.SetInt("Total Magnets", Magnet_Num);
        }
        else
        {
            NotEnough.SetActive(true);
            SFX.PlayOneShot(CantBuy);
        }
    }
    public void Reset_Data()
    {
        SFX.PlayOneShot(Reset);
        balance = 0;
        Shield_Price = 15;
        Magnet_Price = 30;
        Shield_Num = 3;
        Magnet_Num = 1;
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
        PlayerPrefs.SetInt("Earnings", balance);
        PlayerPrefs.SetInt("Total Magnets", Magnet_Num);
        PlayerPrefs.SetInt("Magnet Price", Magnet_Price);
        PlayerPrefs.SetInt("Total Shields", Shield_Num);
        PlayerPrefs.SetInt("Shield Price", Shield_Price);
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
