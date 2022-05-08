using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character _ChrInstance;
    public static Character Instance { get { return _ChrInstance; } }
    
    //Global variables
    [SerializeField]  public int money;
    
    //Character variables
    public int load;
    public bool isLoadFull;
    
    //Children objects
    public Transform tray;
   
    //Character state variables
    [SerializeField] public bool isCarrying;
    [SerializeField] public bool isRunning;
    
    //Script references
    [SerializeField] private ChrController characterController;
    [SerializeField] private ChrAnimation characterAnimation;
    
    private void Awake()
    {
        if (_ChrInstance != null && _ChrInstance != this)
        {
            Destroy(gameObject);
        } else {
            _ChrInstance = this;
        }
        
        //Assign variables
        money = 0;
        tray = transform.GetChild(1);
        tray.gameObject.SetActive(false); 
        
        
        //Assign scripts
        characterController = GetComponent<ChrController>();
        characterAnimation = GetComponent<ChrAnimation>();
        
        //Repeated calls
        InvokeRepeating(nameof(IsRunning), 0.1f, 0.03f);
        InvokeRepeating(nameof(IsCarrying), 0.1f, 0.03f);
        InvokeRepeating(nameof(UpdateLoad), 0.1f, 0.1f);
    }
    
    
    public void IsRunning()
    {
       isRunning = characterController.IsRunning();
       if (isRunning)
       {
           characterAnimation.GetAnimator().SetBool("isRunning", true);
           characterAnimation.GetAnimator().SetFloat("speed", characterController.GetCurrentSpeed());
           //characterAnimation.GetAnimator();
       }
       else
       {
           characterAnimation.GetAnimator().SetBool("isRunning", false);
       }
    }

    public void IsCarrying()
    {
        if (isCarrying)
        {
            characterAnimation.GetAnimator().SetBool("isCarrying", true);
            Invoke(nameof(TrayVisible), 0.4f);
            
        }
        else
        {
            characterAnimation.GetAnimator().SetBool("isCarrying", false);
            Invoke(nameof(TrayHidden), 0.15f);
            
        }
    }

    public void TrayHidden()
    {
        if (tray.gameObject.activeSelf)
        {
            tray.gameObject.SetActive(false);
        }
        
    }

    public void TrayVisible()
    {
        if (!tray.gameObject.activeSelf)
        {
            tray.gameObject.SetActive(true);
        }
        
    }

    public void UpdateLoad()
    {
        load = transform.GetChild(1).childCount;
        isCarrying = (load > 0);
        isLoadFull = (load == 8);
    }

    public void IncreaseMoney()
    {
        money += 100;
    }

   
}
