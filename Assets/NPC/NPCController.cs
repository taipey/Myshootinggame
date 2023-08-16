using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    public Transform player; // プレイヤーオブジェクトのTransform
    public float sightRange = 10f; // 視界の範囲
    public float moveSpeed = 5f; // 移動速度
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;
    }

    private void Update()
    {
        // プレイヤーと敵キャラクターの距離を計算
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // どの位離れているかを表示
        Debug.Log("プレイヤーまでの距離 : " + distanceToPlayer);

        // プレイヤーが視界に入った場合
        if (distanceToPlayer <= sightRange)
        {
            // プレイヤーの位置を追跡対象に設定
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            // プレイヤーが視界外の場合、移動を停止する
            navMeshAgent.ResetPath();
        }
        // 不要な回転を止める
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
