using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnlockPad : MonoBehaviour
{
    [SerializeField] public int requiredAmount;
    [SerializeField] public int currentAmount;
    private Transform innerPart;
    private Transform progressBar;
    private Image progressImg;
    private Text amountText;
    [SerializeField] private bool isPlayerNearby;
    [SerializeField] private Transform toSpawn;
    private Transform playerTeleportPoint;
    
    
    void Start()
    {
        requiredAmount = 800;
        isPlayerNearby = false;
        innerPart = transform.GetChild(1);
        progressBar = transform.GetChild(0);
        progressImg = progressBar.GetComponent<Image>();
        progressImg.fillAmount = 0f;
        amountText = innerPart.GetComponent<Text>();
        playerTeleportPoint = transform.GetChild(3);

        StartCoroutine(Progress());
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !isPlayerNearby)
        {

            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player") && isPlayerNearby)
        {
            isPlayerNearby = false;
        }
    }

    private void UpdateProgress()
    {
        progressImg.fillAmount = (float) currentAmount / requiredAmount;
        amountText.text = (requiredAmount - currentAmount).ToString();

    }

    private IEnumerator Progress()
    {
        if (isPlayerNearby)
        {
            if (Character._ChrInstance.money >= 100 && currentAmount < requiredAmount)
            {
                Character._ChrInstance.money -= 100;
                currentAmount += 100;
                UpdateProgress();
                if (currentAmount == requiredAmount)
                {
                    Unlock();
                }
            }
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Progress());
    }

    private void Unlock()
    {
        Character._ChrInstance.transform.position = playerTeleportPoint.transform.position;
        Instantiate(toSpawn, transform.position + new Vector3(-1.818f, 2.576f, -1.133f), Quaternion.Euler(Vector3.zero));
        Destroy(gameObject);
    }
    //new Vector3(-2.108f, 2.946f, 12.807f)
}
