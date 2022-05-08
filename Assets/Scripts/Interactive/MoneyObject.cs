using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyObject : MonoBehaviour
{
    private Transform rootParent;
    
    private bool taken = false;


    private void Start()
    {
        rootParent = transform.root;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player") && !taken)
        {
            transform.SetParent(other.transform);
            taken = true;
            StartCoroutine(MoveToPlayer());
            rootParent.GetComponent<WorkingDesk>().UpdateMoneyAreaStatus();
        }
    }

    public IEnumerator MoveToPlayer()
    {

        transform.DOMove(transform.parent.position, 0.3f).OnComplete(() => transform.position = transform.parent.position);
        yield return new WaitForSeconds(0.3f);
        Character._ChrInstance.IncreaseMoney();
        Destroy(gameObject);
    }

   
}
