using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>完成ボタンを押した後の動き</summary>
public class RamenEntry : MonoBehaviour
{
    [SerializeField, Header("「完成」のテキストたち")] private GameObject[] _completeText = new GameObject[2];
    [SerializeField, Header("どんぶりの周りを回るカメラの回転の中心")] private GameObject _cameraPivot = default;
    [Tooltip("説明の入力できる部分のリスト")] private Dictionary<string, string> _explanationList = 
        new Dictionary<string, string> { { "名前", "" }, { "制作者", "" }, { "こだわり", "" } };
    public Dictionary<string, string> ExplanationList { get => _explanationList; }
    [Tooltip("いま入力してる文字")] private string _nowTyping = "";
    [SerializeField, Header("入力するときの背景")] private GameObject _inputBackground = default;
    [SerializeField, Header("なにを入力するかの指示を表示するテキスト")] private Text _instructionsText = default;
    [SerializeField, Header("入力されてる文字を表示するテキスト")] private Text _inputText = default;
    [SerializeField, Header("入力するキー")] private GameObject _inputKey = default;
    [Tooltip("入力できる最大文字数")] private int _maxStringLength = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>自由記入の時に使う　文字を入力できる</summary>
    /// <param name="moji"></param>
    public void Typing(string moji)
    {

        if (moji == "b") //bだったら1文字消す
        {

            if (_nowTyping.Length != 0)
            {
                _nowTyping = _nowTyping.Substring(0, _nowTyping.Length - 1);
                _inputText.text = $"{_nowTyping}";
            }

        }
        else
        {

            if (_nowTyping.Length < _maxStringLength) //入力できる最大文字数を設定してあげる
            {
                _nowTyping = $"{_nowTyping}{moji}";
                _inputText.text = $"{_nowTyping}";
            }

        }

    }

    /// <summary>エンターキーを押したときの処理　入力するものによってキーを変える</summary>
    /// <param name="type"></param>
    public void EnterKey(string type)
    {
        //入力されたものをDictionaryに入れておく
        _explanationList[type] = _nowTyping;

        switch (type) //次の指示を出す
        {
            default:
                break;
        }

    }

    /// <summary>カメラが回って「完成」の文字が出てくる</summary>
    public void CompleteAnimation()
    {
        _cameraPivot.transform.DORotate(new Vector3(0, 180, 0), 7).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental).SetAutoKill();
        _completeText[0].SetActive(true);
        DOTween.Sequence()
            .Append(_completeText[0].transform.DOScale(new Vector3(1, 1, 1), 0.8f).SetEase(Ease.Linear).OnComplete(() => _completeText[1].SetActive(true)).SetAutoKill())
            .Append(_completeText[1].transform.DOScale(new Vector3(1, 1, 1), 0.8f).SetEase(Ease.Linear).SetAutoKill())
            .Append(_completeText[0].transform.DOScale(new Vector3(0, 0, 0), 0.8f).SetEase(Ease.Linear).SetAutoKill())
            .Append(_completeText[1].transform.DOScale(new Vector3(0, 0, 0), 0.8f).SetEase(Ease.Linear).OnComplete(() => _inputBackground.SetActive(true)).SetAutoKill())
            .Append(_inputBackground.GetComponent<Image>().DOFade(0.15f, 1.0f).SetEase(Ease.Linear).SetAutoKill())
            .Append(_instructionsText.DOFade(1, 0.3f).SetEase(Ease.Linear).OnComplete(() => { _instructionsText.color = Color.black; _inputKey.SetActive(true); }).SetAutoKill());
    }


}
