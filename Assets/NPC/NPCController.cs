using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    public Transform player; // �v���C���[�I�u�W�F�N�g��Transform
    public float sightRange = 10f; // ���E�͈̔�
    public float moveSpeed = 5f; // �ړ����x
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

        // �v���C���[�ƓG�L�����N�^�[�̋������v�Z
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // �v���C���[�����E�ɓ������ꍇ
        if (distanceToPlayer <= sightRange)
        {
            // �v���C���[�̈ʒu��ǐՑΏۂɐݒ�
            navMeshAgent.SetDestination(player.position);

            // �v���C���[�̈ʒu��G�L�����N�^�[�Ɍ�����
            Vector3 directionToPlayer = player.position - transform.position;
            transform.forward = directionToPlayer.normalized;

            // �v���C���[�̕���������
            _ = player.position - transform.position;
            transform.forward = directionToPlayer.normalized;

            // �v���C���[�Ɍ������Ĉړ�����
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            // �ړ�������
            if (!navMeshAgent.isStopped)
            {
                navMeshAgent.isStopped = false;
            }
        }
        else
        {
            // �v���C���[�����E�O�̏ꍇ�A�ړ����~����
            if (!navMeshAgent.isStopped)
            {
                navMeshAgent.isStopped = true;
            }
        }

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
