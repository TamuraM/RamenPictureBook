using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Header("フェード用のパネル")] private Image _fadePanel = default;

    public void SceneChange(string sceneName)
    {
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(1, 0.3f).SetEase(Ease.Linear)
            .OnComplete(() => SceneManager.LoadScene(sceneName)).SetAutoKill(); //OnCompleteでシーン移動
    }

}
