using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>どんなラーメンができたか判定する</summary>
public class RamenJugde : MonoBehaviour
{
    [SerializeField, Header("'RamenEdit'")] private RamenEdit _ramenEdit = default;
    [SerializeField, Header("'RamenEntry'")] private RamenEntry _ramenEntry = default;
    [Tooltip("できあがったラーメンの情報")] private RamenInf _ramenInf = default;
    [SerializeField, Header("出来上がったラーメンの情報を表示するテキスト")] private GameObject _ramenInfText = default;
    [Tooltip("テキスト")] private Text _text = default;
    [SerializeField, Header("終了ダイアログを出すときに消すものたち")] private GameObject[] _editUIGo = new GameObject[6];
    [SerializeField, Header("終了ダイアログ")] private GameObject _dialog = default;
    [SerializeField, Header("完成アニメーションの時のカメラ")] private GameObject _subCamera = default;
    [SerializeField, Header("もともとのカメラ")] private GameObject _mainCamera = default;

    void Start()
    {
        _text = _ramenInfText.GetComponent<Text>();
        _ramenInfText.SetActive(false);
        //各ラーメンのパラメータを取っておきたいかも
        //図鑑管理するスクリプトからでも
    }

    /// <summary>完成ボタンにつける関数　制作を終了するか聞いてくる</summary>
    public void CompleteEdit()
    {
        //「終了する？」的なダイアログ出す
        foreach (var g in _editUIGo)
        {
            g.SetActive(false);
        }

        _dialog.SetActive(true);
    }

    /// <summary>ダイアログのボタンにつける　trueは「はい」、falseは「いいえ」</summary>
    /// <param name="flg"></param>
    public void EndEdit(bool flg)
    {

        if (flg) //制作終了
        {
            //カメラワーク変える
            _dialog.SetActive(false);
            _subCamera.SetActive(true);
            _mainCamera.SetActive(false);
            _ramenEntry.CompleteAnimation();
        }
        else //制作続行
        {
            _dialog.SetActive(false);

            //ダイアログ消して元に戻す
            foreach (var g in _editUIGo)
            {
                g.SetActive(true);
            }

        }

    }

    /// <summary>図鑑に登録する内容が全部出来上がった時に押すボタンにつける関数　図鑑に登録します</summary>
    public void SaveRamenToBook()
    {
        RamenRecord.Instance.SaveRamenToBook(_ramenInf);
    }

}

/// <summary>出来上がったラーメンの情報を保存できるクラス</summary>
public class RamenInf
{
    private string _soup;
    private string _noodle;
    private int[] _topping;
    //説明文、写真、名前
    private string _name;
    private string _explanatio;

    /// <summary>完成したラーメンのスープ</summary>
    public string Soup => _soup;
    /// <summary>完成したラーメンのめんのかたさ</summary>
    public string Noodle => _noodle;
    /// <summary>
    /// 完成したラーメンのトッピングの数
    /// 0味付けたまご、1チャーシュー、2ねぎ、3メンマ、4もやし、5コーン、6のり
    /// </summary>
    public int[] Topping => _topping;

    public RamenInf(Dictionary<string, bool> soup, Dictionary<string, bool> noodle, Dictionary<string, int> topping)
    {
        //ループで全部確認して、trueになってるとこを保存
        var soupKeys = soup.Keys;

        foreach (var key in soupKeys)
        {
            if (soup[key])
            {
                _soup = key;
                break;
            }
        }

        var noodleKeys = noodle.Keys;

        foreach (var key in noodleKeys)
        {
            if (noodle[key])
            {
                _noodle = key;
                break;
            }
        }

        //配列に数字だけ格納
        _topping = topping.Values.ToArray();
    }
}
