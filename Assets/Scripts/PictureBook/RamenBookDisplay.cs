using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class RamenBookDisplay : MonoBehaviour
{
    [SerializeField, Header("�y�[�W�̃Q�[���I�u�W�F�N�g")] private GameObject _pageGO = default;
    [SerializeField, Header("�\�����闓����")] private GameObject[] _displays = new GameObject[6];
    [SerializeField, Header("�ʐ^��\�����闓����")] private Image[] _imageDisplays = new Image[6];
    [SerializeField, Header("���O��\�����闓����")] private Text[] _nameDisplays = new Text[6];
    [SerializeField, Header("������\�����闓����")] private Text[] _explanationDisplays = new Text[6];
    [Tooltip("�\������index")] private int _displayIndex = default;
    [SerializeField, Header("�����")] private Image _leftArrow = default;
    [SerializeField, Header("�E���")] private Image _rightArrow = default;
    [Tooltip("���\�����Ă�y�[�W��")] private int _nowPage = 0;

    void Start()
    {
        _displayIndex = RamenRecord.Instance.MaxCount / (RamenRecord.Instance.MaxCount / _displays.Length);

        for (int i = 0; i < _displays.Length; i++)
        {
            var index = _displayIndex * _nowPage + i;

            if (RamenRecord.Instance.MyRamenCollection[index] == null)
            {
                _nameDisplays[i].text = "";
                _explanationDisplays[i].text = "�܂��o�^�����\n���܂���";
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

            //�y�[�W���߂���Ԕ�\���ɂ��āA���̃y�[�W�̓��e��\��
            for (int i = 0; i < _displays.Length; i++)
            {
                _displays[i].SetActive(false);
                var index = _displayIndex * _nowPage + i;

                if(RamenRecord.Instance.MyRamenCollection[index] == null)
                {
                    _nameDisplays[i].text = "";
                    _explanationDisplays[i].text = "�܂��o�^�����\n���܂���";
                }
                else
                {
                    _nameDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Name;
                    _explanationDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Explanation;
                }

            }
            
            //�E�����獶���ւ߂���
            _pageGO.transform.rotation = Quaternion.Euler(0, 0, 0);
            _pageGO.transform.DORotate(new Vector3(0, -180, 0), 1).SetEase(Ease.Linear)
                .OnComplete(() => _displays.ToList().ForEach(d => d.SetActive(true))).SetAutoKill();
            
        }
        
        if(_nowPage == 0)
        {
            //�������ɂ���
            _leftArrow.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            //���̐F�ɂ���
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

            //�y�[�W���߂���Ԕ�\���ɂ��āA���̃y�[�W�̓��e��\��
            for (int i = 0; i < _displays.Length; i++)
            {
                _displays[i].SetActive(false);
                var index = _displayIndex * _nowPage + i;

                if (RamenRecord.Instance.MyRamenCollection[index] == null)
                {
                    _nameDisplays[i].text = "";
                    _explanationDisplays[i].text = "�܂��o�^�����\n���܂���";
                }
                else
                {
                    _nameDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Name;
                    _explanationDisplays[i].text = RamenRecord.Instance.MyRamenCollection[index].Explanation;
                }
            }

            //��������E���ւ߂���
            _pageGO.transform.rotation = Quaternion.Euler(0, 180, 0);
            _pageGO.transform.DORotate(new Vector3(0, 360, 0), 1).SetEase(Ease.Linear)
                .OnComplete(() => _displays.ToList().ForEach(d => d.SetActive(true))).SetAutoKill();
        }

        if (_nowPage == 4)
        {
            //�������ɂ���
            _rightArrow.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            //���̐F�ɂ���
            _rightArrow.color = new Color(1, 1, 1, 1);
        }

    }

}
