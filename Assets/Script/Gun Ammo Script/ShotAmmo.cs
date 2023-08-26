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
        // �}�E�X���N���b�N�Ŕ���
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ammo = Instantiate(ammoPrefab, transform.position, Quaternion.identity);  // ��]����ύX

            // �e�̐�[�̌������e�̌����Ă�������ɍ��킹��
            ammo.transform.forward = AKM.transform.forward;

            // ��]�p�x�𒲐�����
            ammo.transform.eulerAngles = new Vector3(ammo.transform.eulerAngles.x + 90, ammo.transform.eulerAngles.y, ammo.transform.eulerAngles.z);

            Rigidbody ammoRB = ammo.GetComponent<Rigidbody>();
            ammoRB.AddForce(transform.forward *  shotSpeed);
            AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position);
        }
    }
}
