using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyScreen : MonoBehaviour
{
    public InventoryManager myInventoryManager;
    public UIManager myUIManager;

    public Text BuyText;
    public Image ItemImage;

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

    public void AcceptTrade()
    {
        if (myInventoryManager.CurrentInventory.Money - activeItem.price >= 0)
        {
            myInventoryManager.CurrentInventory.Money -= activeItem.price;
            myInventoryManager.CurrentInventory.PlayerItems.Add(activeItem);
            myUIManager.HidePanel(UIPanels.UIBuyScreen);
            myUIManager.UIInventoryMenu.GetComponent<InventoryPanel>().PopulateInventory();
            activeCounter.RemoveItem();
            Clear();
        }
    }

    public void DeclineTrade()
    {
        myUIManager.HidePanel(UIPanels.UIBuyScreen);
        Clear();
    }

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
