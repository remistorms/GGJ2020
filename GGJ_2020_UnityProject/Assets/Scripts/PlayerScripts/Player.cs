using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public PlayerState m_PlayerState;
    [SerializeField] private int m_PlayerHealth;
    private int currentHealth;
    [SerializeField] PlayerRepair m_PlayerRepair;
    [SerializeField] PlayerMovement m_PlayerMovement;
    [SerializeField] Interactor m_PlayerInteractor;
    [SerializeField] PlayerWeapon m_PlayerWeapon;

    private void Awake()
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        m_PlayerRepair = GetComponent<PlayerRepair>();
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_PlayerInteractor = GetComponent<Interactor>();
        m_PlayerWeapon = GetComponent<PlayerWeapon>();
        currentHealth = m_PlayerHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            //TODO death state
            Debug.Log("DIE");
        }
    }
}

public enum PlayerState
{ 
    None,
    Cinematic,
    Enabled,
    Dead
}
