using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class WorkingDesk : MonoBehaviour
{
    private Transform tray;
    private Transform moneyArea;
    private bool isPlayerNearby;
    private bool isWorking;
    private bool isMoneyAreaFull;
    [SerializeField] private Transform moneyObject;
    private Animator workerAnimator;
    
    void Start()
    {
        tray = transform.GetChild(0).GetChild(1);
        moneyArea = transform.GetChild(3);
        workerAnimator = transform.GetChild(2).GetComponent<Animator>();
        isPlayerNearby = false;
        isWorking = false;
        isMoneyAreaFull = false;
        

        StartCoroutine(Work());
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayerNearby = true;
            if (other.GetComponent<Character>().isCarrying)
            {
                StartCoroutine(MovePaperToTray(other));
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNearby = false;
    }


    private IEnumerator MovePaperToTray(Collider col)
    {
        yield return new WaitForSeconds(0.3f);
        
        while(col.transform.GetChild(1).childCount > 0 && isPlayerNearby)
        {
            Transform paper = col.transform.GetChild(1).GetChild(0);
            paper.DOMove(tray.position + new Vector3(0, 0.01f+0.01f * tray.transform.childCount, 0), 0.5f).OnComplete(
                () => paper.DORotate(tray.transform.rotation.eulerAngles, 0.3f).OnComplete( 
                () => paper.rotation = tray.transform.rotation));
            paper.SetParent(tray.transform);
            yield return new WaitForSeconds(0.3f); //1.0
        }

        
    }

    private bool IsTrayEmpty()
    {
        return (tray.childCount == 0);
    }

    private IEnumerator Work()
    {
        if (!IsTrayEmpty() && !isMoneyAreaFull)
        {
            workerAnimator.SetBool("IsWorking", true);
            Destroy(tray.GetChild(tray.childCount - 1).gameObject);
            yield return new WaitForSeconds(2);
            WorkComplete();
            workerAnimator.SetBool("IsWorking", false);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(Work());
    }

    private void WorkComplete()
    {
        SpawnMoney();
        //Character._ChrInstance.money += 100;
    }

    private void SpawnMoney()
    {
        for (int i = 0; i < moneyArea.childCount; i++)
        {
            if (moneyArea.GetChild(i).childCount == 0)
            {
                Instantiate(moneyObject, moneyArea.GetChild(i).position, transform.root.GetChild(0).rotation).SetParent(moneyArea.GetChild(i));
                UpdateMoneyAreaStatus();
                break;
            }
        }
    }

    public void UpdateMoneyAreaStatus()
    {
        int count = 0;
        for (int i = 0; i < moneyArea.childCount; i++)
        {
            if (moneyArea.GetChild(i).childCount > 0)
            {
                count++;
            }
        }

        isMoneyAreaFull = (count == 12);
    }
    
}
