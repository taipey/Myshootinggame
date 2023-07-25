using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAmmo : MonoBehaviour
{
    public GameObject AKM;
    public GameObject ammoPrefab;
    public AudioClip shotSound;
    public float shotSpeed;

    void Update()
    {
        // マウス左クリックで発射
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ammo = Instantiate(ammoPrefab, transform.position, AKM.transform.localRotation);
            Rigidbody ammoRB = ammo.GetComponent<Rigidbody>();
            ammoRB.AddForce(transform.forward *  shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position);
        }
    }
}
