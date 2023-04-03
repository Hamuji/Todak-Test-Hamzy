using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1_Indicator : MonoBehaviour
{
    public Skill_1_Joystick j_Controller;
    public bool flipRot = true;

    void Update()
    {
        float horizontal = Skill_1_Joystick.Horizontal;
        float vertical = Skill_1_Joystick.Vertical;

        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        angle = flipRot ? -angle : angle;
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, angle));
    }
}
