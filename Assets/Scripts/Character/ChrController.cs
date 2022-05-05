using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChrController : MonoBehaviour
{
    [SerializeField] public Joystick joystick;
    
    //Movement variables
    [SerializeField] private float speed = 0f;
    private float horizontal = 0f;
    private float vertical = 0f;
    
    
    void Start()
    {
        DOTween.SetTweensCapacity(200, 200);
        speed = 0.6f;
    }

    
    void Update()
    {
        Move();
    }

    public void Move()
    {
        horizontal = -joystick.Horizontal;
        vertical = joystick.Vertical;
        //speed = (Math.Abs(horizontal) > Math.Abs(vertical) ? Math.Abs(horizontal) : Math.Abs(vertical));
        
        Vector3 pos = transform.position;
        //transform.position = Vector3.MoveTowards(pos, new Vector3(pos.x + vertical, pos.y, pos.z + horizontal), speed * Time.deltaTime);
        //transform.DOMove(new Vector3(pos.x + vertical, pos.y, pos.z + horizontal), speed );
        DOTween.To(()=> transform.position, x=> transform.position = x, new Vector3(pos.x + vertical, pos.y, pos.z + horizontal), 1 / speed);

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
    
}
