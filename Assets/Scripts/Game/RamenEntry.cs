using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>�����{�^������������̓���</summary>
public class RamenEntry : MonoBehaviour
{
    [SerializeField, Header("�u�����v�̃e�L�X�g����")] private GameObject[] _completeText = new GameObject[2];
    [SerializeField, Header("�ǂ�Ԃ�̎�������J�����̉�]�̒��S")] private GameObject _cameraPivot = default;
    [Tooltip("���[�����̐���")] private string _explanation = default;
    [Tooltip("���ܓ��͂��Ă镶��")] private string _nowTyping = default;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>���R�L���̎��Ɏg���@��������͂ł���</summary>
    /// <param name="moji"></param>
    public void Typing(char moji)
    {
        _nowTyping = $"{_nowTyping}{moji}";
    }

    /// <summary>�J����������āu�����v�̕������o�Ă���</summary>
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
