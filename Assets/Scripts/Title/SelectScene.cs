using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField, Header("�I�[�f�B�I�\�[�X")] private AudioSource _audioSource = default;
    [SerializeField, Header("�N���b�N�����Ƃ��̉�")] private AudioClip _click = default;
    [SerializeField, Header("'SceneChanger")] private SceneChanger _sceneChanger = default;
    [SerializeField, Header("������\������e�L�X�g")] private Text _ruleText = default;
    [SerializeField, Header("���[��������V�[���̐���")] private string _ruleEdit = default;
    [SerializeField, Header("�}�ӃV�[���̐���")] private string _rulePictureBook = default;
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
                    _audioSource.PlayOneShot(_click, 1.5f);
                    _isFade = true;
                    _sceneChanger.SceneChange("Game");
                }
                else if (_isSelectedPictureBook)
                {
                    Debug.Log("���[�����}�ӃV�[���ֈړ������");
                    _audioSource.PlayOneShot(_click, 1.5f);
                    _isFade = true;
                    _sceneChanger.SceneChange("PictureBook");
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
        }
        else if(other.gameObject == _pictureBook)
        {
            _selectedPictureBook.SetActive(true);
            _isSelectedPictureBook = true;
            _ruleText.text = _rulePictureBook;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == _bowl)
        {
            _selectedBowl.SetActive(false);
            _isSelectedBowl = false;
            _ruleText.text = "";
        }
        else if (other.gameObject == _pictureBook)
        {
            _selectedPictureBook.SetActive(false);
            _isSelectedPictureBook = false;
            _ruleText.text = "";
        }

    }

}
