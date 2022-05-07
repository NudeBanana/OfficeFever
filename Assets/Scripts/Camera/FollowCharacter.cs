using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static ExtensionMethods;

public class FollowCharacter : MonoBehaviour
{
    //Character reference
    [SerializeField] private Transform character;
    
    //Movement variables
    [SerializeField] private float maxSpeed = 0f;
    [SerializeField] private float dist;
    private Vector3 offset;
    
    void Start()
    {
        
        offset = new Vector3(-5, 12, 0);
    }

    
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        dist = Vector3.Distance(transform.position, character.GetComponent<Rigidbody>().position);
        maxSpeed = dist.Map(12, 16, 2, 4);
        
        transform.position = Vector3.Lerp(transform.position,character.GetComponent<Rigidbody>().position + offset, maxSpeed );
    }
    
    
}
