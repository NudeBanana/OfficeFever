using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Wall : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision other)
    {
        other.transform.GetComponent<ChrController>().DisableMovement();

    }

    private void OnCollisionExit(Collision other)
    {
        other.transform.GetComponent<ChrController>().EnableMovement();
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
