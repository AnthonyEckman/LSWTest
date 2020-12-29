using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //singleton class that manages all player invetory interactions

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
    }

    private void Start()
    {
        ResetInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetInventory()
    {
        CurrentInventory.Money = DefaultInventory.Money;
        CurrentInventory.PlayerItems = DefaultInventory.PlayerItems;
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
