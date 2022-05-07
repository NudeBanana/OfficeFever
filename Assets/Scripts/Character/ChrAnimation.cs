using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChrAnimation : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
