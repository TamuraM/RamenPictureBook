using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>具材ボタンを左右に動かすボタンのスクリプト</summary>
public class ArrowButton : MonoBehaviour
{
    [SerializeField, Header("具材ボタンの背景のゲームオブジェクト")] private RectTransform _background = default;
    [Tooltip("最初の位置")] private float _firstXpos = default;
    [SerializeField, Header("'KindButton'をいれる")] private KindButton _kindButton = default;

    void Start()
    {
        _firstXpos = _background.anchoredPosition.x;
    }

    /// <summary>
    /// 左矢印を押したときの動作
    /// 具材ボタンの左側を表示するため、背景自体は右に動く
    /// </summary>
    /// <param name="moveRange"></param>
    public void LeftArrow(float moveRange)
    {
        //最初の位置より左側にいるときだけずらせる
        if(_background.anchoredPosition.x < _firstXpos)
        {
            float movedX = _background.anchoredPosition.x + moveRange;
            _background.anchoredPosition = new Vector3(movedX, _background.anchoredPosition.y);
        }
        
    }

    /// <summary>
    /// 右矢印を押したときの動作
    /// 具材ボタンの右側を表示するため、背景自体は左に動く
    /// </summary>
    /// <param name="moveRange"></param>
    public void RightArrow(float moveRange)
    {

        //今おいてる種類をとってきて、それによって上限がかわる
        if(_kindButton.GetNowKind == KindButton.Kind.Topping)
        {

            //トッピングの時は2回まで移動するから、moveRangeの2倍よりも小さいときだけ押せる
            if(_background.anchoredPosition.x > _firstXpos - moveRange * 2)
            {
                float movedX = _background.anchoredPosition.x - moveRange;
                _background.anchoredPosition = new Vector3(movedX, _background.anchoredPosition.y);
            }
            
        }
        else
        {

            //その他の時は1回まで
            if (_background.anchoredPosition.x > _firstXpos - moveRange)
            {
                float movedX = _background.anchoredPosition.x - moveRange;
                _background.anchoredPosition = new Vector3(movedX, _background.anchoredPosition.y);
            }

        }
        
    }
}
