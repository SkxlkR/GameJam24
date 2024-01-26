using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem InventoryItemUIPrefab;
        [SerializeField] private RectTransform contentPanel;
        [SerializeField] private UIInventoryDescription InventoryItemUIDescription;
        [SerializeField] private MouseFollower mouseFollower;


        private int currentlyDraggedItemIndex = -1;

        public event Action<int> OnDescriptionRequested,
            OnItemActionRequested,
            OnStartDragging;

        

        public event Action<int, int> OnSwapItems;

        

        List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

        private void Awake()
        {
            Hide();
            mouseFollower.Toggle(false);
            InventoryItemUIDescription.ResetDescription();
        }

        public void InitializeInventoryUI(int inventorySize)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                UIInventoryItem uiItem = Instantiate(InventoryItemUIPrefab, Vector3.zero,
                    Quaternion.identity);
                uiItem.transform.SetParent(contentPanel);
                listOfUIItems.Add(uiItem);
                uiItem.OnItemClicked += HandleItemSelection;
                uiItem.OnItemBeginDrag += HandleBeginDrag;
                uiItem.OnItemDroppedOn += HandleSwap;
                uiItem.OnItemEndDrag += HandleEndDrag;
                uiItem.OnItemRightMouseButtonClicked += HandleShowItemActions;
            }
        }

        public void UpdateData(int itemIndex, Sprite itemImage,
            int itemQuantity)
        {
            if (listOfUIItems.Count > itemIndex)
            {
                listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
            }
        }
        private void HandleShowItemActions(UIInventoryItem InventoryItemUI)
        {

        }

        private void HandleEndDrag(UIInventoryItem InventoryItemUI)
        {
            ResetDraggedItem();
        }

        private void HandleSwap(UIInventoryItem InventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(InventoryItemUI);
            if (index == -1)
            {
                return;
            }
            OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
            HandleItemSelection(InventoryItemUI);
        }

        private void ResetDraggedItem()
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
        }

        private void HandleBeginDrag(UIInventoryItem InventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(InventoryItemUI);
            if (index == -1)
                return;
            currentlyDraggedItemIndex = index;
            HandleItemSelection(InventoryItemUI);
            OnStartDragging?.Invoke(index);
        }

        public void CreateDraggedItem(Sprite sprite, int quantity)
        {
            mouseFollower.Toggle(true);
            mouseFollower.SetData(sprite, quantity);
        }

        private void HandleItemSelection(UIInventoryItem InventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(InventoryItemUI);
            if (index == -1)
                return;
            OnDescriptionRequested?.Invoke(index);

        }
        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
        }

        public void ResetSelection()
        {
            InventoryItemUIDescription.ResetDescription();
            DeselectAllItems();
        }

        private void DeselectAllItems()
        {
            foreach (UIInventoryItem item in listOfUIItems)
            {
                item.Deselect();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            ResetDraggedItem();
        }

        internal void UpdateDescription(int itemIndex, Sprite itemImage,
            string name, string description)
        {
            InventoryItemUIDescription.SetDescription
                (itemImage, name, description);
            DeselectAllItems();
            listOfUIItems[itemIndex].Selecte();
        }

        internal void ResetAllItems()
        {
            foreach (var item in listOfUIItems)
            {
                item.ResetData();
                item.Deselect ();
            }
        }
    }
}