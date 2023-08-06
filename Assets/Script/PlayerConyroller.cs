using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConyroller : MonoBehaviour
{
    public float walkSpeed;
    private float speed;
    private Vector3 movement;
    private CharacterController controller;

    private int clickCount = 0;
    public float runSpeed;
    private Vector3 moveDir = Vector3.zero;
    private float gravity = 3f;

    public float jumpPower;
    public AudioClip jumpSound;
    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();

        controller = GetComponent<CharacterController>();

        speed = walkSpeed;
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        movement = new Vector3(moveH, 0, moveV);

        Vector3 desiredMove = Camera.main.transform.forward * movement.z + Camera.main.transform.right * movement.x;
        moveDir.x = desiredMove.x * 3f;
        moveDir.z = desiredMove.z * 3f;
        moveDir.y -= gravity * Time.deltaTime; // 疑似重力の実装

        controller.Move(movement * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.W))
        {
            // clickCountを１ずつカウントアップ
            clickCount += 1;

            Invoke("ResetCount", 0.3f);
        }

        if (Input.GetKeyUp(KeyCode.W)) // wキーから指を離したら移動速度を「歩く」に戻す。
        {
            speed = walkSpeed;
        }

        if (controller.isGrounded)
        {
            moveDir.y = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDir.y = jumpPower;
                audioS.clip = jumpSound;
                audioS.Play();
            }
        }
    }

    void ResetCount()
    {
        // clickCountが２ではない場合、
        if (clickCount != 2)
        {
            // 0に戻す
            clickCount = 0;
            return;
        }
        else // clickCountが２の時（0.3秒以内にｗキーのダブルクリックが成功した場合）
        {
            clickCount = 0;

            // 移動速度をランにする。
            speed = runSpeed;
        }
    }
}
