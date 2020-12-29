using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour , ISelectable
{
    public BaseItem Item;
    public GameObject showing;
    public GameObject ItemImage;

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



 
    public void CheckItem()
    {
        if (Item != null && ItemImage == null)
        {
            ItemImage = Instantiate(showing, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            ItemImage.GetComponent<SpriteRenderer>().sprite = Item.icon;
            
        }
    }

    public void RemoveItem()
    {
        Item = null;
        Destroy(ItemImage);
    }



    public void Selected()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }


    public void UnSelected()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

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
