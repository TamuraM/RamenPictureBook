using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>タイトル画面でどんぶりか図鑑をクリックしたら対応するシーンに飛ぶスクリプト</summary>
public class SelectScene : MonoBehaviour
{
    [SerializeField, Header("どんぶり")] private GameObject _bowl = default;
    [SerializeField, Header("どんぶりにカーソルが乗ってる時に表示するオブジェクト")] private GameObject _selectedBowl = default;
    [SerializeField, Header("図鑑")] private GameObject _pictureBook = default;
    [SerializeField, Header("図鑑にカーソルが乗ってる時に表示するオブジェクト")] private GameObject _selectedPictureBook = default;
    [SerializeField] private bool _isSelectedBowl = false;
    [SerializeField] private bool _isSelectedPictureBook = false;

    //----UI関係---//
    [SerializeField, Header("説明を表示するテキスト")] private Text _ruleText = default;
    [SerializeField, Header("ラーメン制作シーンの説明")] private string _ruleEdit = default;
    [SerializeField, Header("図鑑シーンの説明")] private string _rulePictureBook = default;
    [SerializeField, Header("フェード用の画像")] private Image _fadePanel = default;
    [SerializeField, Header("フェードにかかる時間")] private float _fadeTime = 0.3f;
    private bool _isFade = false;

    void Start()
    {
        _selectedBowl.SetActive(false);
        _selectedPictureBook.SetActive(false);
        _ruleText.text = "";
    }

    void Update()
    {

        if(!_isFade) //まだフェードアウトしてないときだけ動くよ
        {
            //カーソルをマウスに合わせて動かす
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
                    Debug.Log("ラーメン制作シーンへ移動するよ");
                    _isFade = true;
                    _fadePanel.DOFade(1, 0.3f).SetEase(Ease.Linear).OnComplete(() => SceneManager.LoadScene("Game")).SetAutoKill(); //OnCompleteでシーン移動
                }
                else if (_isSelectedPictureBook)
                {
                    Debug.Log("ラーメン図鑑シーンへ移動するよ");
                    _isFade = true;
                    _fadePanel.DOFade(1, 0.3f).SetEase(Ease.Linear).OnComplete(() => SceneManager.LoadScene("PictureBook")).SetAutoKill(); //OnCompleteでシーン移動
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
