using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ControllerBehaviour controller;

    public string itemName;
    public float identif;

    public float damagePerClick;
    public float damagePerSecond;
    public float damagePerClickPrcntg;
    public float damagePerSecondPrcntg;
    public float armor;
    public float armorPenetration;
    public float maxHP;
    public float healingPerSecond;
    public float vampirism;
    public float criticalClickChance;
    public float criticalClickDamageAmpli;

    public int rarity;
    public string rarityText;
    public float rarityMult;

    public Vector3 itemScale;

    public string description;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = itemScale;

        if (rarity == 0)
        {
            rarityMult = 1;
        } else if (rarity == 1)
        {
            rarityMult = 2;
        } else if (rarity == 2)
        {
            rarityMult = 5;
        } else if (rarityMult == 3)
        {
            rarityMult = 15;
        }

        updateTraits();

        switch (rarity)
        {
            case (0):
                rarityText = "Common";
                break;
            case (1):
                rarityText = "Uncommon";
                break;
            case (2):
                rarityText = "Epic";
                break;
            case (3):
                rarityText = "Legendary";
                break;
            default:
                rarityText = "";
                break;
        }

        description = itemName.ToUpper() + "\n(" + rarityText + ")" + "\n \n";
        addDescription();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addDescription()
    {
        if (damagePerClick != 0)
        {
            description += "Damage/Click: " + damagePerClick.ToString() + "\n";
        }
        if (damagePerSecond != 0)
        {
            description += "Damage/second: " + damagePerSecond.ToString() + "\n";
        }
        if (damagePerClickPrcntg != 0)
        {
            description += "Damage/Click %: " + damagePerClickPrcntg.ToString() + "%" + "\n";
        }
        if (damagePerSecondPrcntg != 0)
        {
            description += "Damage/second %: " + damagePerSecondPrcntg.ToString() + "%" + "\n";
        }
        if (armor != 0)
        {
            description += "Armor: " + armor.ToString() + "\n";
        }
        if (armorPenetration != 0)
        {
            description += "Armor Pen.: " + armorPenetration.ToString() + "%" + "\n";
        }
        if (maxHP != 0)
        {
            description += "HP: " + maxHP.ToString() + "\n";
        }
        if (healingPerSecond != 0)
        {
            description += "Healing/second: " + healingPerSecond.ToString() + "\n";
        }
        if (vampirism != 0)
        {
            description += "Vampirism: " + vampirism.ToString() + "%" + "\n";
        }
        if (criticalClickChance != 0)
        {
            description += "Critical Chance: " + criticalClickChance.ToString() + "%" + "\n";
        }
        if (criticalClickDamageAmpli != 0)
        {
            description += "Critical Amp.: " + criticalClickDamageAmpli.ToString() + "%" + "\n";
        }
    }

    void updateTraits()
    {
        damagePerClick *= rarityMult;
        damagePerSecond *= rarityMult;
        damagePerClickPrcntg *= rarityMult;
        damagePerSecondPrcntg *= rarityMult;
        armor *= rarityMult;
        armorPenetration *= rarityMult;
        maxHP *= rarityMult;
        healingPerSecond *= rarityMult;
        vampirism *= rarityMult;
        criticalClickChance *= rarityMult;
        criticalClickDamageAmpli *= rarityMult;
    }
}
