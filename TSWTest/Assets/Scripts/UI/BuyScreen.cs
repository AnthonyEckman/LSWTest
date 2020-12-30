using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//screen handles purchasing of an item from a counter
public class BuyScreen : MonoBehaviour
{
    //singletone references
    public InventoryManager myInventoryManager;
    public UIManager myUIManager;

    //item information
    public Text BuyText;
    public Image ItemImage;

    //item and counter reference
    BaseItem activeItem;
    Counter activeCounter;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        myUIManager = UIManager.Instance;
        myInventoryManager = InventoryManager.Instance;
        myUIManager.UIBuyScreen = gameObject;
        gameObject.SetActive(false);

    }

    //if trade is accepted, money is taken from player inventory and item is added to player inventory.
    public void AcceptTrade()
    {
        if (myInventoryManager.CurrentInventory.Money - activeItem.price >= 0)
        {
            myInventoryManager.RemoveMoney(activeItem.price);
            myInventoryManager.AddToPlayerInventory(activeItem);
            myUIManager.HidePanel(UIPanels.UIBuyScreen);
            myUIManager.UIInventoryMenu.GetComponent<InventoryPanel>().PopulateInventory();
            activeCounter.RemoveItem();
            Clear();
        }
    }

    //rehides panel and clears it
    public void DeclineTrade()
    {
        myUIManager.HidePanel(UIPanels.UIBuyScreen);
        Clear();
    }

    //called from counters when a trade is initiated.
    //Sets up images and text for the appropriate item
    public void SetupTrade(BaseItem item,Counter counter)
    {
        BuyText.text = "Name: " + item.name + "\nDescription: " + item.description + "\nPrice: " + item.price;
        ItemImage.sprite = item.icon;
        activeItem = item;
        activeCounter = counter;
    }

    public void Clear()
    {
        activeItem = null;
        activeCounter = null;
        ItemImage.sprite = null;
        BuyText.text = "";
    }
}
