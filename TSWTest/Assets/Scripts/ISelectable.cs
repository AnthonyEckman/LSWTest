using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//interface for objects to be interacted with
//objects must be on the interactable layer.
public interface ISelectable
{
    void Selected();

    void UnSelected();

    void ClickedOn();

    

}
