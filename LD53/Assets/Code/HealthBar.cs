using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject playerBody;

    [Header("Variables")]
    public int maxHealth = 100;
    public Vector2 offset;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    private void LateUpdate()
    {
        transform.position = playerBody.transform.position + new Vector3 (offset.x, offset.y, transform.position.z);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}
