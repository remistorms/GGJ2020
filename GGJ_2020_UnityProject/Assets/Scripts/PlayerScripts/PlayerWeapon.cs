using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject m_BulletPrefab;
    [SerializeField] private Transform m_BulletSpawnPoint;
    [SerializeField] IntVariable m_PlayerBolts;
    public GameObject weaponMesh;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (m_PlayerBolts.Value > 0)
        {
            GameObject bullet = Instantiate(m_BulletPrefab, m_BulletSpawnPoint) as GameObject;
            bullet.transform.localPosition = Vector3.zero;
            bullet.transform.localRotation = Quaternion.Euler(Vector3.zero);
            bullet.transform.SetParent(null);
            m_PlayerBolts.Value--;
        }

    }

    private void OnEnable()
    {
        weaponMesh.SetActive(true);
    }
}
