using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private const string _lineRotationY = "Mouse Y";
    private const string _lineRotationX = "Mouse X";

    [SerializeField] private float _sensitivity = 2.0f; 
    [SerializeField] private float _speed = 5.0f; 
    [SerializeField] private float _jumpHeight = 1.0f; 
    [SerializeField] private float _gravity = -9.81f; 

    private float _rotationX = 0.0f;
    private Vector3 _velocity;
    private CharacterController _controller;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
    
        float mouseX = Input.GetAxis(_lineRotationX) * _sensitivity;
        float mouseY = Input.GetAxis(_lineRotationY) * _sensitivity;

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -45f, 45f);

        Camera.main.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        _controller.Move(move * _speed * Time.deltaTime);

  
        if (_controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
        }

    
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
