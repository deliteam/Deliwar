using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Action OnDead;
    [Header("Game Objects")] [SerializeField]
    Slider healthSlider;

    [SerializeField] GameObject playerBody;

    [Header("Variables")] public int maxHealth = 100;
    public Vector2 offset;

    public int CurrentHealth { private set; get; }

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        CurrentHealth = maxHealth;
    }

    private void LateUpdate()
    {
        if(playerBody != null)
        transform.position = playerBody.transform.position + new Vector3(offset.x, offset.y, transform.position.z);
    }

    public void SetDamage(int damage)
    {
        CurrentHealth = CurrentHealth - damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnDead?.Invoke();
			SceneManager.LoadScene("Menu_GameOver");
        }
        healthSlider.value = CurrentHealth;
    }
}