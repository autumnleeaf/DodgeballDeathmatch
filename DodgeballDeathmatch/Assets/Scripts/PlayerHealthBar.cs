using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class PlayerHealthBar : MonoBehaviour
{

    Image playerHealthBar;
    public float maxHealth = 100f;
    public static float healthPlayer;

    // Use this for initialization
    void Start()
    {
        playerHealthBar = GetComponent<Image>();
        healthPlayer = maxHealth;
    }

    // Update is called once per frame
    public void Update()
    {

        playerHealthBar.fillAmount = healthPlayer / maxHealth;
        //healthBar.fillAmount = healthEnemy / maxHealth;


    }
}