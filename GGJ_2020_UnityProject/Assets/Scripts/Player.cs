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

    private void Awake()
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        m_PlayerRepair = GetComponent<PlayerRepair>();
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_PlayerInteractor = GetComponent<Interactor>();
        currentHealth = m_PlayerHealth;
    }

    public void TakeDamage(int damage)
    { 
    
    }
}

public enum PlayerState
{ 
    None,
    Cinematic,
    Enabled,
    Dead
}
