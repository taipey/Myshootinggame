using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;
    public PlayerHealth playerHealth; // �v���C���[��HP���Ǘ�����X�N���v�g
    public int damageAmount = 20;
    public int maxHealth = 100; // �ő�HP
    public int currentHealth;    // ���݂�HP

    void Start()
    {
        currentHealth = maxHealth; // �Q�[���J�n����HP���ő�l�ɐݒ�
    }

    // �_���[�W���󂯂��ꍇ�̏���
    public void TakeDamage()
    {
        currentHealth -= damageAmount;

        // HP��0�ȉ��ɂȂ����玀�S�����Ȃǂ�ǉ�����
        if (currentHealth <= 0)
        {
            // ���S�����������ɒǉ�
        }
    }
    void Update()
    {
        healthText.text = "HP: " + playerHealth.currentHealth.ToString();
    }
}
