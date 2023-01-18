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
    [Range(0, 360), Tooltip("Yaw Speed")] public float yaw_speed = 180.0f;
    [Range(0, 360), Tooltip("Pitch Speed")] public float pitch_speed = 90.0f;

    public Transform bullet_origin;
	public GameObject prefab;

    float pitch = 0f;
    float yaw = 0f;
    float roll = 0f;

    public float _pitch = 0f;
    public float _yaw = 0f;
    public float _roll = 0f;

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
        if (yaw != 0)
        {
            //yaw = ((yaw > 0) ? -transform.right : transform.right).normalized;
        }

        //yaw = Input.GetAxis("Mouse X");
        roll = Mathf.Clamp(-yaw * roll_factor, -max_roll, max_roll);

        pitch *= pitch_speed * Time.deltaTime;
        _pitch += pitch;

        _pitch = _pitch % 360;

        if (Input.GetKey(KeyCode.C))
        {
            _pitch = 0;
            Vector3 v = new Vector3(transform.position.x, 0, transform.position.z);
            transform.position = v;
        }

        yaw *= yaw_speed * Time.deltaTime;
        //_yaw -= yaw;
        _yaw += (_pitch <= 90 || _pitch >= 270) ? yaw : -yaw;
        //_yaw += (_pitch >= 180 && _pitch >= -180) ? yaw : -yaw;

        //roll *= rot_speed * Time.deltaTime;
        _roll += roll;
        _roll = _roll % 360;

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, roll);
        transform.rotation = rotation;

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

    }
}
