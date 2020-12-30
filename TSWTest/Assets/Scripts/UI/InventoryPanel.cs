using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

//Manages and populates inventory screen;
public class InventoryPanel : MonoBehaviour
{
    //References to singleton classes
    public InventoryManager myInventoryManager;
    public UIManager myUIManager;

    //Equipscreen Reference
    EquipScreen myEquipmentScreen;

    //prefab button objects that is spawned for each inventory item
    public UnityEngine.GameObject ButtonPrefab;

    //list of all items currently visible in the inventory
    private List<UnityEngine.GameObject> buttonList = new List<UnityEngine.GameObject>();

    //bool that is flipped whenever a sale is started or ended.
    public bool SellMode = false;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        myUIManager = UIManager.Instance;
        myInventoryManager = InventoryManager.Instance;
        myUIManager.UIInventoryMenu = gameObject;
        myEquipmentScreen = myUIManager.EquipScreen.GetComponent<EquipScreen>();
        PopulateInventory();
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //deconstructs inventory and remakes it according to the player's current inventory scriptable object.
    public void PopulateInventory()
    {
        //clearing
        if(buttonList.Count >= 1)
        {
            foreach(UnityEngine.GameObject button in buttonList)
            {
                Destroy(button);
            }
            buttonList.Clear();
        }
        //checks player inventory and creates a uielement for each inventory item
        foreach (BaseItem item in myInventoryManager.CurrentInventory.PlayerItems)
        {
            UnityEngine.GameObject temp = UnityEngine.GameObject.Instantiate(ButtonPrefab, transform);
            temp.GetComponent<InventoryButton>().myItem = item;
            temp.GetComponent<InventoryButton>().myPanel = this.gameObject;
            buttonList.Add(temp);

        }

    }

    //called whenever an item is clicked from the inventory window
    public void ButtonClicked(UnityEngine.GameObject button, BaseItem item)
    {
        //if in sell mode item is sent to sell panel and removed from inventory
        if (SellMode)
        {
            FindObjectOfType<SellPanel>().AddToTable(item);
            myInventoryManager.RemoveFromPlayerInventroy(item);
            PopulateInventory();
        }
        //sent to equipment screena nd removed from inventory.
        //not possible to sell stuff that is equiped, would like to rework.
        else
        {
            if (item.myCategory[0] != Categories.FoodItem)
            {
                myEquipmentScreen.EquipItem(item);
                myInventoryManager.RemoveFromPlayerInventroy(item);
                PopulateInventory();
            }
        } 
        
    }
}
