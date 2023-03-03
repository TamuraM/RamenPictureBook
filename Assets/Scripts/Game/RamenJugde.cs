using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>どんなラーメンができたか判定する</summary>
public class RamenJugde : MonoBehaviour
{
    [SerializeField, Header("'RamenEdit'")] private RamenEdit _ramenEdit = default;
    [Tooltip("できあがったラーメンの情報")] private RamenInf _ramenInf = default;
    [SerializeField, Header("出来上がったラーメンの情報を表示するテキスト")] private GameObject _ramenInfText = default;
    [Tooltip("テキスト")] private Text _text = default;

    void Start()
    {
        _text = _ramenInfText.GetComponent<Text>();
        _ramenInfText.SetActive(false);
        //各ラーメンのパラメータを取っておきたいかも
        //図鑑管理するスクリプトからでも
    }

    void Update()
    {

    }

    /// <summary>完成ボタンにつける関数　出来上がったラーメンがなにラーメンか判定したい</summary>
    public void CompleteEdit()
    {
        _ramenInf = new RamenInf(_ramenEdit.SoupInf, _ramenEdit.NoodleInf, _ramenEdit.ToppingInf);

        //とりあえずはコンソールに全部表示させるのとテキストで表示する
        string completeMessege = $"完成！\n[スープ：{_ramenInf.Soup}] [めん：{_ramenInf.Noodle}] \n" +
            $"[トッピング：味付けたまご{_ramenInf.Topping[0]}、チャーシュー{_ramenInf.Topping[1]}、ねぎ{_ramenInf.Topping[2]}、\n" +
            $"メンマ{_ramenInf.Topping[3]}、もやし{_ramenInf.Topping[4]}、コーン{_ramenInf.Topping[5]}、のり{_ramenInf.Topping[6]}]";
        _text.text = completeMessege;
        Debug.Log(completeMessege);
    }

}

/// <summary>出来上がったラーメンの情報を保存できるクラス</summary>
public class RamenInf
{
    private string _soup;
    private string _noodle;
    private int[] _topping;

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
        
        foreach(var key in soupKeys)
        {
            if(soup[key])
            {
                _soup = key;
                break;
            }
        }

        var noodleKeys = noodle.Keys;

        foreach(var key in noodleKeys)
        {
            if(noodle[key])
            {
                _noodle = key;
                break;
            }
        }

        //配列に数字だけ格納
        _topping = topping.Values.ToArray();
    }
}
