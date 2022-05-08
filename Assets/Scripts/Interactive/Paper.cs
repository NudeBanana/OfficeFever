using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
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
        Vector2 targetPos = new Vector2(parent.position.x, parent.position.z);
        Vector2 paperPos = new Vector2(transform.position.x, transform.position.z);
        while (Vector2.Distance(targetPos, paperPos) > 0.01f)
        {
            transform.DOMove(parent.position + new Vector3(0, 0, 0), 0.3f).OnComplete(() => transform.position = parent.position);
            
            yield return new WaitForSeconds(0.3f);
            paperPos = new Vector2(transform.position.x, transform.position.z);
            targetPos = new Vector2(parent.position.x, parent.position.z);
        }
        transform.DORotate(parent.rotation.eulerAngles, 0.1f);
    }
}
