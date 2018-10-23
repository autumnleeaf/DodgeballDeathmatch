using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class EnemyHealthBar : MonoBehaviour {

    Image enemyHealthBar;
    public float maxHealth = 100f;
    public static float healthEnemy;

    // Use this for initialization
    void Start()
    {
        enemyHealthBar = GetComponent<Image>();
        healthEnemy = maxHealth;
    }

    // Update is called once per frame
    public void Update()
    {

        enemyHealthBar.fillAmount = healthEnemy / maxHealth;
        //healthBar.fillAmount = healthEnemy / maxHealth;


    }
}
