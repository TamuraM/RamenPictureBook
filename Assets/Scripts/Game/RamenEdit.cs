using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

/// <summary>今作ってるラーメンの情報</summary>
public class RamenEdit : MonoBehaviour
{
    [Tooltip("スープの情報")]
    private Dictionary<string, bool> _soupInf =
        new Dictionary<string, bool> { { "とんこつ", false }, { "しょうゆ", true }, { "しお", false }, { "みそ", false }, /*{ "なし", true }*/ };
    /// <summary>今のスープの情報　trueになってるものが選択されてる</summary>
    public Dictionary<string, bool> SoupInf => _soupInf;

    [Tooltip("めんの情報")]
    private Dictionary<string, bool> _noodleInf =
        new Dictionary<string, bool> { { "ばりかた", false }, { "かため", false }, { "ふつう", true }, { "やわらかめ", false }, /* "なし", true }*/ };
    /// <summary>今のめんの情報　trueになってるものが選択されてる</summary>
    public Dictionary<string, bool> NoodleInf => _noodleInf;

    [Tooltip("トッピングの情報")]
    private Dictionary<string, int> _toppingInf =
        new Dictionary<string, int> { { "味付けたまご", 0 }, { "チャーシュー", 0 }, { "ねぎ", 0 }, { "メンマ", 0 }, { "もやし", 0 }, { "コーン", 0 }, { "のり", 0 } };
    /// <summary>今のトッピングの情報　数値の数だけ入ってる</summary>
    public Dictionary<string, int> ToppingInf => _toppingInf;

    [SerializeField, Header("表示してるスープのメッシュレンダラー")] private MeshRenderer _soup = default;
    [SerializeField, Header("変更するスープのマテリアル")] private Material[] _soupMaterials = new Material[4];
    [Tooltip("↑のやつを扱いやすくする")] private Dictionary<string, Material> _soupDic = new Dictionary<string, Material>();
    [SerializeField, Header("表示してるめんのゲームオブジェクト")] private GameObject _noodle = default;
    [SerializeField, Header("トッピングできる最大値")] private int _maxToppingCount = 10;
    [SerializeField, Header("トッピングを置く場所")] private Transform[] _toppingTrans = new Transform[10];
    [Tooltip("今乗ってるトッピングの数")] private int _nowToppingCount = 0;
    [SerializeField, Header("乗せるトッピングのオブジェクト")] private GameObject[] _toppingGO = new GameObject[7];
    [Tooltip("↑のやつを扱いやすくする")] private Dictionary<string, GameObject> _toppingDic = new Dictionary<string, GameObject>();

    //--UI関係--//
    [SerializeField, Header("トッピングしてる数を表示するテキスト")] private Text _numberText = default;

    void Start()
    {
        _numberText.text = $"{_nowToppingCount}/{_maxToppingCount}";
        var toppingName = _toppingInf.Keys.ToArray();
        var soupName = _soupInf.Keys.ToArray();

        for(int i = 0; i < _toppingGO.Length; i++)
        {
            _toppingDic.Add(toppingName[i], _toppingGO[i]);
        }

        for(int i = 0; i < _soupMaterials.Length; i++)
        {
            _soupDic.Add(soupName[i], _soupMaterials[i]);
        }

    }

    /// <summary>トッピングの数の表示を変更する</summary>
    private void NumberTextChange()
    {
        _numberText.text = $"{_nowToppingCount}/{_maxToppingCount}";

        if (_nowToppingCount == _maxToppingCount)
        {
            _numberText.color = Color.red;
        }
        else if (_nowToppingCount >= _maxToppingCount * (4 / 5))
        {
            _numberText.color = Color.yellow;
        }
        else
        {
            _numberText.color = Color.white;
        }

    }

    /// <summary>トッピングの具材ボタンにつける関数　トッピングを追加することができる</summary>
    /// <param name="topping"></param>
    public void Topping(string topping)
    {

        if (_nowToppingCount < _maxToppingCount)
        {
            //指定された位置に具材をおく
            Instantiate(_toppingDic[topping], _toppingTrans[_nowToppingCount].position, Quaternion.identity);
            _nowToppingCount++;
            NumberTextChange();
            //指定されたトッピングが増える
            _toppingInf[topping]++;
            Debug.Log($"{topping}は{_toppingInf[topping]}個置かれています");
        }
        else
        {
            Debug.Log("これ以上トッピングすることはできません");
        }

    }

    ///トッピングをひとつ前の状態に戻すボタンの関数が欲しい
    ///トッピングのボタン押したときにListに保存
    ///→ひとつ戻すボタン押したら最後に格納されてるトッピングの数値を減らして、
    ///トッピングが発生する場所を入れといてるって思ったけど置いてあるオブジェクトListも用意しないといけなさそう

    /// <summary>スープの具材ボタンにつける関数　スープを変更することができる</summary>
    /// <param name="topping"></param>
    public void Soup(string soup)
    {
        //全部falseにしてから、変更したいやつだけtrueにする
        string[] keys = _soupInf.Keys.ToArray();

        foreach (var key in keys)
        {
            _soupInf[key] = false;
        }

        _soupInf[soup] = true;
        Debug.Log($"今のスープは{soup}です");

        //みためを指定されたものに変える
            _soup.material = _soupDic[soup];
    }

    /// <summary>めんの具材ボタンにつける関数　めんを変更することができる</summary>
    /// <param name="topping"></param>
    public void Noodle(string noodle)
    {
        //全部falseにしてから、変更したいやつだけtrueにする
        string[] keys = _noodleInf.Keys.ToArray();

        foreach (var key in keys)
        {
            _noodleInf[key] = false;
        }

        _noodleInf[noodle] = true;
        Debug.Log($"今のめんは{noodle}です");

        //「なし」にした場合、めんのオブジェクトを消す
    }
}
