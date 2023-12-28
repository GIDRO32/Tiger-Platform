
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class ArcadePlayer : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource Sounds;
    public AudioClip PickUp;
    public AudioClip Move;
    public AudioClip ShieldOff;
    public AudioClip CantUse;
    public AudioClip UseShield;
    public AudioClip BombStep;
    public AudioClip IceStep;
    public AudioClip RedStep;
    public AudioClip Danger;
    public AudioClip Open;
    public AudioClip Close;
    public AudioClip test;
    private bool isOnRightWave = false;
    private bool isOnLeftWave = false;
    private bool isLost = false;
    private bool magnetOn = false;
    private float movespeed = 3f; // швидкість руху гравця
    private float step = 0.75f; // відстань між течіями
    private int health = 3;
    private int magnet_coins;
    private int coins_grabbed;
    private int total_coins;
    public GameObject boundary;
    public GameObject Shield;
    public GameObject Magnet;
    public GameObject PausePanel;
    public GameObject HomePanel;
    public GameObject GameOver;
    public GameObject Interface;
    public GameObject Starter;
    public GameObject Coin;
    public GameObject Heart;
    public Slider ticker;
    public Slider Volume;
    public Slider SFX;
    private bool isOnBrokenPlatform = false;
    private bool HasStarted = false;
    private float breakTimer = 3f;
    private int Shield_Count;
    private float line_speed = 4f;
    private float distance = 0.7f;
    private float start_delay = 3f;
    public string RetryTag;
    public Text health_bar;
    public Text Shields_Left;
    public Text coin_counter;

    void Start()
    {
        ticker.gameObject.SetActive(false);
        Shield.SetActive(false);
        GameOver.SetActive(false);
        PausePanel.SetActive(false);
        HomePanel.SetActive(false);
        Starter.SetActive(true);
        Time.timeScale = 1f;
        Interface.SetActive(false);
        StartCoroutine(GetReady());
        coins_grabbed = 0;
        total_coins = PlayerPrefs.GetInt("Earnings", total_coins);
        Shield_Count = PlayerPrefs.GetInt("Total Shields", Shield_Count);
    }
    // Update is called once per frame
    void Update()
    {
        coin_counter.text = coins_grabbed.ToString();
        Shields_Left.text = Shield_Count.ToString();
        // Рух гравця по течіям
        if (isOnRightWave)
        {
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }
        else if (isOnLeftWave)
        {
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }
        health_bar.text = health.ToString();
        PlayerPrefs.SetFloat("Line Speed", line_speed);
        PlayerPrefs.SetFloat("Line Distance", distance);
        if (isOnBrokenPlatform)
        {
            breakTimer -= Time.deltaTime;
            ticker.value = breakTimer / 3f;

            if (breakTimer <= 0f)
            {
                boundary.SetActive(false);
                GameOver.SetActive(true);
                Interface.SetActive(false);
                Time.timeScale = 0f;
            }
        }
        if(health == 0)
        {
            boundary.SetActive(false);
            Interface.SetActive(false);
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
        if(Magnet.activeSelf)
        {
            magnetOn = true;
        }
        else if(!Magnet.activeSelf && magnetOn)
        {
            magnet_coins = PlayerPrefs.GetInt("A balls collected", magnet_coins);
            coins_grabbed += magnet_coins;
            magnetOn = false;
        }
    }
    void LoseGame()
    {
        if(isLost)
        {
            total_coins = total_coins + coins_grabbed;
            PlayerPrefs.SetInt("Earnings", total_coins);
        }
        isLost = false;
    }
    IEnumerator GetReady()
    {
        yield return new WaitForSeconds(start_delay);
        HasStarted = true;
        Starter.SetActive(false);
        Interface.SetActive(true);
    }
    IEnumerator ResetBreakTimer()
    {
        ticker.value = 1f; // Скидання значення слайдера на максимум
        breakTimer = 3f;

        while (breakTimer > 0f)
        {
            yield return null;
        }
        ticker.gameObject.SetActive(false); // При вийшовши з циклу, ховаємо таймер
    }
    IEnumerator ShieldTime()
    {
        Shield.SetActive(true);
        yield return new WaitForSeconds(5f);
        Sounds.PlayOneShot(ShieldOff);
        Shield.SetActive(false);
    }
    public void ActivateShield()
    {
        if(!Shield.activeSelf && Shield_Count > 0 && !magnetOn)
        {
            Sounds.PlayOneShot(UseShield);
            StartCoroutine(ShieldTime());
            Shield_Count--;
        }
        else
        {
            Sounds.PlayOneShot(CantUse);
        }
    }
    public void ResetLevel()
    {
        Sounds.PlayOneShot(Open);
        SceneManager.LoadScene(RetryTag);
    }
    public void OpenPanel(GameObject panel)
    {
        Sounds.PlayOneShot(Open);
        Interface.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ClosePanel(GameObject closer)
    {
        Sounds.PlayOneShot(Close);
        closer.SetActive(false);
        Interface.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GoUp()
    {
        Sounds.PlayOneShot(Move);
        transform.Translate(Vector3.up * step);
    }
    public void GoDown()
    {
        Sounds.PlayOneShot(Move);
        transform.Translate(Vector3.down * step);
    }
    public void GoRight()
    {
        Sounds.PlayOneShot(Move);
        transform.Translate(Vector3.right * step);
    }
    public void GoLeft()
    {
        Sounds.PlayOneShot(Move);
        transform.Translate(Vector3.left * step);
    }

    private void SetMoveSpeed(float speed)
    {
        Platforms[] platforms = FindObjectsOfType<Platforms>();

        foreach (Platforms platform in platforms)
        {
            platform.SetMoveSpeed(speed, 8f); // Ваші значення для vanishX та speed
        }
    }
    public void SoundTest()
    {
        Sounds.PlayOneShot(test);
    }
    // Обробка входу в триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RightWave") && HasStarted)
        {
            isOnLeftWave = false;
            isOnRightWave = true;
        }
        else if (other.CompareTag("LeftWave") && HasStarted)
        {
            isOnLeftWave = true;
            isOnRightWave = false;
        }
        if (other.CompareTag("MustGrab") && HasStarted)
        {
            Sounds.PlayOneShot(PickUp);
            coins_grabbed++;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("MustGrab2") && HasStarted)
        {
            Sounds.PlayOneShot(PickUp);
            health++;
            other.gameObject.SetActive(false);
        }
if (!Shield.activeSelf) // Перевірка, чи щит неактивний
    {
        if (other.CompareTag("Bomb") && HasStarted)
        {
            Sounds.PlayOneShot(BombStep);
            health--;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("RedPlatform") && HasStarted)
        {
            Sounds.PlayOneShot(RedStep);
            line_speed = line_speed + 0.2f;
            movespeed = movespeed + 0.2f;
            distance = distance - 0.02f;
        }
        if (other.CompareTag("IcePlatform") && HasStarted)
        {
            int randomDirection = Random.Range(0, 1); // 0 або 1

            if (randomDirection == 0)
            {
                Sounds.PlayOneShot(IceStep);
            transform.Translate(Vector3.up * step);
            }
            else
            {
                Sounds.PlayOneShot(IceStep);
            transform.Translate(Vector3.down * step);
            }
        }
        if (other.CompareTag("BrokenPlatform") || other.CompareTag("Fire"))
        {
            Sounds.PlayOneShot(Danger);
            isOnBrokenPlatform = true;
            ticker.gameObject.SetActive(true);
            StartCoroutine(ResetBreakTimer());
        }
    }
    }

    // Обробка виходу з триггера
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RightWave") || other.CompareTag("LeftWave"))
        {
            isOnRightWave = false;
            isOnLeftWave = false;
        }
        if (other.gameObject == boundary)
        {
            total_coins = total_coins + coins_grabbed;
            PlayerPrefs.SetInt("Earnings", total_coins);
            Interface.SetActive(false);
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
        if (other.CompareTag("BrokenPlatform") || other.CompareTag("Fire"))
        {
            isOnBrokenPlatform = false;
            ticker.gameObject.SetActive(false);
        }
    }
}
