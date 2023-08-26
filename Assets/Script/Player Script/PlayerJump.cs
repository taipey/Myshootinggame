using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 50.0f; // ジャンプ力
    public float groundCheckDistance = 30.0f;     // 地面判定用の距離
    public LayerMask groundMask;                  // 地面判定に使用するレイヤーマスク?
    private Rigidbody rb;
    private bool isGrounded = true;  // 地面に着地しているかどうかのフラグ

    private void Start()
    {
        TryGetComponent(out rb);
    }
    
    private void Update()
    {
        // 地面に着地している場合のみジャンプを実行
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // 地面に接触しているかを判定
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

        // Ray の可視化
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red);
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
