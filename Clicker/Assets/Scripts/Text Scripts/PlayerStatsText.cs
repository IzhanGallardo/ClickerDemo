using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsText : MonoBehaviour
{
    public ControllerBehaviour controller;
    string stats;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<ControllerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        stats = "HP: " + controller.currentHP.ToString() + "/" + controller.maxHPTotal.ToString() + "\n" +
                "Damage/Click: " + controller.damagePerClickTotal.ToString() + "\n" +
                "Damage/sec: " + controller.damagePerSecondTotal.ToString() + "\n" +
                "Armor: " + controller.armorTotal.ToString() + "\n" +
                "Armor Pen.: " + controller.armorPenetrationTotal.ToString() + "%" + "\n" +
                "Healing/sec: " + controller.healingPerSecondTotal.ToString() + "\n" +
                "Vampirism: " + controller.vampirismTotal.ToString() + "%" + "\n" +
                "Critical Chance: " + controller.criticalClickChanceTotal.ToString() + "%" + "\n" +
                "Critical Amp.: " + controller.criticalClickDamageAmpliTotal.ToString() + "%" + "\n";
        gameObject.GetComponent<Text>().text = stats;
    }
}
