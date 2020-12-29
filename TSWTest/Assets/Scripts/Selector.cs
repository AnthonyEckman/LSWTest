using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    private GameObject Selected;

    public float InteractionDistance = 2f;




    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * 2, Color.red);
        Selected = PointingAt();

        if (Selected != null && Input.GetKeyDown(KeyCode.Space))
        {
            Selected.GetComponent<ISelectable>().ClickedOn();
        }





    }


    //function checks infront of the player for items that can be interacted with.
    public GameObject PointingAt()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.up, InteractionDistance,LayerMask.GetMask("Interactive"));
        if (hit.collider != null)
        {
            
            //selection range from player
            if (hit.distance < 2)
            {
                GameObject go = hit.collider.gameObject;
                if (go.GetComponent<ISelectable>() != null)
                {
                    
                    if (Selected != null)
                    {
                        Selected.GetComponent<ISelectable>().UnSelected();
                    }
                    go.GetComponent<ISelectable>().Selected();
                    return go;
                }
                else
                {
                    if (Selected != null)
                    {
                        Selected.GetComponent<ISelectable>().UnSelected();
                    }
                    return null;
                }
            }

        }
        if (Selected != null)
        {
            Selected.GetComponent<ISelectable>().UnSelected();
        }

        return null;

    }
}
