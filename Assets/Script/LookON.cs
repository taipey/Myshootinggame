using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookON : MonoBehaviour
{
    private float lockRange = 100; // ���R�ɐݒ�
    public Image aimImage;
    private Color originalColor;

    void Start()
    {
        // �J�[�\�����\���ɂ���B
        Cursor.lockState = CursorLockMode.Locked;

        originalColor = aimImage.color;
    }

    
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, lockRange))
        {
            GameObject target = hit.collider.gameObject;

            if (target.CompareTag("Target"))
            {
                // �ԐF�ɕύX
                aimImage.color = Color.red;
            }
            else
            {
                aimImage.color = originalColor;
            }
        }
    }
}
