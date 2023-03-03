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
    [Tooltip("ラーメンの説明")] private string _explanation = default;
    [Tooltip("いま入力してる文字")] private string _nowTyping = default;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>自由記入の時に使う　文字を入力できる</summary>
    /// <param name="moji"></param>
    public void Typing(char moji)
    {
        _nowTyping = $"{_nowTyping}{moji}";
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
            .Append(_completeText[1].transform.DOScale(new Vector3(0, 0, 0), 0.8f).SetEase(Ease.Linear).SetAutoKill());
    }


}
