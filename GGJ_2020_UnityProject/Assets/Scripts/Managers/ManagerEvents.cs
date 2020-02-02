using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManagerEvents : MonoBehaviour
{
    public static ManagerEvents instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
