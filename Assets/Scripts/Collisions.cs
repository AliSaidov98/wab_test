using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] private PlayerMove player;
    [SerializeField] private Score playerScore;


    private float _rotationAngle = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Trap")
        {
            transform.parent = null;
        }
        else if(other.tag == "Speed")
        {
            StartCoroutine(player.SpeedIncrease());
        }
        else if(other.tag == "Jump")
        {
            player.Jump();
        }
        else if(other.tag == "Diamond")
        {
            playerScore.ScoreUp();
            Destroy(other.gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        player.Grounded(true);
        if (other.gameObject.tag == "RotateL")
        {
            Vector3 objPos = other.gameObject.transform.position;
            _rotationAngle = -90;
            RotatePlayer(_rotationAngle, objPos);
        }
        if (other.gameObject.tag == "RotateR")
        {
            Vector3 objPos = other.gameObject.transform.position;
            _rotationAngle = 90;
            RotatePlayer(_rotationAngle, objPos);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        player.Grounded(false);
    }

    private void RotatePlayer(float angle, Vector3 pos)
    {
        Vector3 rotation = new Vector3(transform.rotation.x, transform.rotation.y + angle, transform.rotation.z);
        player.Rotate(rotation, pos);
    }
}
