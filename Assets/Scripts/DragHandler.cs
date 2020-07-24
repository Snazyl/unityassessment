using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemDragged;
    Transform startParent;
    public GameObject panelDefault;
    public List<GameObject> panelAway = new List<GameObject>();
    Vector3 startPosition;


    public void OnBeginDrag(PointerEventData eventData)
    {
        itemDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        itemDragged.GetComponent<LayoutElement>().ignoreLayout = true;
        itemDragged.transform.SetParent(itemDragged.transform.parent.parent);
    }


    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemDragged = null;

        transform.position = transform.parent.position;

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        itemDragged.GetComponent<LayoutElement>().ignoreLayout = false;
    }

    public void OnClick()
    {
        foreach (var item in panelAway)
        {
            if (item.activeSelf)
            {
                item.SetActive(false);
            }
        }
        panelDefault.SetActive(!panelDefault.activeSelf);
    }

}
