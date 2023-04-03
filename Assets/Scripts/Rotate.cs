using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //Get rotation for movement joystick indicator

    public Joystick_Controller j_Controller;
    public bool flipRot = true;

    void Update()
    {
        float horizontal = Joystick_Controller.Horizontal;
        float vertical = Joystick_Controller.Vertical;

        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        angle = flipRot ? -angle : angle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
