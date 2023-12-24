using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Посилання на об'єкт гравця
    public float smoothSpeed = 0.125f; // Плавність слідкування
    public Vector3 offset; // Зміщення камери

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // transform.LookAt(player); // Орієнтація камери на гравця
        }
    }
}
