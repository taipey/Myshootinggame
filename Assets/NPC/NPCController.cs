using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    public Transform player; // �v���C���[�I�u�W�F�N�g��Transform
    public float sightRange = 10f; // ���E�͈̔�
    public float moveSpeed = 5f; // �ړ����x
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;
    }

    private void Update()
    {
        // �v���C���[�ƓG�L�����N�^�[�̋������v�Z
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // �ǂ̈ʗ���Ă��邩��\��
        Debug.Log("�v���C���[�܂ł̋��� : " + distanceToPlayer);

        // �v���C���[�����E�ɓ������ꍇ
        if (distanceToPlayer <= sightRange)
        {
            // �v���C���[�̈ʒu��ǐՑΏۂɐݒ�
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            // �v���C���[�����E�O�̏ꍇ�A�ړ����~����
            navMeshAgent.ResetPath();
        }
        // �s�v�ȉ�]���~�߂�
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
