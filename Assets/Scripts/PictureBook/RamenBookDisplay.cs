using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class RamenBookDisplay : MonoBehaviour
{
    [SerializeField, Header("ページのゲームオブジェクト")] private GameObject _pageGO = default;
    [SerializeField, Header("表示する欄たち")] private GameObject[] _displays = new GameObject[6];
    [SerializeField, Header("写真を表示する欄たち")] private Image[] _imageDisplays = new Image[6];
    [SerializeField, Header("名前を表示する欄たち")] private Text[] _nameDisplays = new Text[6];
    [SerializeField, Header("説明を表示する欄たち")] private Text[] _explanationDisplays = new Text[6];
    [Tooltip("表示するindex")] private int _displayIndex = default;
    [SerializeField, Header("左矢印")] private Image _leftArrow = default;
    [SerializeField, Header("右矢印")] private Image _rightArrow = default;
    [Tooltip("今表示してるページ数")] private int _nowPage = 0;

    void Start()
    {
        _displayIndex = RamenRecord.Instance.MaxCount / (RamenRecord.Instance.MaxCount / _displays.Length);

        for (int i = 0; i < _displays.Length; i++)
        {
            var index = _displayIndex * _nowPage + i;

            if (RamenRecord.Instance.MyRamenCollection[index] == null)
            {
                _nameDisplays[i].text = "";
                _explanationDisplays[i].text = "まだ登録されて\nいません";
            }
            else
            {
                _nameDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Name;
                _explanationDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Explanation;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftArrow()
    {

        if(_nowPage == 0)
        {
            return;
        }
        else
        {
            _nowPage--;

            //ページをめくる間非表示にして、次のページの内容を表示
            for (int i = 0; i < _displays.Length; i++)
            {
                _displays[i].SetActive(false);
                var index = _displayIndex * _nowPage + i;

                if(RamenRecord.Instance.MyRamenCollection[index] == null)
                {
                    _nameDisplays[i].text = "";
                    _explanationDisplays[i].text = "まだ登録されて\nいません";
                }
                else
                {
                    _nameDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Name;
                    _explanationDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Explanation;
                }

            }
            
            //右側から左側へめくる
            _pageGO.transform.rotation = Quaternion.Euler(0, 0, 0);
            _pageGO.transform.DORotate(new Vector3(0, -180, 0), 1).SetEase(Ease.Linear)
                .OnComplete(() => _displays.ToList().ForEach(d => d.SetActive(true))).SetAutoKill();
            
        }
        
        if(_nowPage == 0)
        {
            //半透明にする
            _leftArrow.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            //元の色にする
            _leftArrow.color = new Color(1, 1, 1, 1);
        }

    }

    public void RightArrow()
    {

        if (_nowPage == 4)
        {
            return;
        }
        else
        {
            _nowPage++;

            //ページをめくる間非表示にして、次のページの内容を表示
            for (int i = 0; i < _displays.Length; i++)
            {
                _displays[i].SetActive(false);
                var index = _displayIndex * _nowPage + i;

                if (RamenRecord.Instance.MyRamenCollection[index] == null)
                {
                    _nameDisplays[i].text = "";
                    _explanationDisplays[i].text = "まだ登録されて\nいません";
                }
                else
                {
                    _nameDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Name;
                    _explanationDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Explanation;
                }
            }

            //左側から右側へめくる
            _pageGO.transform.rotation = Quaternion.Euler(0, 180, 0);
            _pageGO.transform.DORotate(new Vector3(0, 360, 0), 1).SetEase(Ease.Linear)
                .OnComplete(() => _displays.ToList().ForEach(d => d.SetActive(true))).SetAutoKill();
        }

        if (_nowPage == 4)
        {
            //半透明にする
            _rightArrow.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            //元の色にする
            _rightArrow.color = new Color(1, 1, 1, 1);
        }

    }

}
