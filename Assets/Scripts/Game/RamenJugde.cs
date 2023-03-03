using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>�ǂ�ȃ��[�������ł��������肷��</summary>
public class RamenJugde : MonoBehaviour
{
    [SerializeField, Header("'RamenEdit'")] private RamenEdit _ramenEdit = default;
    [Tooltip("�ł������������[�����̏��")] private RamenInf _ramenInf = default;
    [SerializeField, Header("�o���オ�������[�����̏���\������e�L�X�g")] private GameObject _ramenInfText = default;
    [Tooltip("�e�L�X�g")] private Text _text = default;

    void Start()
    {
        _text = _ramenInfText.GetComponent<Text>();
        _ramenInfText.SetActive(false);
        //�e���[�����̃p�����[�^������Ă�����������
        //�}�ӊǗ�����X�N���v�g����ł�
    }

    void Update()
    {

    }

    /// <summary>�����{�^���ɂ���֐��@�o���オ�������[�������ȂɃ��[���������肵����</summary>
    public void CompleteEdit()
    {
        _ramenInf = new RamenInf(_ramenEdit.SoupInf, _ramenEdit.NoodleInf, _ramenEdit.ToppingInf);

        //�Ƃ肠�����̓R���\�[���ɑS���\��������̂ƃe�L�X�g�ŕ\������
        string completeMessege = $"�����I\n[�X�[�v�F{_ramenInf.Soup}] [�߂�F{_ramenInf.Noodle}] \n" +
            $"[�g�b�s���O�F���t�����܂�{_ramenInf.Topping[0]}�A�`���[�V���[{_ramenInf.Topping[1]}�A�˂�{_ramenInf.Topping[2]}�A\n" +
            $"�����}{_ramenInf.Topping[3]}�A���₵{_ramenInf.Topping[4]}�A�R�[��{_ramenInf.Topping[5]}�A�̂�{_ramenInf.Topping[6]}]";
        _text.text = completeMessege;
        Debug.Log(completeMessege);
    }

}

/// <summary>�o���オ�������[�����̏���ۑ��ł���N���X</summary>
public class RamenInf
{
    private string _soup;
    private string _noodle;
    private int[] _topping;

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
        
        foreach(var key in soupKeys)
        {
            if(soup[key])
            {
                _soup = key;
                break;
            }
        }

        var noodleKeys = noodle.Keys;

        foreach(var key in noodleKeys)
        {
            if(noodle[key])
            {
                _noodle = key;
                break;
            }
        }

        //�z��ɐ��������i�[
        _topping = topping.Values.ToArray();
    }
}
