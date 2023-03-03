using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>今置ける具材の種類を変更するボタンのスクリプト</summary>
public class KindButton : MonoBehaviour
{
    /// <summary>0がスープ、1がめん、2がトッピングにする</summary>
    [SerializeField, Header("それぞれの種類ボタンに必要な情報たち")] private ButtonsInf[] _kindButtons = new ButtonsInf[3];
    [Tooltip("↑の情報を扱いやすいようにDictionaryにする")] private Dictionary<string, RectTransform> _kindButtonRect = new Dictionary<string, RectTransform>();
    [Tooltip("↑の情報を扱いやすいようにDictionaryにする")] private Dictionary<string, GameObject> _guzaiButtonGo = new Dictionary<string, GameObject>();
    //[Tooltip("具材ボタン背景の初期位置")] private Dictionary<string, Vector2> _guzaiButtonOriginPos = new Dictionary<string, Vector2>();
    //上のやつ、鈴木先生が送ってきたassetが使えるかもらしい

    //--UI関係--//
    [SerializeField, Header("種類ボタンの移動先上")] Vector2 _movedUpper = default;
    [SerializeField, Header("種類ボタンの移動先下")] Vector2 _movedLower = default;
    [SerializeField, Header("種類ボタンが戻る場所")] RectTransform _originPos = default;
    [Tooltip("他の種類ボタンがでてるか")] private bool _isShownOther = false;

    [SerializeField, Header("今の種類を表示するテキスト")] private Text _kindText = default;

    /// <summary>今選択できる具材の種類を管理してる</summary>
    public enum Kind
    {
        /// <summary>スープの種類を選べる</summary>
        Soup,
        /// <summary>めんの種類を選べる</summary>
        Noodle,
        /// <summary>トッピングの種類を選べる</summary>
        Topping,
    }

    [Tooltip("今選択できる種類")] private Kind _nowKind = Kind.Soup;
    public Kind GetNowKind { get => _nowKind; }

    void Start()
    {

        //初期設定
        for (int i = 0; i < _kindButtons.Length; i++)
        {
            _kindButtonRect.Add(_kindButtons[i].GetKind, _kindButtons[i].GetKindButton);
            _guzaiButtonGo.Add(_kindButtons[i].GetKind, _kindButtons[i].GetGuzaiButton);
            //_guzaiButtonOriginPos.Add(_kindButtons[i].GetKind, _kindButtons[i].GetGuzaiButton.GetComponent<RectTransform>().anchoredPosition);
        }

        _nowKind = Kind.Soup;
        _kindText.text = "スープ";
    }

    /// <summary>
    /// 今の種類が表示されてるボタンにつける　他の種類ボタンが表示される
    /// </summary>
    public void ShowKindButton()
    {

        if(!_isShownOther) //ほかの選択肢が出てないとき、出す
        {

            //今の種類によって出てくるやつが変わる　あとでdotweenにする
            switch (_nowKind)
            {
                case Kind.Soup:
                    _kindButtonRect["めん"].anchoredPosition = _movedUpper;
                    _kindButtonRect["トッピング"].anchoredPosition = _movedLower;
                    break;
                case Kind.Noodle:
                    _kindButtonRect["スープ"].anchoredPosition = _movedUpper;
                    _kindButtonRect["トッピング"].anchoredPosition = _movedLower;
                    break;
                case Kind.Topping:
                    _kindButtonRect["スープ"].anchoredPosition = _movedUpper;
                    _kindButtonRect["めん"].anchoredPosition = _movedLower;
                    break;
                default:
                    break;
            }

            _isShownOther = true;
        }
        else //出てる時、変更せずに選択肢を消す
        {
            //全部元に戻す
            var keys = _kindButtonRect.Keys;

            foreach(var key in keys)
            {
                _kindButtonRect[key].anchoredPosition = _originPos.anchoredPosition;
            }

            _isShownOther = false;
        }

    }

    /// <summary>選択できる種類の具材ボタンを表示する</summary>
    /// <param name="kind"></param>
    public void ChangeKind(string kind)
    {
        //いったん全部消してから表示させたいものを出す　テキストも変える
        var keys = _guzaiButtonGo.Keys;

        foreach(var key in keys)
        {
            //_guzaiButtonGo[key].GetComponent<RectTransform>().anchoredPosition = _guzaiButtonOriginPos[key];
            _guzaiButtonGo[key].SetActive(false);
            _kindButtonRect[key].anchoredPosition = _originPos.anchoredPosition;
        }

        _guzaiButtonGo[kind].SetActive(true);
        _kindText.text = kind;
        _isShownOther = false;
    }

    /// <summary>今選択できる種類の状態を変更する</summary>
    /// <param name="kind"></param>
    public void ChangeKind(int kind)
    {
        _nowKind = (Kind)kind;
    }

}

/// <summary>
/// 種類とゲームオブジェクトをセットで登録したかったやつ　他のやり方ありそう
/// </summary>
[System.Serializable]
public class ButtonsInf
{
    [SerializeField, Header("種類の名前")] private string _kind = default;
    /// <summary>種類の名前</summary>
    public string GetKind { get => _kind; }
    [SerializeField, Header("種類ボタン")] private RectTransform _kindButton = default;
    /// <summary>種類ボタン</summary>
    public RectTransform GetKindButton { get => _kindButton; }
    [SerializeField, Header("具材ボタン")] private GameObject _guzaiButton = default;
    /// <summary>具材ボタン</summary>
    public GameObject GetGuzaiButton { get => _guzaiButton; }
}