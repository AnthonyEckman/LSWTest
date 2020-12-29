using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum UIElements
{
    UIInventoryMenu
}
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance { get { return _instance; } }

    public  GameObject UIInventoryMenu;

    

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void ShowPanel(UIElements element)
    {

    }

    public static void HidePanel()
    {

    }

    public static void HideAllPanels()
    {

    }
}
