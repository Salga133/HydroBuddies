using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    public int inventoryLength() 
    {
        return inventory.itemList.Count;
    }

    private void Awake() 
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(Inventory inventory) 
    {
        this.inventory = inventory;

        this.inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) 
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() 
    {
        foreach (Transform child in itemSlotContainer) 
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 60f;
        float indentedPositionX = 100f;
        float indentedPositionY = 10f;
        float factoredY = 0.7f;
        foreach (Item item in inventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                inventory.UseItem(item);
            };
            
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
                inventory.RemoveItem(item);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize + indentedPositionX, y * itemSlotCellSize * factoredY + indentedPositionY);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI textmeshPro = itemSlotRectTransform.Find("Text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1) {
                textmeshPro.SetText("{0}", item.amount);
            } else {
                textmeshPro.SetText("");
            }
            x++;
            if (x > 3) 
            {
                x = 0;
                y--;
            }
        }
    }
}