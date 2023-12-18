using UnityEngine;

public class PlayerWave : MonoBehaviour
{
    private float movespeed;
    private float X_Step;
    private float Y_Step;
    public GameObject PlayerSprite;

    void Start()
    {
        X_Step = 0f;
        Y_Step = 1.3f;
    }

    void Update()
    {
        transform.position = new Vector3(X_Step, Y_Step, transform.position.z);
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
        X_Step = X_Step + 1f;
    }

    public void goLeft()
    {
        X_Step = X_Step - 1f;
    }
}
