using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>��ރ{�^�������E�ɓ������{�^���̃X�N���v�g</summary>
public class ArrowButton : MonoBehaviour
{
    [SerializeField, Header("��ރ{�^���̔w�i�̃Q�[���I�u�W�F�N�g")] private RectTransform _background = default;
    [Tooltip("�ŏ��̈ʒu")] private float _firstXpos = default;
    [SerializeField, Header("'KindButton'�������")] private KindButton _kindButton = default;

    void Start()
    {
        _firstXpos = _background.anchoredPosition.x;
    }

    /// <summary>
    /// �������������Ƃ��̓���
    /// ��ރ{�^���̍�����\�����邽�߁A�w�i���͉̂E�ɓ���
    /// </summary>
    /// <param name="moveRange"></param>
    public void LeftArrow(float moveRange)
    {
        //�ŏ��̈ʒu��荶���ɂ���Ƃ��������点��
        if(_background.anchoredPosition.x < _firstXpos)
        {
            float movedX = _background.anchoredPosition.x + moveRange;
            _background.anchoredPosition = new Vector3(movedX, _background.anchoredPosition.y);
        }
        
    }

    /// <summary>
    /// �E�����������Ƃ��̓���
    /// ��ރ{�^���̉E����\�����邽�߁A�w�i���͍̂��ɓ���
    /// </summary>
    /// <param name="moveRange"></param>
    public void RightArrow(float moveRange)
    {

        //�������Ă��ނ��Ƃ��Ă��āA����ɂ���ď���������
        if(_kindButton.GetNowKind == KindButton.Kind.Topping)
        {

            //�g�b�s���O�̎���2��܂ňړ����邩��AmoveRange��2�{�����������Ƃ�����������
            if(_background.anchoredPosition.x > _firstXpos - moveRange * 2)
            {
                float movedX = _background.anchoredPosition.x - moveRange;
                _background.anchoredPosition = new Vector3(movedX, _background.anchoredPosition.y);
            }
            
        }
        else
        {

            //���̑��̎���1��܂�
            if (_background.anchoredPosition.x > _firstXpos - moveRange)
            {
                float movedX = _background.anchoredPosition.x - moveRange;
                _background.anchoredPosition = new Vector3(movedX, _background.anchoredPosition.y);
            }

        }
        
    }
}
