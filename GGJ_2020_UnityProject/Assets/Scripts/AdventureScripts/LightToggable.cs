using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggable : MonoBehaviour, IToggleable
{
    public MeshRenderer meshRenderer;

    public void Toggle()
    {
        meshRenderer.material.color = Color.green;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
