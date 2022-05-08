using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Animator anim;

    [SerializeField] private Transform destination1;
    [SerializeField] private Transform destination2;
    [SerializeField] private Transform destination3;

    private List<Transform> destinations;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        destinations = new List<Transform>();
        destinations.Add(destination1);
        destinations.Add(destination2);
        destinations.Add(destination3);
        //
        anim.SetBool("isMoving", true);
        
        StartCoroutine(CycleDestination());
    }

    private void Update()
    {
       
    }

    public void SetDestination(Transform dest)
    {
        navMeshAgent.destination = dest.position;
    }

    private IEnumerator CycleDestination()
    {
        int index = 0;
        SetDestination(destinations[index]);

        while (true)
        {
            if (Vector3.Distance(transform.position, destinations[index].position) < 2f)
            {
                index = (index + 1) % 3;
                SetDestination(destinations[index]);
            }
            
            yield return new WaitForSeconds(1f);
        }
        
        
        
    }
}
