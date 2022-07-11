
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteLoot : MonoBehaviour
{
    public ControllerBehaviour controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<ControllerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = controller.stageLoot.GetComponent<SpriteRenderer>().sprite;
    }
}
