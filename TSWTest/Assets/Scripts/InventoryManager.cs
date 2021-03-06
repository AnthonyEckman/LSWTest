﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Singleton Class that handles all transactions involvoing player inventory.
/// </summary>
public class InventoryManager : MonoBehaviour
{
    

    private static InventoryManager _instance;
    
    public static InventoryManager Instance { get { return _instance; } }

    //current inventory player is using
    public PlayerInventory CurrentInventory;

    //default inventory that is defaulted to on game start.
    public PlayerInventory DefaultInventory;

    private void Awake()
    {
        if(_instance !=null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        ResetInventory();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called on game start to make player inventory mirror a default template
    private void ResetInventory()
    {
        CurrentInventory.Money = 0;
        CurrentInventory.Money += DefaultInventory.Money;
        CurrentInventory.PlayerItems.Clear();
        foreach(BaseItem item in DefaultInventory.PlayerItems)
        {
            CurrentInventory.PlayerItems.Add(item);
        }
    }


    public void AddToPlayerInventory(BaseItem newItem)
    {
        CurrentInventory.PlayerItems.Add(newItem);
    }   

    public void RemoveFromPlayerInventroy(BaseItem item)
    {
        CurrentInventory.PlayerItems.Remove(item);
    }

    public void AddMoney(int ammount)
    {
        CurrentInventory.Money += ammount;
    }

    public void RemoveMoney(int ammount)
    {
        CurrentInventory.Money -= ammount;
    }
}
