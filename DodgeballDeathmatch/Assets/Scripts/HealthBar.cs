using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using DodgeballDeathmatch;

public class HealthBar : MonoBehaviour
{

    Image HealthBarImage;
    Player Player;
    private string PlayerType;
    private float MaxHealth;
    private bool PlayerSet;

    // Use this for initialization
    void Start()
    {
        HealthBarImage = GetComponent<Image>();

        string healthBarName = ToString();
        PlayerType = healthBarName.Replace("HealthBar", "?");
        PlayerType = PlayerType.Substring(0, PlayerType.IndexOf("?", StringComparison.CurrentCulture));
       
        Player = new Player(Vector3.zero);
        MaxHealth = Player.Health;
    }

    // Updates HealthBar Image
    void Update()
    {
        if(!PlayerSet)
        {
            Player player = GameObject.Find(PlayerType).GetComponent<PlayerController>().Player;
            if(!player.Health.Equals(null))
            {
                PlayerSet = true;
                Player = player;
                MaxHealth = Player.Health;
            }
            else 
            {
                GameManager.instance.GameOver(0);
            }
        }

        HealthBarImage.fillAmount = Player.Health / MaxHealth;
    }
}