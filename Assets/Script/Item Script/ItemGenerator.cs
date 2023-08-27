using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform leftBottomTram;
    [SerializeField] Transform rightTopTram;
    [SerializeField] int itemCount;
    [SerializeField] int plusItemCount;
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i < itemCount; i++)
        {
            GenerateItem();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GenerateItem();
        }

        // �N���A�������`�F�b�N
        if (plusItemCount >= 10) // 10�̃v���X�A�C�e�����擾�����ꍇ
        {
            // �Q�[���N���A���������s
            GameClear();
        }
    }

    private void GameClear()
    {
        // �Q�[���N���A�����������Ɏ���
        // �Ⴆ�΁A�N���A��ʂ�\������A�^�C�����~�߂�A�Ȃǂ̏������s��
    }

    private void GenerateItem()
    {
        GameObject item = Instantiate(itemPrefab);

        // �����_���ȍ��W���Q���
        float ramdomX = Random.Range(leftBottomTram.position.x, rightTopTram.position.x);
        float ramdomZ = Random.Range(leftBottomTram.position.z, rightTopTram.position.z);

        // ������A�C�e���̍��W�������_���ȏ��ɏ���������
        item.transform.position = new Vector3(ramdomX, item.transform.position.y, ramdomZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlusItem"))
        {
            plusItemCount++;
            Destroy(other.gameObject); // �v���X�A�C�e��������
        }
    }
}
