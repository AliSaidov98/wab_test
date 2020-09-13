using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform centerOfRot;


    [SerializeField]
    private float smoothSpeed;

    [SerializeField]
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Vector3 desiredPosition = player.position + offset;
        // Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        centerOfRot.position = Vector3.Lerp(centerOfRot.position, player.position, smoothSpeed);
        centerOfRot.rotation = player.rotation;
        //transform.position = smoothPosition;
    }
}
