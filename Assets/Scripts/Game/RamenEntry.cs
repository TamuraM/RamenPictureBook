using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>�����{�^������������̓���</summary>
public class RamenEntry : MonoBehaviour
{
    [SerializeField, Header("RamenJugde")] private RamenJugde _ramenJugde = default;
    [SerializeField, Header("�u�����v�̃e�L�X�g����")] private GameObject[] _completeText = new GameObject[2];
    [SerializeField, Header("�ǂ�Ԃ�̎�������J�����̉�]�̒��S")] private GameObject _cameraPivot = default;
    [Tooltip("�����̓��͂ł��镔���̃��X�g�@���O�A����ҁA�������̏�")] private string[] _explanationList = new string[3];
    /// <summary>���R�ɋL�����ꂽ��̏��</summary>
    public string[] ExplanationList { get => _explanationList; }
    [Tooltip("���ܓ��͂��Ă镶��")] private string _nowTyping = "";
    [SerializeField, Header("���͂���Ƃ��̔w�i")] private GameObject _inputBackground = default;
    [SerializeField, Header("�Ȃɂ���͂��邩�̎w����\������e�L�X�g")] private Text _instructionsText = default;
    [SerializeField, Header("���͂���Ă镶����\������e�L�X�g")] private Text _inputText = default;
    [SerializeField, Header("���͂���L�[")] private GameObject _inputKey = default;
    [SerializeField, Header("�G���^�[�L�[�����@���O�A����ҁA�������")] private GameObject[] _enterkeys = new GameObject[3];
    [SerializeField, Header("�w���̕�����@���O�A����ҁA�������")] private string[] _instructions = new string[3];
    [Tooltip("���͂ł���ő啶����")] private int _maxStringLength = 10;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>���R�L���̎��Ɏg���@��������͂ł���</summary>
    /// <param name="moji"></param>
    public void Typing(string moji)
    {

        if (moji == "b") //b��������1��������
        {

            if (_nowTyping.Length != 0)
            {
                _nowTyping = _nowTyping.Substring(0, _nowTyping.Length - 1);
                _inputText.text = $"{_nowTyping}";
            }

        }
        else
        {

            if (_nowTyping.Length < _maxStringLength) //���͂ł���ő啶������ݒ肵�Ă�����
            {
                _nowTyping = $"{_nowTyping}{moji}";
                _inputText.text = $"{_nowTyping}";
            }

        }

    }

    /// <summary>�G���^�[�L�[���������Ƃ��̏����@���͂�����̂ɂ���ăL�[��ς���</summary>
    /// <param name="type"></param>
    public void EnterKey(int index)
    {
        //���͂��ꂽ���̂�z��ɓ���Ă���
        _explanationList[index] = _nowTyping;

        if(index != _enterkeys.Length - 1) //�Ō�̍��ڂ���Ȃ�������
        {
            //���ɓ��͂��邱�ƂɑΉ�����{�^�����o��������
            _enterkeys[index].SetActive(false);
            _enterkeys[index + 1].SetActive(true);
            //�w���ς���
            _instructionsText.text = _instructions[index + 1];
            _nowTyping = "";
            _inputText.text = _nowTyping;
        }
        else //�Ō�̍��ڂ�������
        {
            //�}�ӂɓo�^����
            _ramenJugde.SaveRamenToBook();
            //�^�C�g���{�^���Ɛ}�Ӄ{�^���\���H
        }

    }

    /// <summary>�J����������āu�����v�̕������o�Ă���</summary>
    public void CompleteAnimation()
    {
        //�ŏ��̎w��
        _instructionsText.text = _instructions[0];
        _cameraPivot.transform.DORotate(new Vector3(0, 180, 0), 7).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental).SetAutoKill();
        _completeText[0].SetActive(true);
        DOTween.Sequence()
            .Append(_completeText[0].transform.DOScale(new Vector3(1, 1, 1), 0.8f).SetEase(Ease.Linear).OnComplete(() => _completeText[1].SetActive(true)).SetAutoKill())
            .Append(_completeText[1].transform.DOScale(new Vector3(1, 1, 1), 0.8f).SetEase(Ease.Linear).SetAutoKill())
            .Append(_completeText[0].transform.DOScale(new Vector3(0, 0, 0), 0.8f).SetEase(Ease.Linear).SetAutoKill())
            .Append(_completeText[1].transform.DOScale(new Vector3(0, 0, 0), 0.8f).SetEase(Ease.Linear).OnComplete(() => _inputBackground.SetActive(true)).SetAutoKill())
            .Append(_inputBackground.GetComponent<Image>().DOFade(0.15f, 1.0f).SetEase(Ease.Linear).OnComplete(() => { _instructionsText.color = Color.black; _inputText.color = Color.black; _inputKey.SetActive(true); }).SetAutoKill());
    }


}
