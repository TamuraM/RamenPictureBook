using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>�^�C�g����ʂłǂ�Ԃ肩�}�ӂ��N���b�N������Ή�����V�[���ɔ�ԃX�N���v�g</summary>
public class SelectScene : MonoBehaviour
{
    [SerializeField, Header("�ǂ�Ԃ�")] private GameObject _bowl = default;
    [SerializeField, Header("�ǂ�Ԃ�ɃJ�[�\��������Ă鎞�ɕ\������I�u�W�F�N�g")] private GameObject _selectedBowl = default;
    [SerializeField, Header("�}��")] private GameObject _pictureBook = default;
    [SerializeField, Header("�}�ӂɃJ�[�\��������Ă鎞�ɕ\������I�u�W�F�N�g")] private GameObject _selectedPictureBook = default;
    [SerializeField] private bool _isSelectedBowl = false;
    [SerializeField] private bool _isSelectedPictureBook = false;

    //----UI�֌W---//
    [SerializeField, Header("������\������e�L�X�g")] private Text _ruleText = default;
    [SerializeField, Header("���[��������V�[���̐���")] private string _ruleEdit = default;
    [SerializeField, Header("�}�ӃV�[���̐���")] private string _rulePictureBook = default;
    [SerializeField, Header("�t�F�[�h�p�̉摜")] private Image _fadePanel = default;
    [SerializeField, Header("�t�F�[�h�ɂ����鎞��")] private float _fadeTime = 0.3f;
    private bool _isFade = false;

    void Start()
    {
        _selectedBowl.SetActive(false);
        _selectedPictureBook.SetActive(false);
        _ruleText.text = "";
    }

    void Update()
    {

        if(!_isFade) //�܂��t�F�[�h�A�E�g���ĂȂ��Ƃ�����������
        {
            //�J�[�\�����}�E�X�ɍ��킹�ē�����
            var mousePos = Input.mousePosition;
            var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z));
            gameObject.transform.position = worldPos;
        }

        if(Input.GetMouseButtonDown(0))
        {

            if (!_isFade)
            {

                if (_isSelectedBowl)
                {
                    Debug.Log("���[��������V�[���ֈړ������");
                    _isFade = true;
                    _fadePanel.DOFade(1, 0.3f).SetEase(Ease.Linear).OnComplete(() => SceneManager.LoadScene("Game")).SetAutoKill(); //OnComplete�ŃV�[���ړ�
                }
                else if (_isSelectedPictureBook)
                {
                    Debug.Log("���[�����}�ӃV�[���ֈړ������");
                    _isFade = true;
                    _fadePanel.DOFade(1, 0.3f).SetEase(Ease.Linear).OnComplete(() => SceneManager.LoadScene("PictureBook")).SetAutoKill(); //OnComplete�ŃV�[���ړ�
                }

            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject == _bowl)
        {
            _selectedBowl.SetActive(true);
            _isSelectedBowl = true;
            _ruleText.text = _ruleEdit;
            //SelectMode(_selectedBowl, _isSelectedBowl, true);
        }
        else if(other.gameObject == _pictureBook)
        {
            _selectedPictureBook.SetActive(true);
            _isSelectedPictureBook = true;
            _ruleText.text = _rulePictureBook;
            //SelectMode(_selectedPictureBook, _isSelectedPictureBook, true);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == _bowl)
        {
            _selectedBowl.SetActive(false);
            _isSelectedBowl = false;
            _ruleText.text = "";
            //SelectMode(_selectedBowl, _isSelectedBowl, false);
        }
        else if (other.gameObject == _pictureBook)
        {
            _selectedPictureBook.SetActive(false);
            _isSelectedPictureBook = false;
            _ruleText.text = "";
            //SelectMode(_selectedPictureBook, _isSelectedPictureBook, false);
        }

    }

    //private void SelectMode(GameObject mode, bool flg, bool ToF)
    //{
    //    mode.SetActive(ToF);
    //    flg = ToF;
    //}
}
