using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�����ō�������[������}�ӂɕۑ�����X�N���v�g �V���O���g��</summary>
public class RamenRecord : MonoBehaviour
{
    public static RamenRecord Instance;
    [Tooltip("�ۑ����Ă������X�g")] private int i = 0;

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
}
