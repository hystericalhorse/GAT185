using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 20;
    public float rotation_rate = 20;
    public GameObject explosion;

    bool shutdown = false;

    Vector3 direction;
    Vector3 rotation;

    private void OnApplicationQuit()
    {
        shutdown = true;
    }

    private void OnDestroy()
    {
        if (!shutdown) Instantiate(explosion, transform.position, transform.rotation);
    }

    void Start()
    {
        direction = Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), Vector3.up) * Vector3.forward;
        rotation = new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1));
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = transform.rotation * Quaternion.Euler(rotation * rotation_rate * Time.deltaTime);
    }
}
