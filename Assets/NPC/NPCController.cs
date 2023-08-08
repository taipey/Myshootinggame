using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    public Transform player; // プレイヤーオブジェクトのTransform
    public float sightRange = 10f; // 視界の範囲
    public float moveSpeed = 5f; // 移動速度
    private NavMeshAgent navMeshAgent;
    public float distance = 3.0f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (distance > navMeshAgent.remainingDistance)
        {
           // navMeshAgent.ResetPath();
            return;
        }

        // プレイヤーと敵キャラクターの距離を計算
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // プレイヤーが視界に入った場合
        if (distanceToPlayer <= sightRange)
        {
            // プレイヤーの位置を追跡対象に設定
            navMeshAgent.SetDestination(player.position);

            // プレイヤーの位置を敵キャラクターに向ける
            Vector3 directionToPlayer = player.position - transform.position;
            transform.forward = directionToPlayer.normalized;

            // プレイヤーの方向を向く
            _ = player.position - transform.position;
            transform.forward = directionToPlayer.normalized;

            // プレイヤーに向かって移動する
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            // 移動させる
            if (!navMeshAgent.isStopped)
            {
                navMeshAgent.isStopped = false;
            }
        }
        else
        {
            // プレイヤーが視界外の場合、移動を停止する
            if (!navMeshAgent.isStopped)
            {
                navMeshAgent.isStopped = true;
            }
        }

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
