using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Slot : MonoBehaviour, IDropHandler
{

    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }
    #region IDropHandler implementation

    public void OnDrop(PointerEventData eventData)
    {
        Transform parent = DragHandler.itemDragged.transform.parent;
        if (!item)
        {

            DragHandler.itemDragged.transform.SetParent(transform);

        }
        else
        {
            DragHandler.itemDragged.transform.SetParent(transform);
            transform.GetChild(0).SetParent(parent);
        }
    }
    #endregion

}