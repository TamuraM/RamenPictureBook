using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>�ǂ�ȃ��[�������ł��������肷��</summary>
public class RamenJugde : MonoBehaviour
{
    [SerializeField, Header("'RamenEdit'")] private RamenEdit _ramenEdit = default;
    [SerializeField, Header("'RamenEntry'")] private RamenEntry _ramenEntry = default;
    [Tooltip("�ł������������[�����̏��")] private RamenInf _ramenInf = default;
    [SerializeField, Header("�o���オ�������[�����̏���\������e�L�X�g")] private GameObject _ramenInfText = default;
    [Tooltip("�e�L�X�g")] private Text _text = default;
    [SerializeField, Header("�I���_�C�A���O���o���Ƃ��ɏ������̂���")] private GameObject[] _editUIGo = new GameObject[6];
    [SerializeField, Header("�I���_�C�A���O")] private GameObject _dialog = default;
    [SerializeField, Header("�����A�j���[�V�����̎��̃J����")] private GameObject _subCamera = default;
    [SerializeField, Header("���Ƃ��Ƃ̃J����")] private GameObject _mainCamera = default;

    void Start()
    {
        _text = _ramenInfText.GetComponent<Text>();
        _ramenInfText.SetActive(false);
        //�e���[�����̃p�����[�^������Ă�����������
        //�}�ӊǗ�����X�N���v�g����ł�
    }

    /// <summary>�����{�^���ɂ���֐��@������I�����邩�����Ă���</summary>
    public void CompleteEdit()
    {
        //�u�I������H�v�I�ȃ_�C�A���O�o��
        foreach (var g in _editUIGo)
        {
            g.SetActive(false);
        }

        _dialog.SetActive(true);
    }

    /// <summary>�_�C�A���O�̃{�^���ɂ���@true�́u�͂��v�Afalse�́u�������v</summary>
    /// <param name="flg"></param>
    public void EndEdit(bool flg)
    {

        if (flg) //����I��
        {
            //�J�������[�N�ς���
            _dialog.SetActive(false);
            _subCamera.SetActive(true);
            _mainCamera.SetActive(false);
            _ramenEntry.CompleteAnimation();
        }
        else //���쑱�s
        {
            _dialog.SetActive(false);

            //�_�C�A���O�����Č��ɖ߂�
            foreach (var g in _editUIGo)
            {
                g.SetActive(true);
            }

        }

    }

    /// <summary>�}�ӂɓo�^������e���S���o���オ�������ɉ����{�^���ɂ���֐��@�}�ӂɓo�^���܂�</summary>
    public void SaveRamenToBook()
    {
        RamenRecord.Instance.SaveRamenToBook(_ramenInf);
    }

}

/// <summary>�o���オ�������[�����̏���ۑ��ł���N���X</summary>
public class RamenInf
{
    private string _soup;
    private string _noodle;
    private int[] _topping;
    //�������A�ʐ^�A���O
    private string _name;
    private string _explanatio;

    /// <summary>�����������[�����̃X�[�v</summary>
    public string Soup => _soup;
    /// <summary>�����������[�����̂߂�̂�����</summary>
    public string Noodle => _noodle;
    /// <summary>
    /// �����������[�����̃g�b�s���O�̐�
    /// 0���t�����܂��A1�`���[�V���[�A2�˂��A3�����}�A4���₵�A5�R�[���A6�̂�
    /// </summary>
    public int[] Topping => _topping;

    public RamenInf(Dictionary<string, bool> soup, Dictionary<string, bool> noodle, Dictionary<string, int> topping)
    {
        //���[�v�őS���m�F���āAtrue�ɂȂ��Ă�Ƃ���ۑ�
        var soupKeys = soup.Keys;

        foreach (var key in soupKeys)
        {
            if (soup[key])
            {
                _soup = key;
                break;
            }
        }

        var noodleKeys = noodle.Keys;

        foreach (var key in noodleKeys)
        {
            if (noodle[key])
            {
                _noodle = key;
                break;
            }
        }

        //�z��ɐ��������i�[
        _topping = topping.Values.ToArray();
    }
}
