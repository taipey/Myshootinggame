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
    /// 移動用のキー入力
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
        //moveDir.y -= gravity * Time.deltaTime; // 疑似重力の実装

        //controller.Move(movement * Time.deltaTime * speed);

        // 64行目と処理の内容は同じですが、desiredMove 変数の処理を２つに分けます
        // プレイヤーが傾いたまま移動すると空中に浮かぶため、その斜めの方向の力をそれぞれ除去する必要があるためです
        // カメラの forward と right ベクトルを水平面上に投影して、移動方向を計算(単位ベクトルになっているので正規化不要)
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // プレイヤーが斜めに傾いている際に前後移動すると空中に浮かんでしまう
        // その挙動を防ぐため、それぞれの Y 軸の成分を 0 にする
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        // カメラの正面方向と右方向のベクトルを使用して、プレイヤーの移動方向を計算
        Vector3 desiredMove = cameraForward * movement.z + cameraRight * movement.x;

        // Rigidbody を使って移動。また、ジャンプと落下を考慮して重力(rb.velocity.y)を反映
        rb.velocity = desiredMove * speed + new Vector3(0, rb.velocity.y, 0);


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
