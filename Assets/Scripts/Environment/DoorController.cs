using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private BoxCollider proximityCollider;
    
    void Start()
    {
        proximityCollider = GetComponent<BoxCollider>();
       
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Open();
    }

    private void OnTriggerExit(Collider other)
    {

        Close();
    }
    
    


    public void Open()
    {
        transform.GetChild(0).DOLocalRotate(new Vector3(0, 90, 0), 1.5f);
    }

    public void Close()
    {
        transform.GetChild(0).DOLocalRotate(Vector3.zero, 1.5f);
    }
}
