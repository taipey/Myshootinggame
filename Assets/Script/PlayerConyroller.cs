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
        moveDir.y -= gravity * Time.deltaTime; // �^���d�͂̎���

        controller.Move(movement * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.W))
        {
            // clickCount���P���J�E���g�A�b�v
            clickCount += 1;

            Invoke("ResetCount", 0.3f);
        }

        if (Input.GetKeyUp(KeyCode.W)) // w�L�[����w�𗣂�����ړ����x���u�����v�ɖ߂��B
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
        // clickCount���Q�ł͂Ȃ��ꍇ�A
        if (clickCount != 2)
        {
            // 0�ɖ߂�
            clickCount = 0;
            return;
        }
        else // clickCount���Q�̎��i0.3�b�ȓ��ɂ��L�[�̃_�u���N���b�N�����������ꍇ�j
        {
            clickCount = 0;

            // �ړ����x�������ɂ���B
            speed = runSpeed;
        }
    }
}
