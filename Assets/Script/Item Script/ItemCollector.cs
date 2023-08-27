using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] int itemsToCollect = 5; // 設定する必要があるアイテムの総数
    private int collectedItems = 0; // 現在取得したアイテムの数

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // 仮のアクションキーとしてSpaceキーを使用
        {
            TryCollectItem();
        }
    }

    private void TryCollectItem()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.0f); // キャラクター周囲の1.0半径の範囲内のコライダーを検出

        foreach (var collider in hitColliders)
        {
            GameObject item = collider.gameObject;

            if (item.CompareTag("Item")) // "Item" タグを持つオブジェクトをアイテムとして認識
            {
                collectedItems++;
                Destroy(item); // アイテムを削除

                if (collectedItems >= itemsToCollect)
                {
                    // ここにクリア時の処理を記述
                    Debug.Log("Clear!"); // クリア時のメッセージを表示
                }

                break; // 1フレーム内で複数のアイテムが取得されないようにする
            }
        }
    }
}
