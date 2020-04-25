﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public float totalHealth;
    public float currentHealth;
    public float healthLevel;
    public float meleeAttackDamage;
    public Slider slider;

    [SerializeField] private LayerMask lavaLayerMask;

    private PlayerMovement playerMovement;
    private AnimatorController animatorController;
    private EdgeCollider2D edgeCollider2D;

    public void Start()
    {
        currentHealth = totalHealth * healthLevel;
        animatorController = GetComponent<AnimatorController>();
        playerMovement = GetComponent<PlayerMovement>();
        edgeCollider2D = GetComponent<EdgeCollider2D>();
    }

    public void Update()
    {
        if (IsOnLava()) {
            Debug.Log("Buring");
            currentHealth -= 40 * Time.deltaTime;
            UpdateHealthSlider();
        }
    }

    public float GetMeleeAttackDamage() {
        return meleeAttackDamage;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeavyBandit" && other.gameObject.GetComponent<BanditController>().GetIsAttacking())
        {
            currentHealth -= other.gameObject.GetComponent<BanditController>().GetDamage() * Time.deltaTime;
            UpdateHealthSlider();
            if (currentHealth <= 0)
            {
                animatorController.Die();
                playerMovement.Die();
            }
        }
    }

    public void Heal(float healValue) {
        currentHealth += healValue;
        if (currentHealth > 100)
            currentHealth = 100;
        UpdateHealthSlider();
    }

    public void UpdateHealthSlider()
    {
        slider.value = currentHealth / totalHealth;
    }

    public bool IsOnLava() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(edgeCollider2D.bounds.center, edgeCollider2D.bounds.size, 0f,
        Vector2.down, .05f, lavaLayerMask);
        return raycastHit2D.collider != null;
    }

}
