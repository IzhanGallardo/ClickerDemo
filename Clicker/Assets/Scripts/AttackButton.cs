using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public ControllerBehaviour controller;
    public Enemy enemy;

    float damageDealtPerClick;
    float damageCriticalApplied;
    float enemyTotalArmor;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<ControllerBehaviour>();
        enemy = FindObjectOfType<Enemy>();

        StartCoroutine(LateStart(0.01f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        enemyTotalArmor = enemy.armor - enemy.armor * controller.armorPenetrationTotal;
        
        var critical = Random.Range(0f, 1f);

        if (critical <= (controller.criticalClickChanceTotal/100))
        {
            damageCriticalApplied = controller.damagePerClickTotal * (controller.criticalClickDamageAmpliTotal/100);
        }
        else
        {
            damageCriticalApplied = controller.damagePerClickTotal;
        }

        damageDealtPerClick = damageCriticalApplied - enemyTotalArmor;

        if (damageDealtPerClick < 0) damageDealtPerClick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            enemy.currentHP -= damageDealtPerClick;
        }
    }
}
