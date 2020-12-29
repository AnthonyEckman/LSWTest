using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum UIPanels
{
    UIInventoryMenu,
    UIBuyScreen
}


public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance { get { return _instance; } }

    public InventoryManager myInventoryManager;

    public  GameObject UIInventoryMenu;
    public GameObject UIBuyScreen;
    public GameObject textBox;
    public Text MoneyAmmount;

    GameObject activeTextBox;



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myInventoryManager = InventoryManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (!UIInventoryMenu.active)
            {
                ShowPanel(UIPanels.UIInventoryMenu);
            }
            else
            {
                HidePanel(UIPanels.UIInventoryMenu);
            }

        }
        MouseOverText();
        MoneyAmmount.text = "Money: " + myInventoryManager.CurrentInventory.Money;
    }
    public void ShowPanel(UIPanels panel)
    {
        switch(panel)
        {
            case UIPanels.UIInventoryMenu:
                if (!UIBuyScreen.active)
                {
                    UIInventoryMenu.SetActive(true);
                }
                break;
            case UIPanels.UIBuyScreen:
                UIBuyScreen.SetActive(true);
                break;
        }

    }
    public void HidePanel(UIPanels panel)
    {
        switch (panel)
        {
            case UIPanels.UIInventoryMenu:
                UIInventoryMenu.SetActive(false);
                break;
            case UIPanels.UIBuyScreen:
                UIBuyScreen.SetActive(false);
                break;
        }
    }
    public void HideAllPanels()
    {
        foreach(UIPanels panel in System.Enum.GetValues(typeof(UIPanels)))
        {
            HidePanel(panel);
        }
    }

    public void MouseOverText()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;


        List<RaycastResult> raycastList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastList);
        for (int i = 0; i < raycastList.Count; i++)
        {
            if (raycastList[i].gameObject.GetComponent<ITextBox>() == null)
            {
                raycastList.RemoveAt(i);
            }
        }
        if (raycastList.Count >= 1 && activeTextBox == null)
        {
            if (raycastList[0].gameObject.GetComponent<ITextBox>() != null)
            {
                raycastList[0].gameObject.GetComponent<ITextBox>().SendTextBoxInfo();
            }
        }
        else if(raycastList.Count == 0)
        {
            if(activeTextBox != null)
            {
                Destroy(activeTextBox);
            }
        }

    }

    public void SpawnTextBox(string text)
    {
        if(activeTextBox != null)
        {
            Destroy(activeTextBox);
        }

        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        var temp = Instantiate( textBox,transform);
        temp.GetComponentInChildren<Text>().text = text;
        temp.transform.position = pointerData.position;
        activeTextBox = temp;
    }
}
