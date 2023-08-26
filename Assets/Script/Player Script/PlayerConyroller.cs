using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConyroller : MonoBehaviour
{
    public float walkSpeed;
    private float speed;
    private Vector3 movement;
    //private CharacterController controller;

    private int clickCount = 0;
    public float runSpeed;
    //private Vector3 moveDir = Vector3.zero;
    //private float gravity = 3f;

    //public float jumpPower;
    //public AudioClip jumpSound;
    //private AudioSource audioS;

    private Rigidbody rb;


    void Start()
    {
        //audioS = GetComponent<AudioSource>();

        //controller = GetComponent<CharacterController>();

        speed = walkSpeed;

        TryGetComponent(out rb);
    }

    void Update()
    {
        //PlayerMove();

        ProcessInput();
    }
    /// <summary>
    /// �ړ��p�̃L�[����
    /// </summary>
    private void ProcessInput()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        movement = new Vector3(moveH, 0, moveV);
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        //float moveH = Input.GetAxis("Horizontal");
        //float moveV = Input.GetAxis("Vertical");
        //movement = new Vector3(moveH, 0, moveV);

        //Vector3 desiredMove = Camera.main.transform.forward * movement.z + Camera.main.transform.right * movement.x;
        //moveDir.x = desiredMove.x * 3f;
        //moveDir.z = desiredMove.z * 3f;
        //moveDir.y -= gravity * Time.deltaTime; // �^���d�͂̎���

        //controller.Move(movement * Time.deltaTime * speed);

        // 64�s�ڂƏ����̓��e�͓����ł����AdesiredMove �ϐ��̏������Q�ɕ����܂�
        // �v���C���[���X�����܂܈ړ�����Ƌ󒆂ɕ����Ԃ��߁A���̎΂߂̕����̗͂����ꂼ�ꏜ������K�v�����邽�߂ł�
        // �J������ forward �� right �x�N�g���𐅕��ʏ�ɓ��e���āA�ړ��������v�Z(�P�ʃx�N�g���ɂȂ��Ă���̂Ő��K���s�v)
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // �v���C���[���΂߂ɌX���Ă���ۂɑO��ړ�����Ƌ󒆂ɕ�����ł��܂�
        // ���̋�����h�����߁A���ꂼ��� Y ���̐����� 0 �ɂ���
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        // �J�����̐��ʕ����ƉE�����̃x�N�g�����g�p���āA�v���C���[�̈ړ��������v�Z
        Vector3 desiredMove = cameraForward * movement.z + cameraRight * movement.x;

        // Rigidbody ���g���Ĉړ��B�܂��A�W�����v�Ɨ������l�����ďd��(rb.velocity.y)�𔽉f
        rb.velocity = desiredMove * speed + new Vector3(0, rb.velocity.y, 0);


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

        //if (controller.isGrounded)
        //{
        //    moveDir.y = 0;
        
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        moveDir.y = jumpPower;
        //        audioS.clip = jumpSound;
        //        audioS.Play();
        //    }
        //}
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
