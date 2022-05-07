using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChrController : MonoBehaviour
{
    [SerializeField] public Joystick joystick;

    private Rigidbody rb;
    //Movement variables
    [SerializeField] private float speedMultiplier = 0f;
    private float currentSpeed = 0f;
    private float horizontal = 0f;
    private float vertical = 0f;
    private bool isRunning;
    [SerializeField] private bool canMove;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedMultiplier = 0.4f;
        canMove = true;
        isRunning = false;
    }

    
    void LateUpdate()
    {
        Move();
    }

    public void Move()
    {
        horizontal = -joystick.Horizontal;
        vertical = joystick.Vertical;
        currentSpeed = (Math.Abs(horizontal) > Math.Abs(vertical) ? Math.Abs(horizontal) : Math.Abs(vertical));
        
        if (horizontal != 0 || vertical != 0)
        {
            isRunning = true;
            
        }
        else
        {
            isRunning = false;
        }
        Vector3 pos = transform.position;
        //rb.AddForce(new Vector3(vertical*speedMultiplier, 0, horizontal*speedMultiplier), ForceMode.VelocityChange);
        //DOTween.To(()=> transform.position, x=> transform.position = x, new Vector3(pos.x + vertical, pos.y, pos.z + horizontal), 1 / speedMultiplier);
        transform.DOMove(new Vector3(pos.x + vertical, pos.y, pos.z + horizontal), 1/speedMultiplier);
            
        if (!canMove)
        {
            transform.DOKill();
        }
        
        LookForward(new Vector3(pos.x + vertical, pos.y, pos.z + horizontal));
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void LookForward(Vector3 toLook)
    {
        if (Vector3.Distance(transform.position ,toLook) > 0)
        {
            transform.DOLookAt(toLook, 1f, AxisConstraint.Y);
        }
        
    }

    public void TweenKillAll()
    {
        DOTween.KillAll();
    }

    public Vector3 GetCurrentPos()
    {
        return transform.position;
    }

    public void SetCurrentPos()
    {
        
    }

    public float GetCurrentSpeed() //To set running animation speed
    {
        return (currentSpeed > 0.2f ? currentSpeed : 0.2f);
    }

    public bool IsRunning()
    {
        return isRunning;
    }
    
}
