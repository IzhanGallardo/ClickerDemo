using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    public ControllerBehaviour control;
    public Item item1, item2, item3, item4, item5, lootItem;

    // Start is called before the first frame update
    void Start()
    {
        control = FindObjectOfType<ControllerBehaviour>();

        item1 = null;
        item2 = null;
        item3 = null;
        item4 = null;
        item5 = null;
        lootItem = null;

        control.addIdentifiers();
        updateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateInventory()
    {
        if (control.inventory[0] != null)
        {
            Destroy(item1);
            item1 = Instantiate(control.inventory[0], new Vector3(-8, 2.5f, 0), Quaternion.identity);
        }
        if (control.inventory[1] != null)
        {
            Destroy(item2);
            item2 =Instantiate(control.inventory[1], new Vector3(-5.5f, 2.5f, 0), Quaternion.identity);
        }
        if (control.inventory[2] != null)
        {
            Destroy(item3);
            item3 = Instantiate(control.inventory[2], new Vector3(-3, 2.5f, 0), Quaternion.identity);
        }
        if (control.inventory[3] != null)
        {
            Destroy(item4);
            item4 = Instantiate(control.inventory[3], new Vector3(-4.25f, -1, 0), Quaternion.identity);
        }
        if (control.inventory[4] != null)
        {
            Destroy(item5);
            item5 = Instantiate(control.inventory[4], new Vector3(-6.75f, -1, 0), Quaternion.identity);
        }

        if(control.stageLoot != null)
        {
            Destroy(lootItem);
            lootItem = Instantiate(control.stageLoot, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }

    public void inventoryNotFull()
    {
        if(control.inventory[0] == null || control.inventory[1] == null || control.inventory[2] == null || control.inventory[3] == null || control.inventory[4] == null)
        {
            control.addToInventoryWithSpace();
        }
    }
}
