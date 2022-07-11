using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNameText : MonoBehaviour
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = enemy.EnemyName;
    }
}
