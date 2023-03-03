using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>自分で作ったラーメンを図鑑に保存するスクリプト シングルトン</summary>
public class RamenRecord : MonoBehaviour
{
    public static RamenRecord Instance;
    [Tooltip("保存しておくリスト")] private int i = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
