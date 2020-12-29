using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour , ITextBox
{

    public BaseItem myItem;
    public InventoryPanel myPanel;
    
    Image myImage;

    

    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponentInChildren<Button>().GetComponent<Image>();
        myImage.sprite = myItem.icon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    



    public void ClickedOn()
    {
        myPanel.ButtonClicked(this.gameObject, myItem);
    }

    public void SendTextBoxInfo()
    {

        string text = "Price: " + myItem.price + "\nName: " + myItem.name;
        myPanel.myUIManager.SpawnTextBox(text);
        
    }
}
