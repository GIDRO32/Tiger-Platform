using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetField : MonoBehaviour
{
    private int A_ball;
    private int B_ball;
    public int Magnet_Count;
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
        Magnets_Left.text = Magnet_Count.ToString();
        magneticField.SetActive(false); // Забезпечуємо, що на початку гри магнітне поле вимкнене
        A_ball = 0;
        B_ball = 0;
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
        PlayerPrefs.SetInt("A balls collected", A_ball);
        PlayerPrefs.SetInt("B balls collected", B_ball);
        magneticField.SetActive(false);
        isMagnetActive = false;
        A_ball = 0;
        B_ball = 0;
        MagnetSound.PlayOneShot(Disable);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MustGrab"))
        {
            other.gameObject.SetActive(false);
            A_ball++;
            MagnetSound.PlayOneShot(PickUp);
        }
        if (other.CompareTag("MustGrab2"))
        {
            other.gameObject.SetActive(false);
            B_ball++;
            MagnetSound.PlayOneShot(PickUp);
        }
    }
}
