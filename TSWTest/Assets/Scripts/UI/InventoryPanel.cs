using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour
{
    public InventoryManager myInventoryManager;
    public UIManager myUIManager;

    public GameObject ButtonPrefab;

    private List<GameObject> buttonList = new List<GameObject>();



    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        myUIManager = UIManager.Instance;
        myInventoryManager = InventoryManager.Instance;
        myUIManager.UIInventoryMenu = gameObject;
        PopulateInventory();
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PopulateInventory()
    {
        if(buttonList.Count >= 1)
        {
            foreach(GameObject button in buttonList)
            {
                Destroy(button);
            }
            buttonList.Clear();
        }

        foreach (BaseItem item in myInventoryManager.CurrentInventory.PlayerItems)
        {
            GameObject temp = GameObject.Instantiate(ButtonPrefab, transform);
            temp.GetComponent<InventoryButton>().myItem = item;
            temp.GetComponent<InventoryButton>().myPanel = this;
            buttonList.Add(temp);

        }

    }

    public void ButtonClicked(GameObject button, BaseItem item)
    {
        
    }
}
