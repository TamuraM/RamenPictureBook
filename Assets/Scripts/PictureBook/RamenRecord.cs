using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>自分で作ったラーメンを図鑑に保存するスクリプト シングルトン</summary>
public class RamenRecord : MonoBehaviour
{
    /// <summary>RamenRecordのインスタンス</summary>
    public static RamenRecord Instance;
    [Tooltip("保存しておくリスト")] private List<RamenInf> _myRamenCollection = new List<RamenInf>();

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

    /// <summary>図鑑に保存するための関数</summary>
    public void SaveRamenToBook(RamenInf ramenInf)
    {
        //リストに保存
        _myRamenCollection.Add(ramenInf);
        Debug.Log($"図鑑に保存しました。今保存されてるラーメンは{_myRamenCollection.Count}個です。");

        //いっぱいだったら保存する前に何かしないと
    }
}
