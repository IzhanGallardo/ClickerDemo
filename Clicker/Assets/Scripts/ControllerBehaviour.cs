using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerBehaviour : MonoBehaviour
{
    public Item[] lootableItems = new Item[13];
    public Item[] inventory = new Item[5];
    public Item stageLoot;

    public Enemy[] enemies = new Enemy[19]; 

    public float damagePerClickBase;
    public float maxHpBase;
    public float currentHP;

    public float damagePerClickTotal;
    public float damagePerSecondTotal;
    public float damagePerClickPrcntgTotal;
    public float damagePerSecondPrcntgTotal;
    public float armorTotal;
    public float armorPenetrationTotal;
    public float maxHPTotal;
    public float healingPerSecondTotal;
    public float vampirismTotal;
    public float criticalClickChanceTotal;
    public float criticalClickDamageAmpliTotal;

    public int enemyStage;

    public float[] itemRarityPrcntg;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 

        if(SceneManager.GetActiveScene().name == "Gameplay")
        {
            updateItemRarity();
            Instantiate(enemies[Random.Range(0, 18)], new Vector3(0, 0, 1), Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<ControllerBehaviour>().Length > 1)
        {
            Destroy(gameObject);
        }

        damagePerClickBase = 1;
        maxHpBase = 10;
        enemyStage = 1;
        updatePlayer();

        itemRarityPrcntg = new float[4];

        updateItemRarity();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enemyDead()
    {
        generateLoot();
        enemyStage++;
        SceneManager.LoadScene("LootCollect");
    }

    void generateLoot()
    {
        var randomLoot = Random.Range(0f, 1f);
        var rarity = 0;
        var rarity0 = itemRarityPrcntg[0];
        var rarity1 = rarity0 + itemRarityPrcntg[1];
        var rarity2 = rarity1 + itemRarityPrcntg[2];

        if (randomLoot < rarity0)
        {
            rarity = 0;
        }
        else if (randomLoot >= rarity0 && randomLoot < rarity1)
        {
            rarity = 1;
        }
        else if (randomLoot >= rarity1 && randomLoot < rarity2)
        {
            rarity = 2;
        }
        else if (randomLoot >= rarity2)
        {
            rarity = 3;
        }

        stageLoot = lootableItems[Random.Range(0, lootableItems.Length-1)];
        stageLoot.rarity = rarity;
    }

    public void updatePlayer()
    {
        damagePerClickTotal = damagePerClickBase;
        damagePerSecondTotal = 0;
        damagePerClickPrcntgTotal = 0;
        damagePerSecondPrcntgTotal = 0;
        armorTotal = 0;
        armorPenetrationTotal = 0;
        maxHPTotal = maxHpBase;
        healingPerSecondTotal = 0;
        vampirismTotal = 0;
        criticalClickChanceTotal = 0;
        criticalClickDamageAmpliTotal = 0;

        for (int i=0; i<inventory.Length; i++)
        {
            if (inventory[i] != null){
                damagePerClickTotal += inventory[i].damagePerClick;
                damagePerSecondTotal += inventory[i].damagePerSecond;
                damagePerClickPrcntgTotal += inventory[i].damagePerClickPrcntg;
                damagePerSecondPrcntgTotal += inventory[i].damagePerSecondPrcntg;
                armorTotal += inventory[i].armor;
                armorPenetrationTotal += inventory[i].armorPenetration;
                maxHPTotal += inventory[i].maxHP;
                healingPerSecondTotal += inventory[i].healingPerSecond;
                vampirismTotal += inventory[i].vampirism;
                criticalClickChanceTotal += inventory[i].criticalClickChance;
                criticalClickDamageAmpliTotal += inventory[i].criticalClickDamageAmpli;
            }
        }

        if (criticalClickChanceTotal > 1) criticalClickChanceTotal = 1; 
        if (armorPenetrationTotal > 1) armorPenetrationTotal = 1;

        damagePerClickTotal += damagePerClickTotal * (damagePerClickPrcntgTotal/100);
        damagePerSecondTotal += damagePerSecondTotal * (damagePerSecondPrcntgTotal/100);

        currentHP = maxHPTotal;
    }

    public void updateItemRarity()
    {
        if(enemyStage == 1)
        {
            itemRarityPrcntg[0] = 1;
            itemRarityPrcntg[1] = 0;
            itemRarityPrcntg[2] = 0;
            itemRarityPrcntg[3] = 0;
        } else if (enemyStage >= 2 && enemyStage <= 11)
        {
            itemRarityPrcntg[0] = 1 - 0.05f * (enemyStage - 1);
            itemRarityPrcntg[1] = 0.04f * (enemyStage - 1);
            itemRarityPrcntg[2] = 0.01f * (enemyStage - 1);
            itemRarityPrcntg[3] = 0;
        } else if (enemyStage >= 12 && enemyStage <= 21)
        {
            itemRarityPrcntg[0] = 0.5f - 0.03f * (enemyStage - 11);
            itemRarityPrcntg[1] = 0.4f + 0.01f * (enemyStage - 11);
            itemRarityPrcntg[2] = 0.1f + 0.017f * (enemyStage - 11);
            itemRarityPrcntg[3] = 0.003f * (enemyStage - 11);
        } else if (enemyStage >= 22 && enemyStage <= 31)
        {
            itemRarityPrcntg[0] = 0.2f - 0.01f * (enemyStage - 21);
            itemRarityPrcntg[1] = 0.5f - 0.02f * (enemyStage - 21);
            itemRarityPrcntg[2] = 0.27f + 0.023f * (enemyStage - 21);
            itemRarityPrcntg[3] = 0.03f + 0.007f * (enemyStage - 21);
        } else if (enemyStage >= 32 && enemyStage <= 41)
        {
            itemRarityPrcntg[0] = 0.1f - 0.01f * (enemyStage - 31);
            itemRarityPrcntg[1] = 0.3f - 0.01f * (enemyStage - 31);
            itemRarityPrcntg[2] = 0.5f + 0.007f * (enemyStage - 31);
            itemRarityPrcntg[3] = 0.1f + 0.013f * (enemyStage - 31);
        } else if (enemyStage >= 42 && enemyStage <= 51)
        {
            itemRarityPrcntg[0] = 0;
            itemRarityPrcntg[1] = 0.2f - 0.02f * (enemyStage - 41);
            itemRarityPrcntg[2] = 0.57f + 0.003f * (enemyStage - 41);
            itemRarityPrcntg[3] = 0.23f + 0.017f * (enemyStage - 41);
        }
        else if (enemyStage >= 52)
        {
            itemRarityPrcntg[0] = 0;
            itemRarityPrcntg[1] = 0;
            itemRarityPrcntg[2] = 0.6f;
            itemRarityPrcntg[3] = 0.4f;
        }
    }

    public void getAttacked(float enemyDamage)
    {
        var damageRecived = enemyDamage - armorTotal;
        if (damageRecived < 0) damageRecived = 0;

        currentHP -= damageRecived;

        if(currentHP <= 0)
        {
            currentHP = 0;
            playerDie();
        }
    }

    public void playerDie()
    {
        PlayerPrefs.SetInt("currentStage", enemyStage);
        Destroy(gameObject);
        SceneManager.LoadScene("EndScreen");
    }

    public void addToInventory(Item item)
    {
        Item auxItem;
        var found = false;
        var iter = 0;

        while (!found && iter < inventory.Length)
        {
            if (inventory[iter].identif == item.identif)
            {
                auxItem = inventory[iter];
                inventory[iter] = stageLoot;
                stageLoot = auxItem;
                found = true;
                SceneManager.LoadScene("Inventory");
            }
            iter++;
        }
        updatePlayer();
    }

    public void addToInventoryWithSpace()
    {
        var found = false;
        var i = 0;
        while (i < inventory.Length && !found)
        {
            if (inventory[i] == null)
            {
                inventory[i] = stageLoot;
                found = true;
            }
            i++;
        }
        updatePlayer();
    }

    public void addIdentifiers()
    {
        foreach(Item item in inventory)
        { 
            if(item != null)
            {
                item.identif = Random.Range(0f, 10f);
            }
        }
    }
}
