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

        // クリア条件をチェック
        if (plusItemCount >= 10) // 10個のプラスアイテムを取得した場合
        {
            // ゲームクリア処理を実行
            GameClear();
        }
    }

    private void GameClear()
    {
        // ゲームクリア処理をここに実装
        // 例えば、クリア画面を表示する、タイムを止める、などの処理を行う
    }

    private void GenerateItem()
    {
        GameObject item = Instantiate(itemPrefab);

        // ランダムな座標を２つ作る
        float ramdomX = Random.Range(leftBottomTram.position.x, rightTopTram.position.x);
        float ramdomZ = Random.Range(leftBottomTram.position.z, rightTopTram.position.z);

        // 作ったアイテムの座標をランダムな情報に書き換える
        item.transform.position = new Vector3(ramdomX, item.transform.position.y, ramdomZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlusItem"))
        {
            plusItemCount++;
            Destroy(other.gameObject); // プラスアイテムを消す
        }
    }
}
