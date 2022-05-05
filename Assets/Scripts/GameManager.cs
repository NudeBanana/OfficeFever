using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager _GMinstance;
    
    
    public static GameManager Instance { get { return _GMinstance; } }
    
    
    private void Awake()
    {
        if (_GMinstance != null && _GMinstance != this)
        {
            Destroy(gameObject);
        } else {
            _GMinstance = this;
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
