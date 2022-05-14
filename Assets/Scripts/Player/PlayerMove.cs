using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] FixedJoystick _joystick;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction = Vector2.zero;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_joystick.Horizontal !=0 || _joystick.Vertical != 0)
        {
            _direction.x = _joystick.Horizontal * -1;
            _direction.y = _joystick.Vertical * -1;
            _rigidbody2D.MovePosition(_rigidbody2D.position+_speed*Time.deltaTime*_direction);
        }
    }
}
