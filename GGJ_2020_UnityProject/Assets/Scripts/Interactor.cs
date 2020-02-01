using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float m_InteractionRadius;
    private Collider[] collidersInRange;
    private List<IInteractable> interactablesInRange;
    IInteractable currentInteractable = null;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Interact();
        }
    }

    private void Interact()
    {
        GetInteractablesInRange();
        if (interactablesInRange.Count > 0)
        {
            interactablesInRange[0].Interact(this);
        }
    }

    //Gets interactables in range of the action sphere
    private void GetInteractablesInRange()
    {
        interactablesInRange = new List<IInteractable>();
        collidersInRange = Physics.OverlapSphere(transform.position + transform.forward * .5f + transform.up * 0.5f, m_InteractionRadius);

        for (int i = 0; i < collidersInRange.Length; i++)
        {
            if (collidersInRange[i].GetComponent<IInteractable>() != null)
            {
                interactablesInRange.Add(collidersInRange[i].GetComponent<IInteractable>());
            }
        }
        if (interactablesInRange.Count > 0)
        {
            currentInteractable = interactablesInRange[0];
        }

    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position + transform.forward * .5f + transform.up * 0.5f, m_InteractionRadius);
    }
}
