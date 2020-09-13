using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    public Vector3 posForRot;

    public bool turned;

    public Vector3 playerPos;

    public Vector3 playerPosControl = Vector3.zero;



    public bool ShouldRotate { get; set; }
    public float RotationAngle { get; set; }
    public Quaternion RotateTowards { get; set; }

    private float moveSpeed = 10;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float waitForRot = 0;
    [SerializeField]
    private float waitForClamp = 0;
    [SerializeField]
    private float waitForSpeed = 0;

    [SerializeField] private float bound;


    [SerializeField] private float distFromRot;

    [SerializeField]
    private Animator anim;


    private Rigidbody rb;

    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        posForRot = transform.localPosition;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        playerPos = transform.position;
        
        playerPos += (transform.forward * moveSpeed * Time.deltaTime);

        transform.position = playerPos;


        /*transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime)

        if (!turned)
        {
            playerPos.x = Mathf.Clamp(transform.position.x, posForRot.x - bound, posForRot.x + bound);
        }
        else
        {
            playerPos.z = Mathf.Clamp(transform.position.z, posForRot.z - bound, posForRot.z + bound);
        }



        rb.MovePosition(playerPos);*/
    }

    public void Rotate(Vector3 towards, Vector3 pos)
    {
        transform.DORotate(towards, rotationSpeed, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetDelay(waitForRot);
       // StartCoroutine(StartRot(towards, pos));
    }

    /*IEnumerator StartRot(Vector3 _towards, Vector3 objPos)
    {
        yield return new WaitForSeconds(waitForRot);
        
        transform.DORotate(_towards, rotationSpeed, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);

        yield return new WaitForSeconds(waitForClamp);


        posForRot = objPos + Vector3.forward * distFromRot;

        if (!turned)
        {
            turned = true;
        }
        else
        {
            turned = false;
        }
    }*/

    public IEnumerator SpeedIncrease()
    {
        float speed = moveSpeed;
        moveSpeed += 20;
        yield return new WaitForSeconds(waitForSpeed);
        moveSpeed = speed;
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        anim.Play("Jump");
    }

    public void Grounded(bool _isGrounded)
    {
        isGrounded = _isGrounded;
        anim.SetBool("isGrounded", isGrounded);
    }
}
