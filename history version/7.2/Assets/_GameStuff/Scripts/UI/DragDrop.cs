using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField]
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("onDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("beginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Add Event");
        EventManager.m_Instance.AddEventToWishlist(gameObject);
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
