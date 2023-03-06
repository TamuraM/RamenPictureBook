using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Header("フェード用のパネル")] private Image _fadePanel = default;

    private void Start()
    {
        _fadePanel.DOFade(0, 1.5f).SetEase(Ease.Linear)
            .OnComplete(() => _fadePanel.gameObject.SetActive(false)).SetAutoKill();
    }

    public void SceneChange(string sceneName)
    {
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(1, 1.5f).SetEase(Ease.Linear)
            .OnComplete(() => SceneManager.LoadScene(sceneName)).SetAutoKill(); //OnCompleteでシーン移動
    }

}
