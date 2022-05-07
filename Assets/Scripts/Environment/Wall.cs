using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        other.transform.DOFlip();

    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
