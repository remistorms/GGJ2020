using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBullet : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_Damage;

    private void Update()
    {
        transform.Translate(this.transform.forward * Time.deltaTime * m_Speed, Space.World);    
    }

    private void Awake()
    {
        Destroy(gameObject, 5.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamageable>() != null && other.tag != "Player")
        {
            other.GetComponent<IDamageable>().TakeDamage(m_Damage);
            Debug.Log("bullet hit " + other.gameObject.name);
        }

        Destroy(gameObject);
    }
}
