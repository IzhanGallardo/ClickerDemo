using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tooltip : MonoBehaviour
{
    public Text tooltip;
    public ControllerBehaviour control;

    // Start is called before the first frame update
    void Start()
    {
        control = FindObjectOfType<ControllerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        tooltip = FindObjectOfType<Text>();

        if(tooltip.tag == "Tooltip")
        {
            tooltip.text = gameObject.GetComponent<Item>().description;
        }

    }

    public void OnMouseDown()
    {
        if(SceneManager.GetActiveScene().name == "Inventory" && !gameObject.GetComponent<Item>().Equals(control.stageLoot))
        {
            control.addToInventory(gameObject.GetComponent<Item>());
        }
    }


}
