using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBolts : MonoBehaviour, IInteractable
{
    public int lootBolts;

    public void Interact(Interactor interactor)
    {
        interactor.GetComponent<PlayerRepair>().AddBolts(lootBolts);
        Destroy(gameObject);
    }
}
