using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    float speed = 0.0f;
    [Range(0, 500), Tooltip("Max Player Speed")] public float max_speed = 0.0f;
    [Range(0, 360), Tooltip("Rotation Speed")] public float rot_speed = 180.0f;

    public Transform bullet_origin;
	public GameObject prefab;

    float pitch = 0f;
    float yaw = 0f;
    float roll = 0f;

    float _pitch = 0f;
    float _yaw = 0f;
    float _roll = 0f;

    float max_roll = 45f;
    float roll_factor = 20f;

    void Awake()
	{

	}

	void Start()
    {

    }

    void Update()
    {
        

        speed += Input.GetAxis("Vertical");

        //speed = Mathf.Clamp(speed, -max_speed / 2, max_speed);
        speed = Mathf.Clamp(speed, 0, max_speed);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(prefab, bullet_origin.position, bullet_origin.rotation);
        }

        if (Input.GetKey(KeyCode.LeftShift)) speed *= 2f;

        //var roll = Mathf.Clamp(rotation.y * roll_factor, -max_roll, max_roll);

        //Quaternion tilt = Quaternion.Euler(0, transform.rotation.y, -roll);
        //transform.rotation = tilt;

        //Quaternion rotate = Quaternion.Euler(rotation * rot_speed * Time.deltaTime);
        //transform.rotation *= rotate;

        
        pitch = Input.GetAxis("Q/E");
        //pitch = Input.GetAxis("Mouse Y");

        yaw = Input.GetAxis("Horizontal");
        //yaw = Input.GetAxis("Mouse X");
        roll = Mathf.Clamp(-yaw * roll_factor, -max_roll, max_roll);

        pitch *= rot_speed * Time.deltaTime;
        _pitch += pitch;

        if (Input.GetKey(KeyCode.C))
        {

        }

        yaw *= rot_speed * Time.deltaTime;
        _yaw += yaw;

        //roll *= rot_speed * Time.deltaTime;
        _roll += roll;

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, roll);
        transform.rotation = rotation;

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

    }
}
