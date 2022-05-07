using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCollider : MonoBehaviour
{
    
    
    private void OnCollisionEnter(Collision other)
    {
        other.transform.GetComponent<ChrController>().DisableMovement();

    }

    private void OnCollisionExit(Collision other)
    {
        other.transform.GetComponent<ChrController>().EnableMovement();
    }
    
    
}
