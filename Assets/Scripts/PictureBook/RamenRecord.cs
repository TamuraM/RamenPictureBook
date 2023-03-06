using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�����ō�������[������}�ӂɕۑ�����X�N���v�g �V���O���g��</summary>
public class RamenRecord : MonoBehaviour
{
    /// <summary>RamenRecord�̃C���X�^���X</summary>
    public static RamenRecord Instance;
    [Tooltip("�ۑ����Ă������X�g")] private RamenInf[] _myRamenCollection = new RamenInf[30];
    /// <summary>��������[�����̏���ۑ����Ă������X�g</summary>
    public RamenInf[] MyRamenCollection => _myRamenCollection;
    [Tooltip("���ڂɒǉ����邩")] private int _index = 0;
    [Tooltip("���X�g�ɓ���ő�l")] private int _maxCount = 30;
    /// <summary>�ۑ����Ă������X�g�ɓ���ő�l</summary>
    public int MaxCount => _maxCount;

    void Awake()
    {
        // ���̏����� Start() �ɏ����Ă��悢���AAwake() �ɏ������Ƃ������B
        // �Q�l: �C�x���g�֐��̎��s���� https://docs.unity3d.com/ja/2019.4/Manual/ExecutionOrder.html
        if (Instance)
        {
            // �C���X�^���X�����ɂ���ꍇ�́A�j������
            Debug.LogWarning($"SingletonSystem �̃C���X�^���X�͊��ɑ��݂���̂ŁA{gameObject.name} �͔j�����܂��B");
            Destroy(this.gameObject);
        }
        else
        {
            // ���̃N���X�̃C���X�^���X�����������ꍇ�́A������ DontDestroyOnload �ɒu��
            Instance = this;
            //���z�V�[��(DontDestroyOnLoad)�ɕۑ�����āA���̃V�[�����Ăяo���Ă�Destroy����Ȃ�
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {

        for(int i = 0; i < _maxCount; i++)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>�}�ӂɕۑ����邽�߂̊֐�</summary>
    public void SaveRamenToBook(RamenInf ramenInf)
    {
        //�ő�l���������ۑ����悤�Ƃ�����A�ŏ��ɖ߂�
        if(_index + 1 == _maxCount)
        {
            _index = 0;
        }

        //���X�g�ɕۑ�
        _myRamenCollection[_index] = ramenInf;
        _index++;
        Debug.Log($"�}�ӂɕۑ����܂����B���ۑ�����Ă郉�[������{_index}�ł��B");
    }
}
