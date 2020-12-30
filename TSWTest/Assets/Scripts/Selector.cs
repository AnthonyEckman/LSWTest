using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//Class lets player interact with objects infront of them
public class Selector : MonoBehaviour
{
    //what is currently being hovered over
    private UnityEngine.GameObject Selected;

    //range of interaction
    public float InteractionDistance = 4f;




    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * InteractionDistance, Color.red);
        Selected = PointingAt();

        if (Selected != null && Input.GetKeyDown(KeyCode.Space))
        {
            Selected.GetComponent<ISelectable>().ClickedOn();
        }





    }


    //function checks infront of the player for items that can be interacted with.
    public UnityEngine.GameObject PointingAt()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.up, InteractionDistance,LayerMask.GetMask("Interactive"));
        if (hit.collider != null)
        {
            
            //selection range from player
            if (hit.distance < InteractionDistance)
            {
                UnityEngine.GameObject go = hit.collider.gameObject;
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
