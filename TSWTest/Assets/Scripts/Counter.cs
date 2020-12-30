using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for counters in game world that hold items
//can be interacted with to buy an item.
public class Counter : MonoBehaviour , ISelectable
{
    public BaseItem Item;
    public UnityEngine.GameObject showing;
    public UnityEngine.GameObject ItemImage;

    UIManager UIManager;
    
    //public InventoryScript playerInventory;



    private void Update()
    {
        


    }
    private void Start()
    {
        CheckItem();
        UIManager = UIManager.Instance;
    }



    //Checks to see if the counter is storing an item, if it is it will spawn an image of it.
    public void CheckItem()
    {
        if (Item != null && ItemImage == null)
        {
            ItemImage = Instantiate(showing, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            ItemImage.GetComponent<SpriteRenderer>().sprite = Item.icon;
            
        }
    }

    //removed item from the counter
    public void RemoveItem()
    {
        Item = null;
        Destroy(ItemImage);
    }


    //Indicates when the player can interact with it
    public void Selected()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        if (Item != null)
        {
            UIManager.SelectorText.text = "Buy " + Item.name + "(Space)";
        }
    }

    public void UnSelected()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        UIManager.Instance.SelectorText.text = "";
    }


    //Calls BuyScreen and starts a transaction
    public void ClickedOn()
    {
        if (Item != null)
        {
            UIManager.HideAllPanels();
            UIManager.ShowPanel(UIPanels.UIBuyScreen);
            UIManager.UIBuyScreen.GetComponent<BuyScreen>().SetupTrade(Item, this);
        }
    }

    
}
