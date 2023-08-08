using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController2 : MonoBehaviour
{

public class EnemyAI : MonoBehaviour
{
    public Transform player; // �v���C���[�I�u�W�F�N�g��Transform
    private NavMeshAgent navMeshAgent;
    public float sightRange = 10f; // ���E�͈̔�
    public float attackRange = 2f; // �U���͈̔�

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // �v���C���[�ƓG�L�����N�^�[�̋������v�Z
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // �v���C���[�����E�͈͓̔��ɂ��邩����
        if (distanceToPlayer <= sightRange)
        {
            // �v���C���[�̈ʒu��ǐՑΏۂɐݒ�
            navMeshAgent.SetDestination(player.position);

            // �v���C���[���U���͈͓��ɂ��邩����
            if (distanceToPlayer <= attackRange)
            {
                // �����ōU�����J�n���鏈����ǉ�����
            }
        }
    }
}



}
       
