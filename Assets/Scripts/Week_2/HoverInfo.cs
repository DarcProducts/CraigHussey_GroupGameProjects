using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Action<Vector3, HoverInfo> OnPointerEntered, OnPointerExited;
    public ItemType currentItemType;
    public string itemName;

    void OnEnable()
    {
        itemName = string.Empty;
        itemName = ItemNameGenerator.Instance.CreateItemName(currentItemType);
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
