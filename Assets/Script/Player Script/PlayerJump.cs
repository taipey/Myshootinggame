using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 50.0f; // �W�����v��
    public float groundCheckDistance = 30.0f;     // �n�ʔ���p�̋���
    public LayerMask groundMask;                  // �n�ʔ���Ɏg�p���郌�C���[�}�X�N?
    private Rigidbody rb;
    private bool isGrounded = true;  // �n�ʂɒ��n���Ă��邩�ǂ����̃t���O

    private void Start()
    {
        TryGetComponent(out rb);
    }
    
    private void Update()
    {
        // �n�ʂɒ��n���Ă���ꍇ�̂݃W�����v�����s
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // �n�ʂɐڐG���Ă��邩�𔻒�
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

        // Ray �̉���
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red);
    }

    /// <summary>
    /// �W�����v
    /// </summary>
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
