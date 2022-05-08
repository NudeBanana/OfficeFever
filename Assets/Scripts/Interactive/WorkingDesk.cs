using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WorkingDesk : MonoBehaviour
{
    private Transform tray;

    private bool isPlayerNearby;
    
    void Start()
    {
        tray = transform.GetChild(0).GetChild(1);
        isPlayerNearby = false;
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
        yield return new WaitForSeconds(1);
        
        while(col.transform.GetChild(1).childCount > 0 && isPlayerNearby)
        {
            Transform paper = col.transform.GetChild(1).GetChild(0);
            paper.DOMove(tray.position + new Vector3(0, 0.01f * tray.transform.childCount, 0), 0.5f).OnComplete(
                () => paper.DORotate(tray.transform.rotation.eulerAngles, 0.3f).OnComplete( 
                () => paper.rotation = tray.transform.rotation));
            paper.SetParent(tray.transform);
            yield return new WaitForSeconds(1f);
        }

        

    }
}
