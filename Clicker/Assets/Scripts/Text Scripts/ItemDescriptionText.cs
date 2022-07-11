using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionText : MonoBehaviour
{
    public ControllerBehaviour controller;
    Item item;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<ControllerBehaviour>();
        item = Instantiate(controller.stageLoot, new Vector3(-2f, 0f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = item.description;
    }
}
