using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Rigidbody _rb;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        _rb.velocity = transform.forward * speed;
        Destroy(gameObject, 3);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
