
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerController : MonoBehaviour
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
    public AudioClip YouClear;
    public AudioClip test;
    private bool isOnRightWave = false;
    private bool isOnLeftWave = false;
    private bool isPlayingYouClear = false;
    private bool magnetOn = false;
    private float movespeed = 3f; // швидкість руху гравця
    private float step = 0.75f; // відстань між течіями
    private int health = 3;
    private int max_health = 3;
    private int progress = 0;
    public GameObject ballA;
    public GameObject ballB;
    public GameObject ExtraShow;
    public GameObject boundary;
    public GameObject Shield;
    public GameObject Magnet;
    public GameObject ClearPanel;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject LevelCheck;
    public GameObject HealthCheck;
    public GameObject BallsCheck;
    public GameObject PausePanel;
    public GameObject HomePanel;
    public GameObject GameOver;
    public GameObject Interface;
    public GameObject Starter;
    public Slider ticker;
    public Slider Volume;
    public Slider SFX;
    private bool isOnBrokenPlatform = false;
    private bool FullHealth;
    private bool NoExtras;
    private bool HasStarted = false;
    private float breakTimer = 3f;
    public int ballsA_needed = 10;
    public int ballsB_needed = 0;
    private int A_Collected;
    private int B_Collected;
    private int ExtraBalls = 0;
    private int Stars = 0;
    public int Shield_Count;
    private float line_speed = 4f;
    private float distance = 0.7f;
    private float start_delay = 3f;
    private string Rank;
    public string LevelTag;
    public string Progress_Tag;
    public string RetryTag;
    public Text ballsA;
    public Text ballsB;
    public Text health_bar;
    public Text Extra;
    public Text Result;
    public Text Shields_Left;

    void Start()
    {
        FullHealth = true;
        NoExtras = true;
        ticker.gameObject.SetActive(false);
        Shield.SetActive(false);
        ClearPanel.SetActive(false);
        GameOver.SetActive(false);
        PausePanel.SetActive(false);
        HomePanel.SetActive(false);
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
        LevelCheck.SetActive(false);
        HealthCheck.SetActive(true);
        BallsCheck.SetActive(true);
        Starter.SetActive(true);
        Time.timeScale = 1f;
        Interface.SetActive(false);
        StartCoroutine(GetReady());
    }
    // Update is called once per frame
    void Update()
    {
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
        ballsA.text = ballsA_needed.ToString();
        ballsB.text = ballsB_needed.ToString();
        Extra.text = ExtraBalls.ToString();
        health_bar.text = health.ToString();
        PlayerPrefs.SetFloat("Line Speed", line_speed);
        PlayerPrefs.SetFloat("Line Distance", distance);
        if (isOnBrokenPlatform)
        {
            breakTimer -= Time.deltaTime;
            ticker.value = breakTimer / 3f;

            if (breakTimer <= 0f)
            {
                GameOver.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if(ballsA_needed == 0 && ballsB_needed == 0)
        {
            Interface.SetActive(false);
            LevelCheck.SetActive(true);
            ClearPanel.SetActive(true);
            LevelClear(Stars, Rank);
            progress = 1;
            PlayerPrefs.SetInt(Progress_Tag, progress);
            Time.timeScale = 0f;
        }
        if(health < max_health)
        {
            FullHealth = false;
            HealthCheck.SetActive(false);
        }
        if(health == 0)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
        if(Magnet.activeSelf)
        {
            magnetOn = true;
        }
        else if(!Magnet.activeSelf && magnetOn)
        {
            A_Collected = PlayerPrefs.GetInt("A balls collected", A_Collected);
            B_Collected = PlayerPrefs.GetInt("B balls collected", B_Collected);
            ballsA_needed = ballsA_needed - A_Collected;
            ballsB_needed = ballsB_needed - B_Collected;
            magnetOn = false;
        }
        if(ballsA_needed < 0)
        {
            ballsA_needed = -ballsA_needed + ballsA_needed;
        }
        if(ballsB_needed < 0)
        {
            ballsB_needed = -ballsB_needed + ballsB_needed;
        }
        if(ExtraBalls == 0)
        {
            ExtraShow.SetActive(false);
        }
        else
        {
            BallsCheck.SetActive(false);
            NoExtras = false;
            ExtraShow.SetActive(true);
        }
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
    void LevelClear(int starship, string Ranking)
    {
        if(!NoExtras && !FullHealth)
        {
            Star1.SetActive(true);
            starship = 1;
            Ranking = "Level Clear";
            Result.text = Ranking;
        }
        else if(!NoExtras || !FullHealth)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            starship = 2;
            Ranking = "Great Job!";
            Result.text = Ranking;
        }
        else
        {
            Star1.SetActive(true);
            Star2.SetActive(true);   
            Star3.SetActive(true);
            starship = 3;
            Ranking = "PERFECT!";
            Result.text = Ranking;
        }
        Stars = starship;
        PlayerPrefs.SetInt(LevelTag, Stars);
if (!isPlayingYouClear)
    {
        if (YouClear != null)
        {
            isPlayingYouClear = true;
            Sounds.PlayOneShot(YouClear);
        }
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
        if (other.CompareTag("MustGrab") && ballsA_needed > 0 && HasStarted)
        {
            Sounds.PlayOneShot(PickUp);
            other.gameObject.SetActive(false);
            ballsA_needed--;
        }
        if (other.CompareTag("MustGrab2") && ballsB_needed > 0 && HasStarted)
        {
            Sounds.PlayOneShot(PickUp);
            other.gameObject.SetActive(false);
            ballsB_needed--;
        }
        if (other.CompareTag("Extra") && HasStarted)
        {
            Sounds.PlayOneShot(PickUp);
            other.gameObject.SetActive(false);
            ExtraBalls++;
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
