using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reparable : MonoBehaviour
{
    public ReparableState currentState;
    [SerializeField] private int m_RequiredBoltsToRepair;
    [HideInInspector] public int boltsNeededToRepair;
    public GameObject objectToToggle;
    public float repairPercentage;
    public Transform numberCanvas;
    private Transform camera;

    private void Awake()
    {
        ResetReparable();
    }

    private void Start()
    {
        camera = Camera.main.transform;
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
        if (objectToToggle != null)
        {
            objectToToggle.GetComponent<IToggleable>().Toggle();
        }

    }

    public void LateUpdate()
    {
        numberCanvas.LookAt(camera, Vector3.up);
    }
}

public enum ReparableState
{
    Broken,
    Repairing,
    Repaired
}
