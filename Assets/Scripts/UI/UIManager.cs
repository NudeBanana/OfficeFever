using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private Transform panel;
    private Component moneyText;
    
    void Start()
    {
        panel = transform.GetChild(1);
        moneyText = panel.GetChild(0).GetChild(1).GetComponent<Text>();
        //Update
        InvokeRepeating(nameof(UpdateMoney), 0.1f, 0.3f);
    }

    
    void Update()
    {
        
    }

    public void UpdateMoney()
    {
        moneyText.GetComponent<Text>().text = Character._ChrInstance.money.ToString();
    }
    
}
