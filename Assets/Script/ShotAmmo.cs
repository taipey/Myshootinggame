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
            GameObject ammo = Instantiate(ammoPrefab, transform.position, Quaternion.identity);  // 回転情報を変更

            // 弾の先端の向きを銃の向いている方向に合わせる
            ammo.transform.forward = AKM.transform.forward;

            // 回転角度を調整する
            ammo.transform.eulerAngles = new Vector3(ammo.transform.eulerAngles.x + 90, ammo.transform.eulerAngles.y, ammo.transform.eulerAngles.z);

            Rigidbody ammoRB = ammo.GetComponent<Rigidbody>();
            ammoRB.AddForce(transform.forward *  shotSpeed);
            AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position);
        }
    }
}
