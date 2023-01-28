using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemDisplayer : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Canvas infoCanvas;
    [SerializeField] TMP_Text itemInfoText;
    [SerializeField] Vector3 infoPanelOffset;
    [SerializeField] Vector3 panelRotationOffset;

    private void OnEnable()
    {
        HoverInfo.OnPointerEntered += DisplayItem;
        HoverInfo.OnPointerExited += HideItemDisplay;
    }

    private void OnDisable()
    {
        HoverInfo.OnPointerEntered -= DisplayItem;
        HoverInfo.OnPointerExited -= HideItemDisplay;
    }

    void DisplayItem(Vector3 position, HoverInfo info)
    {
        infoCanvas.transform.position = position + infoPanelOffset;
        infoCanvas.transform.LookAt(mainCamera.transform.position + panelRotationOffset);
        itemInfoText.text = info.currentItemType.ToString();
        infoCanvas.gameObject.SetActive(true);
    }

    void HideItemDisplay(Vector3 position, HoverInfo info)
    {
        infoCanvas.transform.position = Vector3.zero + Vector3.down * 10;
        infoCanvas.gameObject.SetActive(false);
    }
}

