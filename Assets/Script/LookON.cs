using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookON : MonoBehaviour
{
    private float lockRange = 100; // 自由に設定
    public Image aimImage;
    private Color originalColor;

    void Start()
    {
        // カーソルを非表示にする。
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
                // 赤色に変更
                aimImage.color = Color.red;
            }
            else
            {
                aimImage.color = originalColor;
            }
        }
    }
}
