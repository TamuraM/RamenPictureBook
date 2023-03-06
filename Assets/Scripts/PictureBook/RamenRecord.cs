using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>自分で作ったラーメンを図鑑に保存するスクリプト シングルトン</summary>
public class RamenRecord : MonoBehaviour
{
    /// <summary>RamenRecordのインスタンス</summary>
    public static RamenRecord Instance;
    [Tooltip("保存しておくリスト")] private RamenInf[] _myRamenCollection = new RamenInf[30];
    /// <summary>作ったラーメンの情報を保存しておくリスト</summary>
    public RamenInf[] MyRamenCollection => _myRamenCollection;
    [Tooltip("何個目に追加するか")] private int _index = 0;
    [Tooltip("リストに入る最大値")] private int _maxCount = 30;
    /// <summary>保存しておくリストに入る最大値</summary>
    public int MaxCount => _maxCount;

    void Awake()
    {
        // この処理は Start() に書いてもよいが、Awake() に書くことが多い。
        // 参考: イベント関数の実行順序 https://docs.unity3d.com/ja/2019.4/Manual/ExecutionOrder.html
        if (Instance)
        {
            // インスタンスが既にある場合は、破棄する
            Debug.LogWarning($"SingletonSystem のインスタンスは既に存在するので、{gameObject.name} は破棄します。");
            Destroy(this.gameObject);
        }
        else
        {
            // このクラスのインスタンスが無かった場合は、自分を DontDestroyOnload に置く
            Instance = this;
            //仮想シーン(DontDestroyOnLoad)に保存されて、他のシーンを呼び出してもDestroyされない
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {

        for(int i = 0; i < _maxCount; i++)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>図鑑に保存するための関数</summary>
    public void SaveRamenToBook(RamenInf ramenInf)
    {
        //最大値よりも多く保存しようとしたら、最初に戻す
        if(_index + 1 == _maxCount)
        {
            _index = 0;
        }

        //リストに保存
        _myRamenCollection[_index] = ramenInf;
        _index++;
        Debug.Log($"図鑑に保存しました。今保存されてるラーメンは{_index}個です。");
    }
}
