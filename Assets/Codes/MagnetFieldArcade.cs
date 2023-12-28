using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetFieldArcade : MonoBehaviour
{
    private int Coin;
    private int Magnet_Count;
    public Text Magnets_Left;
    public GameObject magneticField; // Посилання на об'єкт магнітного поля
    public GameObject Shield;
    private bool isMagnetActive = false; // Прапорець, який вказує, чи активоване магнітне поле
    public AudioSource MagnetSound;
    public AudioClip Use;
    public AudioClip Cannot;
    public AudioClip Disable;
    public AudioClip PickUp;

    void Start()
    {
        Magnet_Count = PlayerPrefs.GetInt("Total Magnets", Magnet_Count);
        Magnets_Left.text = Magnet_Count.ToString();
        magneticField.SetActive(false); // Забезпечуємо, що на початку гри магнітне поле вимкнене
        Coin = 0;
    }
    void Update()
    {
        Magnets_Left.text = Magnet_Count.ToString();
    }

    // Функція для активації магнітного поля
    public void ActivateMagnetField()
    {
        if (!isMagnetActive && Magnet_Count > 0 && !Shield.activeSelf)
        {
            // Активуємо магнітне поле
            magneticField.SetActive(true);
            isMagnetActive = true;

            // Запускаємо таймер на 5 секунд для вимкнення магнітного поля
            Invoke("DeactivateMagnetField", 5f);
            MagnetSound.PlayOneShot(Use);
            Magnet_Count--;
        }
        else
        {
            MagnetSound.PlayOneShot(Cannot);
        }
    }
    private void DeactivateMagnetField()
    {
        PlayerPrefs.SetInt("A balls collected", Coin);
        magneticField.SetActive(false);
        isMagnetActive = false;
        Coin = 0;
        MagnetSound.PlayOneShot(Disable);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MustGrab"))
        {
            other.gameObject.SetActive(false);
            Coin++;
            MagnetSound.PlayOneShot(PickUp);
        }
    }
}
