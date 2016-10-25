﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerHealth : NetworkBehaviour
{
    private int health = 100;
    public RectTransform healthBar;
    private bool shouldDie = false;
    public bool isDead = false;
    public int lives = 1;

    private bool isShield = false;
    private int shieldCount;

    [SyncVar (hook = "OnHealthChanged")] private int currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = health;
        lives = 5;
    }

    public void StartShield() {
        isShield = true;
        shieldCount = 3;
    }

    public void FinishShield() {
        isShield = false;
    }


    public void DeductHealth(int damage)
    {
        health -= damage;
    }

    public void TakeDamage(int amount)
    {
        if (!isServer) return;

        if (isShield){
            shieldCount -= 1;
            if (shieldCount <= 0)
                isShield = false;
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = health;
            RpcRespawn();
        }
    }

    void OnHealthChanged (int health)
    {
       healthBar.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            lives -= 1;
            transform.position = Vector3.zero;
        }
    }
}
