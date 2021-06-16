using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageCountController : MonoBehaviour
{
    [SerializeField]
    public Inventory inventoryScript;

    public Text garbageCountDisplay;
    static int garbageCount = 0;
    static int totalGarbage;


    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnedItems = GameObject.Find("SpawnedItems");
        totalGarbage = spawnedItems.transform.childCount;
        GameObject totalItemsInInvetory = GameObject.Find("TotalItems");

        GameObject inventoryUI = GameObject.Find("InventoryUI");
        UI_Inventory uiInventory = inventoryUI.GetComponent<UI_Inventory>();
        garbageCount = uiInventory.inventoryLength();
        garbageCountDisplay.text = string.Format("Garbage: {0}/{1}", garbageCount, totalGarbage);
    }

    // Update is called once per frame
    void Update()
    {
        if (garbageCount == totalGarbage) {
            garbageCountDisplay.text = "You've Finished The Game";
        } else {
            GameObject inventoryUI = GameObject.Find("InventoryUI");
            UI_Inventory uiInventory = inventoryUI.GetComponent<UI_Inventory>();
            garbageCount = uiInventory.inventoryLength();
            garbageCountDisplay.text = string.Format("Garbage: {0}/{1}", garbageCount, totalGarbage);
        }

    }
}
