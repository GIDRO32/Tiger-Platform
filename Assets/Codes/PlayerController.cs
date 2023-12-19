
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool isOnRightWave = false;
    private bool isOnLeftWave = false;
    private float movespeed = 3f; // швидкість руху гравця
    private float step = 0.75f; // відстань між течіями
    public GameObject ball;
    public GameObject boundary;
    private int balls_needed = 10;
    private float line_speed = 4f;
    public Text balls;

    // Update is called once per frame
    void Update()
    {
        // Рух гравця по течіям
        if (isOnRightWave)
        {
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }
        else if (isOnLeftWave)
        {
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }
        balls.text = balls_needed.ToString();
        PlayerPrefs.SetFloat("Line Speed", line_speed);
    }

    // Функція для кнопки "Вгору"
    public void GoUp()
    {
        transform.Translate(Vector3.up * step);
        isOnRightWave = false;
        isOnLeftWave = false;
    }

    // Функція для кнопки "Вниз"
    public void GoDown()
    {
        transform.Translate(Vector3.down * step);
        isOnRightWave = false;
        isOnLeftWave = false;
    }
    public void GoRight()
    {
        transform.Translate(Vector3.right * step);
    }
    public void GoLeft()
    {
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

    // Обробка входу в триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RightWave"))
        {
            isOnRightWave = true;
            isOnLeftWave = false;
        }
        else if (other.CompareTag("LeftWave"))
        {
            isOnLeftWave = true;
            isOnRightWave = false;
        }
        if (other.CompareTag("MustGrab"))
        {
            other.gameObject.SetActive(false);
            balls_needed--;
        }
        if (other.CompareTag("Bomb"))
        {
            Time.timeScale = 0f;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("RedPlatform"))
        {
            Debug.Log("On Red!");
            line_speed = line_speed + 0.2f;
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
            Time.timeScale = 0f;
        }
    }
}
