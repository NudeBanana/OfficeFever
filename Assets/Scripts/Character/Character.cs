using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character _ChrInstance;
    public static Character Instance { get { return _ChrInstance; } }
    
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
        
        //Assign scripts
        characterController = GetComponent<ChrController>();
        characterAnimation = GetComponent<ChrAnimation>();
        
        //Repeated calls
        InvokeRepeating(nameof(IsRunning), 0.1f, 0.016f);
        InvokeRepeating(nameof(IsCarrying), 0.1f, 0.016f);
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
        }
        else
        {
            characterAnimation.GetAnimator().SetBool("isCarrying", false);
        }
    }
}
