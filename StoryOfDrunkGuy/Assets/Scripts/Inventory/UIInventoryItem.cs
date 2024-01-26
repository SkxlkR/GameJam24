using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class UIInventoryItem : MonoBehaviour, IPointerClickHandler,
        IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private Text quantityText;

        [SerializeField] private Image borderImage;

        public event Action<UIInventoryItem> OnItemClicked, OnItemDroppedOn,
            OnItemBeginDrag, OnItemEndDrag, OnItemRightMouseButtonClicked;

        private bool isEmpty = true;

        public void Awake()
        {
            ResetData();
            Deselect();
        }
        public void Deselect()
        {
            borderImage.enabled = false;
        }

        public void ResetData()
        {
            itemImage.gameObject.SetActive(false);
            isEmpty = true;
        }

        public void SetData(Sprite sprite, int quantity)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = sprite;
            quantityText.text = quantity + "";
            isEmpty = false;
        }

        public void Selecte()
        {
            borderImage.enabled = true;
        }



        public void OnPointerClick(PointerEventData pointerData)
        {
            if (pointerData.button == PointerEventData.InputButton.Right)
            {
                OnItemRightMouseButtonClicked?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (isEmpty)
                return;
            OnItemBeginDrag?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnItemEndDrag?.Invoke(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            OnItemDroppedOn?.Invoke(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
        }
    }
}