using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;
    public PlayerHealth playerHealth; // プレイヤーのHPを管理するスクリプト
    public int damageAmount = 20;
    public int maxHealth = 100; // 最大HP
    public int currentHealth;    // 現在のHP

    void Start()
    {
        currentHealth = maxHealth; // ゲーム開始時にHPを最大値に設定
    }

    // ダメージを受けた場合の処理
    public void TakeDamage()
    {
        currentHealth -= damageAmount;

        // HPが0以下になったら死亡処理などを追加する
        if (currentHealth <= 0)
        {
            // 死亡処理をここに追加
        }
    }
    void Update()
    {
        healthText.text = "HP: " + playerHealth.currentHealth.ToString();
    }
}
