using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2_Move : MonoBehaviour
{
    public float speed,
                 h,
                 v;

    public Skill_2_Joystick s2_Joystick;
    public Skill_2_Spawn s2_Spawn;

    void Awake()
    {
        s2_Spawn = GameObject.Find("Skill 2 Spawn").GetComponent<Skill_2_Spawn>();
    }

    void Update()
    {
        float x = Skill_2_Joystick.Horizontal;
        float z = Skill_2_Joystick.Vertical;
        transform.localPosition = new Vector3(x, 0, z) * speed;

        h = transform.position.x;
        v = transform.position.z;

        s2_Spawn.h = h;
        s2_Spawn.v = v;
    }
}
