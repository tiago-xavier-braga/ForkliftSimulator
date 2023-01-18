using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
    }
}
