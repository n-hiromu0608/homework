using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _item;
    [SerializeField] Transform _root;

    // Start is called before the first frame update
    void Awake()
    {

        for (int i = 0; i < 18; i++)
        {
            var item = Instantiate(_item, _root);
            item.transform.position = new Vector3(0, 1, i * 5 + 5);
        }
    }
}
