using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField, Header("オーディオソース")] private AudioSource _audioSource = default;
    [SerializeField, Header("クリックしたときの音")] private AudioClip _click = default;
    [SerializeField, Header("'SceneChanger")] private SceneChanger _sceneChanger = default;
    [SerializeField, Header("説明を表示するテキスト")] private Text _ruleText = default;
    [SerializeField, Header("ラーメン制作シーンの説明")] private string _ruleEdit = default;
    [SerializeField, Header("図鑑シーンの説明")] private string _rulePictureBook = default;
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
                    _audioSource.PlayOneShot(_click, 1.5f);
                    _isFade = true;
                    _sceneChanger.SceneChange("Game");
                }
                else if (_isSelectedPictureBook)
                {
                    Debug.Log("ラーメン図鑑シーンへ移動するよ");
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
