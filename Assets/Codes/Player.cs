using UnityEngine;

public class Player : MonoBehaviour
{
    private float movespeed;
    private float X_Step;
    private float Y_Step;
    private float movement_speed;
    public GameObject PlayerSprite;

    void Start()
    {
        X_Step = 0f;
        Y_Step = 1.3f;
    }

    void Update()
    {
        // Move the player horizontally based on the movespeed
        transform.Translate(movespeed, 0, 0);

        // Clamp the player's position within certain bounds
        float clampedX = Mathf.Clamp(transform.position.x, -5f, 5f);
        float clampedY = Mathf.Clamp(transform.position.y, -5f, 5f);

        // Update the player's position after clamping
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void goUp()
    {
        Y_Step = Y_Step + 1f;
    }

    public void goDown()
    {
        Y_Step = Y_Step - 1f;
    }

    public void goRight()
    {
        X_Step = X_Step + 3f;
    }

    public void goLeft()
    {
        X_Step = X_Step - 3f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LeftWave")
        {
            movespeed = -0.004f;
            PlayerSprite.transform.position = new Vector2(X_Step, Y_Step);
        }

        if (collision.tag == "RightWave")
        {
            movespeed = 0.004f;
            PlayerSprite.transform.position = new Vector2(X_Step, Y_Step);
        }
    }
}
