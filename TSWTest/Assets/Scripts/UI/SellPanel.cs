using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles selling interactions
/// </summary>
public class SellPanel : MonoBehaviour
{
    //singleton references
    UIManager myUIManager;
    InventoryManager myInventoryManager;
    
    //uielements references
    public GameObject Bench;
    public Text PayoutText;

    //totals how much the palyer will get
    private int payoutAmmount;

    //prefab used to creat buttons for item bench
    public UnityEngine.GameObject ButtonPrefab;

    //List holding all items currently to be sold
    public List<GameObject> TableContents = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        myUIManager = UIManager.Instance;
        myUIManager.UISellScreen = this.gameObject;
        myInventoryManager = InventoryManager.Instance;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PayoutText.text = "You Will Recieve: " + payoutAmmount;
    }


    //when sale is compelte, player is given money and items are poofed from existance.
    //flips sale flag to off
    public void SellItems()
    {

        myInventoryManager.AddMoney( payoutAmmount);
        ClearTable();
        
        myUIManager.UIInventoryMenu.GetComponent<InventoryPanel>().SellMode = false;
        myUIManager.HideAllPanels();
    }

    //cancels sale and returns all items to player's inventory
    public void cancelSale()
    {
        if (TableContents.Count > 0)
        {
            foreach (GameObject button in TableContents)
            {
                BaseItem temp = button.GetComponent<InventoryButton>().myItem;
                myInventoryManager.AddToPlayerInventory(temp);
            }
        }
        ClearTable();
        myUIManager.UIInventoryMenu.GetComponent<InventoryPanel>().SellMode = false;
        myUIManager.HideAllPanels();
    }

    //called from inventory panel when sell screen is open.
    //creates a button prefab and sets up appropriate images.
    public void AddToTable(BaseItem item)
    {
        UnityEngine.GameObject temp = UnityEngine.GameObject.Instantiate(ButtonPrefab, Bench.transform);
        temp.GetComponent<InventoryButton>().myItem = item;
        temp.GetComponent<InventoryButton>().myPanel = this.gameObject;
        payoutAmmount += temp.GetComponent<InventoryButton>().myItem.price;
        TableContents.Add(temp);



    }

    //removes item from sell table and back into player inventory
    public void RemoveFromTable(GameObject button)
    {
        myInventoryManager.AddToPlayerInventory(button.GetComponent<InventoryButton>().myItem);
        payoutAmmount -= button.GetComponent<InventoryButton>().myItem.price;
        TableContents.Remove(button);
        Destroy(button);
        myUIManager.UIInventoryMenu.GetComponent<InventoryPanel>().PopulateInventory();

    }

    public void StartSale()
    {
        ClearTable();

    }

    private void ClearTable()
    {
        if (TableContents.Count > 0)
        {
            foreach (GameObject button in TableContents)
            {
                
                Destroy(button);
                
            }
        }
        payoutAmmount = 0;
        TableContents.Clear();
    }
}
