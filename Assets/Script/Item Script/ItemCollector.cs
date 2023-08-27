using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] int itemsToCollect = 5; // �ݒ肷��K�v������A�C�e���̑���
    private int collectedItems = 0; // ���ݎ擾�����A�C�e���̐�

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // ���̃A�N�V�����L�[�Ƃ���Space�L�[���g�p
        {
            TryCollectItem();
        }
    }

    private void TryCollectItem()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.0f); // �L�����N�^�[���͂�1.0���a�͈͓̔��̃R���C�_�[�����o

        foreach (var collider in hitColliders)
        {
            GameObject item = collider.gameObject;

            if (item.CompareTag("Item")) // "Item" �^�O�����I�u�W�F�N�g���A�C�e���Ƃ��ĔF��
            {
                collectedItems++;
                Destroy(item); // �A�C�e�����폜

                if (collectedItems >= itemsToCollect)
                {
                    // �����ɃN���A���̏������L�q
                    Debug.Log("Clear!"); // �N���A���̃��b�Z�[�W��\��
                }

                break; // 1�t���[�����ŕ����̃A�C�e�����擾����Ȃ��悤�ɂ���
            }
        }
    }
}
