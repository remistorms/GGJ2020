using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepair : MonoBehaviour
{
    public bool isReparing = false;
    [SerializeField] private IntVariable m_PlayerBolts;
    [SerializeField] private float m_RepairRadius;

    private PlayerMovement playerMovement;
    private Collider[] collidersInRange;
    private List<Reparable> reparablesInRange;
    private Reparable currenReparable;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            playerMovement.enabled = false;
            isReparing = true;
            GetReparablesInRange();
            StartCoroutine(RepairRoutine());
        }


        if (Input.GetButtonUp("Fire2"))
        {
            reparablesInRange.Clear();
            playerMovement.enabled = true;
            isReparing = false;
            if (currenReparable != null && currenReparable.currentState == ReparableState.Repairing)
            {
                currenReparable.currentState = ReparableState.Broken;
            }
            currenReparable = null;
        }
    }

    IEnumerator RepairRoutine()
    {
        if (reparablesInRange.Count == 0)
            yield break;

        while(isReparing && m_PlayerBolts.Value > 0 && currenReparable.currentState != ReparableState.Repaired )
        {
            reparablesInRange[0].Repair();
            m_PlayerBolts.Value--;
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

    //Gets reparables in range of the action sphere
    private void GetReparablesInRange()
    {
        reparablesInRange = new List<Reparable>();
        collidersInRange = Physics.OverlapSphere(transform.position + transform.forward * .5f + transform.up * 0.5f, m_RepairRadius);

        for (int i = 0; i < collidersInRange.Length; i++)
        {
            if (collidersInRange[i].GetComponent<Reparable>() != null)
            {
                reparablesInRange.Add(collidersInRange[i].GetComponent<Reparable>());
            }
        }
        if (reparablesInRange.Count > 0)
        {
            currenReparable = reparablesInRange[0];
        }

    }

    public void AddBolts(int boltsToAdd)
    {
        m_PlayerBolts.Value += boltsToAdd;
    }

    public void RemoveBolts(int boltsToRemove)
    {
        m_PlayerBolts.Value -= boltsToRemove;
    }


    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position + transform.forward * .5f + transform.up * 0.5f, m_RepairRadius);
    }
}
