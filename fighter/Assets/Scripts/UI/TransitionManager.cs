using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private Image _loadingBar;
    private float _progress = 0;
    private float _maxTime;

    private void Start()
    {
        _maxTime = Random.Range(5, 10);
        StartCoroutine(LoadAsync());
    }

    private IEnumerator LoadAsync()
    {
        AsyncOperation asynkLoad = SceneManager.LoadSceneAsync("GameScene");
        asynkLoad.allowSceneActivation = false;
        StartCoroutine(WaitForLoadingBar());
        while (!asynkLoad.isDone && _progress < _maxTime)
        {
            yield return null;
        }
        asynkLoad.allowSceneActivation = true;
    }

    private IEnumerator WaitForLoadingBar()
    {
        while (_progress < _maxTime)
        {
            yield return new WaitForEndOfFrame();
            _progress += Time.deltaTime;
            _loadingBar.fillAmount = _progress / _maxTime;
        }
    }

    public void OnCancelPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
