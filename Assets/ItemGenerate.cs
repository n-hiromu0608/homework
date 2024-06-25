using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _item;
    [SerializeField] Transform _root;
    [SerializeField] int _number = 0;
    private List<GameObject> _generatedItems = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        foreach (var item in _generatedItems)
        {
            Destroy(item);
        }
        _generatedItems.Clear(); // リストをクリア

        for (int i = 0; i < 18 * _number; i++)
        {
            var item = Instantiate(_item, _root);
            item.transform.position = new Vector3(_root.position.x, _root.position.y, i * 5 + _root.position.z);
        }
    }

    public void PlayerReset()
    {
        foreach (var item in _generatedItems)
        {
            Destroy(item);
        }
        _generatedItems.Clear(); // リストをクリア

        // アイテムを再生成する
        for (int i = 0; i < 18 * _number; i++)
        {
            var item = Instantiate(_item, _root);
            item.transform.position = new Vector3(_root.position.x, _root.position.y, i * 5 + _root.position.z);
        }
    }
}
