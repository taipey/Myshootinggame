using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController2 : MonoBehaviour
{

public class EnemyAI : MonoBehaviour
{
    public Transform player; // プレイヤーオブジェクトのTransform
    private NavMeshAgent navMeshAgent;
    public float sightRange = 10f; // 視界の範囲
    public float attackRange = 2f; // 攻撃の範囲

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // プレイヤーと敵キャラクターの距離を計算
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // プレイヤーが視界の範囲内にいるか判定
        if (distanceToPlayer <= sightRange)
        {
            // プレイヤーの位置を追跡対象に設定
            navMeshAgent.SetDestination(player.position);

            // プレイヤーが攻撃範囲内にいるか判定
            if (distanceToPlayer <= attackRange)
            {
                // ここで攻撃を開始する処理を追加する
            }
        }
    }
}



}
       
