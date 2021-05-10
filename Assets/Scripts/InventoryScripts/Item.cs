using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public enum ItemType {
        Trash,
        Paper,
        Trashcan,
    }

    public ItemType itemType;
    public int amount;

}

