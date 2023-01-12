using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    float centerX = Screen.width / 2;
    float centerY = Screen.height / 2;
    static Vector2 screenCenter;
    public Player player;

    static float weightX = 0.0f;
    static float weightY = 0.0f;

    void Start()
    {
        screenCenter = new Vector2(centerX, centerY);
    }

    void Update()
    {
        weightX = 0;
        weightY = 0;

        if (Input.mousePosition.x > centerX)
        {
            weightX = 1.0f;
        }

        if (Input.mousePosition.x < centerX)
        {
            weightX = -1.0f;
        }

        if (Input.mousePosition.y > centerY)
        {
            weightY = 1.0f;
        }

        if (Input.mousePosition.y < centerY)
        {
            weightY = -1.0f;
        }
    }
}
