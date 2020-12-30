using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//class used in inventorypanel class and sell panel class
//Stores an object and displays it as a button
public class InventoryButton : MonoBehaviour , ITextBox
{
    //references
    public BaseItem myItem;
    public GameObject myPanel;
    UIManager myUIManager;
    
    Image myImage;

    

    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponentInChildren<Button>().GetComponent<Image>();
        myImage.sprite = myItem.icon;
        myUIManager = UIManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    //whenever the item is clicked on it will check wether it its parent is the inventorypanel or sell panel
    //calls appropriate function to move item.
    public void ClickedOn()
    {
        if (myPanel.GetComponent<InventoryPanel>())
        {
            myPanel.GetComponent<InventoryPanel>().ButtonClicked(this.gameObject, myItem);
        }
        if(myPanel.GetComponent<SellPanel>())
        {
            myPanel.GetComponent<SellPanel>().RemoveFromTable(gameObject);
        }
    }

    //displays item information when hovered.
    public void SendTextBoxInfo()
    {

        string text = "Price: " + myItem.price + "\nName: " + myItem.name;
        myUIManager.SpawnTextBox(text);
        
    }
}
