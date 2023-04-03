using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1_Projectile : MonoBehaviour
{
    public float speed;
    public Skill_1_Spawner spawner;

    public float h,
                 v;

    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        spawner = GameObject.Find("Skill 1 Spawner").GetComponent<Skill_1_Spawner>();
    }
    void Start()
    {
        _rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        h = transform.position.x;
        v = transform.position.z;

        spawner.h = h;
        spawner.v = v;
        Object.Destroy(gameObject, 2);
    }
}
