using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private float moveSpeed;
    private float vanishX;

    public void SetMoveSpeed(float speed, float vanishPosition)
    {
        moveSpeed = speed;
        vanishX = vanishPosition;
    }

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

        // Перевірка на досягнення точки зникнення
        if (transform.position.x == vanishX)
        {
            gameObject.SetActive(false);
        }
    }
}

