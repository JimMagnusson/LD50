﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollector : MonoBehaviour
{
    [SerializeField] private bool togglesCarOnFirstPickup = false;
    [SerializeField] private Transform under;
    [SerializeField] private Transform wheelCovers;
    [SerializeField] private Transform front;
    [SerializeField] private Transform side;
    [SerializeField] private Transform roof;

    private Grower grower;
    private int partsCollected = 0;
    private EnemyCarController enemyCarController;


    private void Start()
    {
        grower = GetComponent<Grower>();
        enemyCarController = FindObjectOfType<EnemyCarController>();
    }

    public int GetPartsCollected()
    {
        return partsCollected;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Part>())
        {
            partsCollected++;
            switch(partsCollected)
            {
                case 1:
                    if(togglesCarOnFirstPickup)
                    {
                        enemyCarController.ToggleCar(true);
                    }
                    under.gameObject.SetActive(true);
                    break;
                case 2:
                    wheelCovers.gameObject.SetActive(true);
                    break;
                case 3:
                    front.gameObject.SetActive(true);
                    break;
                case 4:
                    side.gameObject.SetActive(true);
                    break;
                case 5:
                    roof.gameObject.SetActive(true);
                    break;
                default:
                    Debug.LogError("More than 5 parts collected.");
                    break;
            }
            if(grower != null)
            {
                grower.Grow();
            }
        }
    }
}