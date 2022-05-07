using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Paper : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
       
    }

    public IEnumerator MoveToPlayerTray()
    {
        Transform parent = transform.parent;
        while (Vector3.Distance(transform.position, parent.position) > 0.05f)
        {
            yield return new WaitForSeconds(0.001f);
            transform.DOMove(parent.position, 0.3f);
            transform.DORotate(parent.rotation.eulerAngles, 1f);
        }
    }
}
