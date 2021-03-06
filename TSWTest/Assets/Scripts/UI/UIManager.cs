﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//enum that stores all types of inventory panels
public enum UIPanels
{
    UIInventoryMenu,
    UIBuyScreen,
    UISellScreen,
    UIEquipScreen
}

/// <summary>
/// Singleton Class that handles all UIInteractions and Displays
/// </summary>
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance { get { return _instance; } }

    public InventoryManager myInventoryManager;

    //references to all uipanels
    //references are set when uipanels are awake
    public UnityEngine.GameObject UIInventoryMenu;

    //displays ui for player equipment
    public GameObject EquipScreen;
    //displays ui for buying an object
    public UnityEngine.GameObject UIBuyScreen;
    //displays ui for selling objects
    public GameObject UISellScreen;
    //dispalys item info
    public UnityEngine.GameObject textBox;
    //displays money
    public Text MoneyAmmount;
    public Text SelectorText;

    //current text box that is being displayed
    UnityEngine.GameObject activeTextBox;



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
        //Opens Inventory Menu
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (!UIInventoryMenu.active)
            {
                ShowPanel(UIPanels.UIInventoryMenu);
                ShowPanel(UIPanels.UIEquipScreen);
            }
            else
            {
                HidePanel(UIPanels.UIInventoryMenu);
                HidePanel(UIPanels.UIEquipScreen);
            }

        }
        MouseOverText();
        //updates money ammount
        MoneyAmmount.text = "Money: " + myInventoryManager.CurrentInventory.Money;

        
    }

    //shows the requested panel
    public void ShowPanel(UIPanels panel)
    {
        switch(panel)
        {
            case UIPanels.UIInventoryMenu:
                if (!UIBuyScreen.active)
                {
                    UIInventoryMenu.SetActive(true);
                    UIInventoryMenu.GetComponent<InventoryPanel>().PopulateInventory();
                }
                break;

            case UIPanels.UIBuyScreen:
                UIBuyScreen.SetActive(true);
                break;

            case UIPanels.UISellScreen:
                UISellScreen.SetActive(true);
                break;

            case UIPanels.UIEquipScreen:
                EquipScreen.SetActive(true);
                break;


        }

    }

    //Hides the requested panel
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

            case UIPanels.UISellScreen:
                UISellScreen.SetActive(false);
                break;

            case UIPanels.UIEquipScreen:
                EquipScreen.SetActive(false);
                break;
        }
    }

    //Hides all UI Elements
    public void HideAllPanels()
    {
        foreach(UIPanels panel in System.Enum.GetValues(typeof(UIPanels)))
        {
            HidePanel(panel);
        }
    }

    //Send raycast through Ui to check for valid objects that can display item information
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

    //called from an objects with ITextBox and is hovered over.
    //Spawns TextBox
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


    public void ExitGame()
    {
        Application.Quit();
    }
}
