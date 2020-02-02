using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public PlayerState m_PlayerState;
    [SerializeField] private int m_PlayerHealth;
    private int currentHealth;
    public PlayerRepair m_PlayerRepair;
    public PlayerMovement m_PlayerMovement;
    public Interactor m_PlayerInteractor;
    public PlayerWeapon m_PlayerWeapon;

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

        m_PlayerRepair.enabled = false;
        m_PlayerInteractor.enabled = false;
        m_PlayerWeapon.enabled = false;
        m_PlayerMovement.enabled = false;
        m_PlayerRepair.m_PlayerBolts.Value = 0;
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
