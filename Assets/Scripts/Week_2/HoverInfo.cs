using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Action<Vector3, HoverInfo> OnPointerEntered, OnPointerExited;
    public ItemType currentItemType;
    string itemName;

    public void CreateItemName()
    {
        string name = "Unknown";
        itemName = name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEntered?.Invoke(transform.position, this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExited?.Invoke(transform.position, this);
    }
}
