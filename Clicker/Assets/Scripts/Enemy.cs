using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ControllerBehaviour controller;

    public string EnemyName;
    public float maxHP;
    public float currentHP;
    public float armor;
    public float damage;

    public Vector3 enemyScale;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<ControllerBehaviour>();

        gameObject.transform.localScale = enemyScale;

        updateStats();

        currentHP = maxHP;

        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            controller.enemyDead();
        }
    }

    public void updateStats()
    {
        
        if (controller.enemyStage > 1)
        {
            maxHP = (maxHP + 1) * (Mathf.Pow(1.2f,controller.enemyStage));
            armor = (armor + 0.2f) * (Mathf.Pow(1.3f, controller.enemyStage));
            damage = (damage -0.2f) * (Mathf.Pow(1.4f, controller.enemyStage));
        }
    }

    IEnumerator attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            controller.getAttacked(damage);
        }
    }
}
