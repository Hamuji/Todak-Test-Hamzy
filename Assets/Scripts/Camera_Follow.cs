using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform playerTarget;
    public Vector3 offset;

    void Update()
    {
        transform.position = playerTarget.position + offset;
    }
}
