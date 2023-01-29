using TMPro;
using UnityEngine;

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

    private void FixedUpdate()
    {
        if (infoCanvas.isActiveAndEnabled)
            infoCanvas.transform.LookAt(mainCamera.transform.position + panelRotationOffset);
    }

    void DisplayItem(Vector3 position, HoverInfo info)
    {
        itemInfoText.SetText(info.itemName);
        infoCanvas.transform.position = position + infoPanelOffset;
        infoCanvas.gameObject.SetActive(true);
    }

    void HideItemDisplay(Vector3 position, HoverInfo info)
    {
        itemInfoText.text = string.Empty;
        infoCanvas.transform.position = Vector3.zero + Vector3.down * 10;
        infoCanvas.gameObject.SetActive(false);
    }
}

