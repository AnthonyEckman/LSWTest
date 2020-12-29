using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour , ISelectable
{
    public BaseItem Item;
    public GameObject showing;
    public GameObject ItemImage;
    
    //public InventoryScript playerInventory;



    private void Update()
    {
        


    }
    private void Start()
    {
        CheckItem();
    }



    public void SetItem(BaseItem newItem)
    {
        

    }

    public void RecieveItem(BaseItem item)
    {
        

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
        
    }

    public void Selected()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void ClickedOn()
    {




    }

    public void UnSelected()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
