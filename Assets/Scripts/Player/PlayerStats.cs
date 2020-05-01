using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

    public float totalHealth;
    static public float currentHealth = 100;
    public float meleeAttackDamage;
    public Slider slider;

    [SerializeField] private LayerMask lavaLayerMask;

    private PlayerMovement playerMovement;
    private AnimatorController animatorController;
    private EdgeCollider2D edgeCollider2D;

    public void Start()
    {
        UpdateHealthSlider();
        animatorController = GetComponent<AnimatorController>();
        playerMovement = GetComponent<PlayerMovement>();
        edgeCollider2D = GetComponent<EdgeCollider2D>();
        currentHealth = 100;
    }

    public void Update()
    {
        if (IsOnLava()) {
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
        if (currentHealth > totalHealth)
            currentHealth = totalHealth;
        UpdateHealthSlider();
    }

    public void UpdateHealthSlider()
    {
        Debug.Log(currentHealth);
        Debug.Log(totalHealth);
        Debug.Log(currentHealth / totalHealth);
        slider.value = currentHealth / totalHealth;
    }

    public bool IsOnLava() {

        RaycastHit2D raycastHit2D = Physics2D.BoxCast(edgeCollider2D.bounds.center, edgeCollider2D.bounds.size, 0f,
        Vector2.down, .05f, lavaLayerMask);
        Debug.Log(raycastHit2D.collider != null);
        return raycastHit2D.collider != null;
    }

}
