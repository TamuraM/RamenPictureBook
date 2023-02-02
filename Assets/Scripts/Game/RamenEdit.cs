using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

/// <summary>������Ă郉�[�����̏��</summary>
public class RamenEdit : MonoBehaviour
{
    [Tooltip("�X�[�v�̏��")]
    private Dictionary<string, bool> _soupInf =
        new Dictionary<string, bool> { { "�Ƃ񂱂�", false }, { "���傤��", false }, { "����", false }, { "�݂�", false }, { "�Ȃ�", true } };
    /// <summary>���̃X�[�v�̏��@true�ɂȂ��Ă���̂��I������Ă�</summary>
    public Dictionary<string, bool> SoupInf => _soupInf;

    [Tooltip("�߂�̏��")]
    private Dictionary<string, bool> _noodleInf =
        new Dictionary<string, bool> { { "�΂肩��", false }, { "������", false }, { "�ӂ�", false }, { "���炩��", false }, { "�Ȃ�", true } };
    /// <summary>���̂߂�̏��@true�ɂȂ��Ă���̂��I������Ă�</summary>
    public Dictionary<string, bool> NoodleInf => _noodleInf;

    [Tooltip("�g�b�s���O�̏��")]
    private Dictionary<string, int> _toppingInf =
        new Dictionary<string, int> { { "���t�����܂�", 0 }, { "�`���[�V���[", 0 }, { "�˂�", 0 }, { "�����}", 0 }, { "���₵", 0 }, { "�R�[��", 0 }, { "�̂�", 0 } };
    /// <summary>���̃g�b�s���O�̏��@���l�̐����������Ă�</summary>
    public Dictionary<string, int> ToppingInf => _toppingInf;

    [SerializeField, Header("�\�����Ă�X�[�v�̃Q�[���I�u�W�F�N�g")] private GameObject _soup = default;
    [SerializeField, Header("�\�����Ă�߂�̃Q�[���I�u�W�F�N�g")] private GameObject _noodle = default;
    [SerializeField, Header("�g�b�s���O�ł���ő�l")] private int _maxToppingCount = 10;
    [SerializeField, Header("�g�b�s���O��u���ꏊ")] private Transform[] _toppingTrans = new Transform[10];
    [Tooltip("������Ă�g�b�s���O�̐�")] private int _nowToppingCount = 0;

    //--UI�֌W--//
    [SerializeField, Header("�g�b�s���O���Ă鐔��\������e�L�X�g")] private Text _numberText = default;

    void Start()
    {
        _numberText.text = $"{_nowToppingCount}/{_maxToppingCount}";
    }

    void Update()
    {

    }

    /// <summary>�g�b�s���O�̐��̕\����ύX����</summary>
    private void NumberTextChange()
    {
        _numberText.text = $"{_nowToppingCount}/{_maxToppingCount}";

        if (_nowToppingCount == _maxToppingCount)
        {
            _numberText.color = Color.red;
        }
        else if (_nowToppingCount >= 8)
        {
            _numberText.color = Color.yellow;
        }
        else
        {
            _numberText.color = Color.white;
        }

    }

    /// <summary>�g�b�s���O�̋�ރ{�^���ɂ���֐��@�g�b�s���O��ǉ����邱�Ƃ��ł���</summary>
    /// <param name="topping"></param>
    public void Topping(string topping)
    {

        if (_nowToppingCount < _maxToppingCount)
        {
            _nowToppingCount++;
            //�w�肳�ꂽ�g�b�s���O��������
            _toppingInf[topping]++;
            NumberTextChange();
            Debug.Log($"{topping}��{_toppingInf[topping]}�u����Ă��܂�");
            //�w�肳�ꂽ�ʒu�ɋ�ނ�����
        }
        else
        {
            Debug.Log("����ȏ�g�b�s���O���邱�Ƃ͂ł��܂���");
        }

    }

    ///�g�b�s���O���ЂƂO�̏�Ԃɖ߂��{�^���̊֐����~����
    ///�g�b�s���O�̃{�^���������Ƃ���List�ɕۑ�
    ///���ЂƂ߂��{�^����������Ō�Ɋi�[����Ă�g�b�s���O�̐��l�����炵�āA
    ///�g�b�s���O����������ꏊ�����Ƃ��Ă���Ďv�������ǒu���Ă���I�u�W�F�N�gList���p�ӂ��Ȃ��Ƃ����Ȃ�����

    /// <summary>�X�[�v�̋�ރ{�^���ɂ���֐��@�X�[�v��ύX���邱�Ƃ��ł���</summary>
    /// <param name="topping"></param>
    public void Soup(string soup)
    {
        //�S��false�ɂ��Ă���A�ύX�����������true�ɂ���
        string[] keys = _soupInf.Keys.ToArray();

        foreach (var key in keys)
        {
            _soupInf[key] = false;
        }

        _soupInf[soup] = true;
        Debug.Log($"���̃X�[�v��{soup}�ł�");
        //�݂��߂��w�肳�ꂽ���̂ɕς���
    }

    /// <summary>�߂�̋�ރ{�^���ɂ���֐��@�߂��ύX���邱�Ƃ��ł���</summary>
    /// <param name="topping"></param>
    public void Noodle(string noodle)
    {
        //�S��false�ɂ��Ă���A�ύX�����������true�ɂ���
        string[] keys = _noodleInf.Keys.ToArray();

        foreach (var key in keys)
        {
            _noodleInf[key] = false;
        }

        _noodleInf[noodle] = true;
        Debug.Log($"���̂߂��{noodle}�ł�");

        //�u�Ȃ��v�ɂ����ꍇ�A�߂�̃I�u�W�F�N�g������
    }
}
