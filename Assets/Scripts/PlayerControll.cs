using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _joystick;

    [SerializeField] private float controlSpeed;

    [SerializeField]
    private PlayerMove playerMove;

    private void Update()
    {
        if (_joystick.drugged)
        {
            Vector3 position = transform.right * (_joystick.Horizontal * controlSpeed * Time.deltaTime);
            transform.position += position;
        }
    }
}
