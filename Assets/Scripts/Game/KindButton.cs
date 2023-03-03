using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>���u�����ނ̎�ނ�ύX����{�^���̃X�N���v�g</summary>
public class KindButton : MonoBehaviour
{
    /// <summary>0���X�[�v�A1���߂�A2���g�b�s���O�ɂ���</summary>
    [SerializeField, Header("���ꂼ��̎�ރ{�^���ɕK�v�ȏ�񂽂�")] private ButtonsInf[] _kindButtons = new ButtonsInf[3];
    [Tooltip("���̏��������₷���悤��Dictionary�ɂ���")] private Dictionary<string, RectTransform> _kindButtonRect = new Dictionary<string, RectTransform>();
    [Tooltip("���̏��������₷���悤��Dictionary�ɂ���")] private Dictionary<string, GameObject> _guzaiButtonGo = new Dictionary<string, GameObject>();
    //[Tooltip("��ރ{�^���w�i�̏����ʒu")] private Dictionary<string, Vector2> _guzaiButtonOriginPos = new Dictionary<string, Vector2>();
    //��̂�A��ؐ搶�������Ă���asset���g���邩���炵��

    //--UI�֌W--//
    [SerializeField, Header("��ރ{�^���̈ړ����")] Vector2 _movedUpper = default;
    [SerializeField, Header("��ރ{�^���̈ړ��扺")] Vector2 _movedLower = default;
    [SerializeField, Header("��ރ{�^�����߂�ꏊ")] RectTransform _originPos = default;
    [Tooltip("���̎�ރ{�^�����łĂ邩")] private bool _isShownOther = false;

    [SerializeField, Header("���̎�ނ�\������e�L�X�g")] private Text _kindText = default;

    /// <summary>���I���ł����ނ̎�ނ��Ǘ����Ă�</summary>
    public enum Kind
    {
        /// <summary>�X�[�v�̎�ނ�I�ׂ�</summary>
        Soup,
        /// <summary>�߂�̎�ނ�I�ׂ�</summary>
        Noodle,
        /// <summary>�g�b�s���O�̎�ނ�I�ׂ�</summary>
        Topping,
    }

    [Tooltip("���I���ł�����")] private Kind _nowKind = Kind.Soup;
    public Kind GetNowKind { get => _nowKind; }

    void Start()
    {

        //�����ݒ�
        for (int i = 0; i < _kindButtons.Length; i++)
        {
            _kindButtonRect.Add(_kindButtons[i].GetKind, _kindButtons[i].GetKindButton);
            _guzaiButtonGo.Add(_kindButtons[i].GetKind, _kindButtons[i].GetGuzaiButton);
            //_guzaiButtonOriginPos.Add(_kindButtons[i].GetKind, _kindButtons[i].GetGuzaiButton.GetComponent<RectTransform>().anchoredPosition);
        }

        _nowKind = Kind.Soup;
        _kindText.text = "�X�[�v";
    }

    /// <summary>
    /// ���̎�ނ��\������Ă�{�^���ɂ���@���̎�ރ{�^�����\�������
    /// </summary>
    public void ShowKindButton()
    {

        if(!_isShownOther) //�ق��̑I�������o�ĂȂ��Ƃ��A�o��
        {

            //���̎�ނɂ���ďo�Ă������ς��@���Ƃ�dotween�ɂ���
            switch (_nowKind)
            {
                case Kind.Soup:
                    _kindButtonRect["�߂�"].anchoredPosition = _movedUpper;
                    _kindButtonRect["�g�b�s���O"].anchoredPosition = _movedLower;
                    break;
                case Kind.Noodle:
                    _kindButtonRect["�X�[�v"].anchoredPosition = _movedUpper;
                    _kindButtonRect["�g�b�s���O"].anchoredPosition = _movedLower;
                    break;
                case Kind.Topping:
                    _kindButtonRect["�X�[�v"].anchoredPosition = _movedUpper;
                    _kindButtonRect["�߂�"].anchoredPosition = _movedLower;
                    break;
                default:
                    break;
            }

            _isShownOther = true;
        }
        else //�o�Ă鎞�A�ύX�����ɑI����������
        {
            //�S�����ɖ߂�
            var keys = _kindButtonRect.Keys;

            foreach(var key in keys)
            {
                _kindButtonRect[key].anchoredPosition = _originPos.anchoredPosition;
            }

            _isShownOther = false;
        }

    }

    /// <summary>�I���ł����ނ̋�ރ{�^����\������</summary>
    /// <param name="kind"></param>
    public void ChangeKind(string kind)
    {
        //��������S�������Ă���\�������������̂��o���@�e�L�X�g���ς���
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

    /// <summary>���I���ł����ނ̏�Ԃ�ύX����</summary>
    /// <param name="kind"></param>
    public void ChangeKind(int kind)
    {
        _nowKind = (Kind)kind;
    }

}

/// <summary>
/// ��ނƃQ�[���I�u�W�F�N�g���Z�b�g�œo�^������������@���̂������肻��
/// </summary>
[System.Serializable]
public class ButtonsInf
{
    [SerializeField, Header("��ނ̖��O")] private string _kind = default;
    /// <summary>��ނ̖��O</summary>
    public string GetKind { get => _kind; }
    [SerializeField, Header("��ރ{�^��")] private RectTransform _kindButton = default;
    /// <summary>��ރ{�^��</summary>
    public RectTransform GetKindButton { get => _kindButton; }
    [SerializeField, Header("��ރ{�^��")] private GameObject _guzaiButton = default;
    /// <summary>��ރ{�^��</summary>
    public GameObject GetGuzaiButton { get => _guzaiButton; }
}