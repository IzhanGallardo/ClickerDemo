using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatsText : MonoBehaviour
{
    public Enemy enemy;
    string stats;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        stats = "HP: " + enemy.currentHP.ToString() + "/" + enemy.maxHP.ToString() + "\n" +
                "Damage/sec: " + enemy.damage.ToString() + "\n" +
                "Armor: " + enemy.armor.ToString() + "\n";
        gameObject.GetComponent<Text>().text = stats;

    }
}
