using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�����ō�������[������}�ӂɕۑ�����X�N���v�g �V���O���g��</summary>
public class RamenRecord : MonoBehaviour
{
    /// <summary>RamenRecord�̃C���X�^���X</summary>
    public static RamenRecord Instance;
    [Tooltip("�ۑ����Ă������X�g")] private List<RamenInf> _myRamenCollection = new List<RamenInf>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>�}�ӂɕۑ����邽�߂̊֐�</summary>
    public void SaveRamenToBook(RamenInf ramenInf)
    {
        //���X�g�ɕۑ�
        _myRamenCollection.Add(ramenInf);
        Debug.Log($"�}�ӂɕۑ����܂����B���ۑ�����Ă郉�[������{_myRamenCollection.Count}�ł��B");

        //�����ς���������ۑ�����O�ɉ������Ȃ���
    }
}
