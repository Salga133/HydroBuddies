using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour {

    private Inventory inventory;
    private Transform slots;
    private Transform templates;

    private void Awake(){
        slots = transform.Find("slots");
        templates = templates.Find("templates");
    }
    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems(){
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;
        foreach (Item item in inventory.GetItemList()) {
           RectTransform itemSlotRectTransform = Instantiate(templates, slots).GetComponent<RectTransform>();
           itemSlotRectTransform.gameObject.SetActive(true);
           itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
           x++;
           if (x > 4) {
               x = 0;
               y++;
           }
        }
    }



}
