using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform leftBottomTram;
    [SerializeField] Transform rightTopTram;
    [SerializeField] int itemCount;
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
}
