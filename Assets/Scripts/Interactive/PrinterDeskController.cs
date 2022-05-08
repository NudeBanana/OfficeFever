using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PrinterDeskController : MonoBehaviour
{

    private Transform[] paperSlots;
    private Transform[] paperWaypoints;
    private Transform tray;
    private Transform printer;
    
    [SerializeField] private GameObject paperObject;
    

    [SerializeField] private bool isTrayFull;
    [SerializeField] private bool isEmpty;
    [SerializeField] private bool isPlayerNearby;
    
    void Start()
    {
        printer = transform.GetChild(0);
        tray = transform.GetChild(1);
        paperSlots = transform.GetChild(1).gameObject.GetComponentsInChildren<Transform>();
        paperWaypoints = transform.GetChild(0).transform.GetChild(1).gameObject.GetComponentsInChildren<Transform>();
        isTrayFull = false;
        isPlayerNearby = false;

        StartCoroutine(PrintPaper());
        InvokeRepeating(nameof(UpdateTrayStatus), 0.1f, 0.1f);
    }
    
    void Update()
    {
        
    }

    public IEnumerator PrintPaper()
    {
        while (!isTrayFull)
        {
            yield return new WaitForSeconds(0.3f);
            for (int i = 1; i < paperSlots.Length; i++)
            {
                if (paperSlots[i].childCount < 5)
                {
                    GameObject toInstantiate = Instantiate(paperObject, printer.position, Quaternion.Euler(new Vector3(0, -90, 0)));
                    toInstantiate.transform.SetParent(paperSlots[i]);
                    toInstantiate.transform.DOMove( paperWaypoints[1].position, 0.2f ).SetRelative( false ).OnComplete( () =>
                        toInstantiate.transform.DOMove(paperSlots[i].position + new Vector3(0, paperSlots[i].childCount * 0.01f, 0), 0.4f));
                    yield return new WaitForSeconds(1f);
                }
                
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !other.GetComponent<Character>().isLoadFull)
        {
            isPlayerNearby = true;
            StartCoroutine(MovePaperToPlayer(other));
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNearby = false;
        StopCoroutine(MovePaperToPlayer(other));
    }


    public IEnumerator MovePaperToPlayer(Collider col)
    {
        
        if (Character._ChrInstance.load < 8)
        {
            yield return new WaitForSeconds(0.8f);
            for (int i = 8; i > 1; i--)
            {
                yield return new WaitForSeconds(0.8f);
                if (paperSlots[i].childCount > 0 && Character._ChrInstance.load < 8 && isPlayerNearby)
                {
                    Transform paper = paperSlots[i].GetChild(0);
                    paper.SetParent(col.transform.GetChild(1));
                    paper.transform.DOKill();
                    StartCoroutine(paper.GetComponent<Paper>().MoveToPlayerTray());
                    StartCoroutine(MovePaperToPlayer(col));
                    yield break;
                    
                }
            }
        }
    }

    
    public void UpdateTrayStatus() //Is empty or is full
    {
        int paperCount = 0;
        for (int i = 0; i < paperSlots.Length; i++)
        {
            if (paperSlots[i].childCount > 0)
            {
                paperCount++;
            }
        }
        isEmpty = (paperCount == 0);
        isTrayFull = (paperCount == 32);
    }
    

}
