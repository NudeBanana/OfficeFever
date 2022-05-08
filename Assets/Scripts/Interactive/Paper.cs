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
        
        
            transform.DOMove(parent.position, 0.3f).OnComplete(
                () => transform.position = parent.position).OnComplete(
                () => transform.DORotate(parent.rotation.eulerAngles, 0.1f).OnComplete( //0.3
                    () => transform.rotation = parent.rotation));
            
            yield return new WaitForSeconds(0.3f); //0.3
            transform.position = parent.position;
    }
}
