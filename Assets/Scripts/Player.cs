using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    public Joystick_Controller j_Controller;
    public float moveSpeed;

    Vector3 moveVelocity;

    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Get input
        moveVelocity = new Vector3(Joystick_Controller.Horizontal, _rb.velocity.y, Joystick_Controller.Vertical);

        // movement
        Vector3 moveInput = new Vector3(moveVelocity.x, _rb.velocity.y, moveVelocity.z);
        Vector3 moveDir = moveInput.normalized * moveSpeed;
        _rb.MovePosition(_rb.position + moveDir * Time.deltaTime);

        // rotate Player
        Vector3 lookAtPoint = transform.position + moveInput;
        transform.LookAt(lookAtPoint);
    }
}
