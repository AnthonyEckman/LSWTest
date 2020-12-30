using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


//shop guy who stands around and starts sale
public class ShopKeeper : MonoBehaviour , ISelectable
{

    UIManager myUIManager;
    
 

    // Start is called before the first frame update
    void Start()
    {
        myUIManager = UIManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when clicked on, calls UIManager to flip flag on inventory menue for sale and show sell screen
    public void ClickedOn()
    {
        
        myUIManager.HideAllPanels();
        myUIManager.ShowPanel(UIPanels.UIInventoryMenu);
        myUIManager.ShowPanel(UIPanels.UISellScreen);
        myUIManager.UIInventoryMenu.GetComponent<InventoryPanel>().SellMode = true;

    }

    public void Selected()
    {
        GetComponent<SpriteShapeRenderer>().color = Color.red;
        UIManager.Instance.SelectorText.text = "Sell Items(Space)";
    }

    public void UnSelected()
    {
        GetComponent<SpriteShapeRenderer>().color = Color.white;
        UIManager.Instance.SelectorText.text = "";
    }
}
