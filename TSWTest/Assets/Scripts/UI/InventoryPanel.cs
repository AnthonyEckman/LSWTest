using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    InventoryManager myInventoryManager;
    UIManager myUIManager;




    private void Awake()
    {
        myUIManager = UIManager.Instance;
        myInventoryManager = InventoryManager.Instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        myUIManager.UIInventoryMenu = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
