using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reparable : MonoBehaviour
{
    public ReparableState currentState;
    [SerializeField] private int m_RequiredBoltsToRepair;
    [HideInInspector] public int boltsNeededToRepair;
    public float repairPercentage;

    private void Awake()
    {
        ResetReparable();
    }

    public void Repair()
    {
        currentState = ReparableState.Repairing;
        boltsNeededToRepair--;

        repairPercentage = 1.0f - ((float)boltsNeededToRepair / (float)m_RequiredBoltsToRepair);

        if (boltsNeededToRepair <= 0)
        {
            currentState = ReparableState.Repaired;
            Repaired();
        }
    }

    private void ResetReparable()
    {
        boltsNeededToRepair = m_RequiredBoltsToRepair;
    }

    public void Repaired()
    {
        Debug.Log("Repaired");
    }
}

public enum ReparableState
{
    Broken,
    Repairing,
    Repaired
}
