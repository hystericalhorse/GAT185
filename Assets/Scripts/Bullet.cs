using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
