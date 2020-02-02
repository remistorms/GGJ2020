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
    public bool isInvencible = false;
    public MeshRenderer playerMesh;

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
        if (!isInvencible)
        {
            StartCoroutine(_TakeDamage(damage));
        }
    }

    IEnumerator _TakeDamage(int damage)
    {
        isInvencible = true;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("DIE");
            Die();
        }

        for (int i = 0; i < 5; i++)
        {
            playerMesh.enabled = false;
            yield return new WaitForSeconds(0.2f);
            playerMesh.enabled = true;
        }
        isInvencible = false;
    }

    public void Die()
    {
        m_PlayerMovement.enabled = false;
        ManagerUI.instance.SwapScren(ScreenType.GameOverScreen);
    }
}

public enum PlayerState
{ 
    None,
    Cinematic,
    Enabled,
    Dead
}
