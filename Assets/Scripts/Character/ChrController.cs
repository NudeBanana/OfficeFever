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
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedMultiplier = 0.6f;
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
        
        rb.AddForce(new Vector3(vertical*speedMultiplier, 0, horizontal*speedMultiplier), ForceMode.VelocityChange);
        //rb.velocity = new Vector3(vertical*speedMultiplier, 0, horizontal*speedMultiplier);
        
        Vector3 pos = transform.position;
        LookForward(new Vector3(pos.x + vertical, pos.y, pos.z + horizontal));
    }

    public void LookForward(Vector3 toLook)
    {
        if (Vector3.Distance(transform.position ,toLook) > 0)
        {
            transform.DOLookAt(toLook, 1f, AxisConstraint.Y);
        }
        
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
