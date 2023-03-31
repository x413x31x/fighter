using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<CharacterStateManager> _charactersPrefs;
    private string _currentPlayerCharacterName;
    [SerializeField] private ResourcesObject _resources;
    [SerializeField] private GameObject _cinemachineCameraPref;
    private Button _attackButton;

    [SerializeField] private GameObject _playerSpownPoint;
    [SerializeField] private GameObject _enemySpownPoint;
    public static CharacterStateManager _player;
    public static CharacterStateManager _enemy;

    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private Image _victoryImage;
    [SerializeField] private Sprite _victory;
    [SerializeField] private Sprite _defeat;
    [SerializeField] private TMP_Text _rewards;

    [SerializeField] private AudioManager _audioManager;
    private bool _gameIsOver = false;

    private int _gameCounter
    {
        get => PlayerPrefs.GetInt("GameCounter", 0);
        set => PlayerPrefs.SetInt("GameCounter", value);
    }
    [SerializeField] private InterAd _interAd;
    private int _reward;
    [SerializeField] private GameObject _adButton;

    private void Awake()
    {
        CreatePlayer();
        CreateEnemy();
        CreateCamera();
    }

    private void Update()
    {
        if (!_gameIsOver)
        {
            if (_player._isDead)
            {
                GameOver(false);
            }
            else if (_enemy._isDead)
            {
                GameOver(true);
            }
        }
    }

    private void CreatePlayer()
    {
        CharacterStateManager player = Instantiate(_charactersPrefs[FindPlayerCharacterIndex()]);
        player.transform.position = _playerSpownPoint.transform.position;
        player.tag = "Player";
        player._nickname = UIManager._nickname;
        player.gameObject.layer = LayerMask.NameToLayer("Player");
        _player = player;

        _attackButton = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Button>();
        _attackButton.onClick.AddListener(_player.Attack);
    }

    private void CreateEnemy()
    {
        int randomEnemyIndex = Random.Range(0, _charactersPrefs.Count);
        CharacterStateManager enemy = Instantiate(_charactersPrefs[randomEnemyIndex]);
        enemy.transform.position = _enemySpownPoint.transform.position;
        enemy.tag = "Enemy";
        enemy._nickname = Nicknames._nicknames[Random.Range(0, Nicknames._nicknames.Length)];
        enemy.gameObject.layer = LayerMask.NameToLayer("Enemy");
        enemy.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        enemy._isPlayer = false;
        _enemy = enemy;
    }

    private void CreateCamera()
    {
        GameObject camera = Instantiate(_cinemachineCameraPref);
        camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = _player.transform;
    }

    private int FindPlayerCharacterIndex()
    {
        _currentPlayerCharacterName = PlayerPrefs.GetString("CurrentCharacter");
        if(_currentPlayerCharacterName == "AlphaSpartan")
        {
            return 0;
        }
        else if(_currentPlayerCharacterName == "BravoStrongman")
        {
            return 1;
        }
        else if (_currentPlayerCharacterName == "CharlieNinja")
        {
            return 2;
        }
        else if (_currentPlayerCharacterName == "DeltaRobber")
        {
            return 3;
        }
        else if (_currentPlayerCharacterName == "EchoWarrior")
        {
            return 4;
        }
        else if (_currentPlayerCharacterName == "FoxtrotElfy")
        {
            return 5;
        }
        else if (_currentPlayerCharacterName == "GolfYoung")
        {
            return 6;
        }
        else if (_currentPlayerCharacterName == "HotelDevil")
        {
            return 7;
        }
        else
        {
            return 0;
        }
    }

    private void GameOver(bool _playerIsWin)
    {
        if (_playerIsWin)
        {
            int randomRewards = Random.Range(222, 444);
            EndGame(randomRewards, _victory, "Win");
            _resources.SetWins(1);
        }
        else
        {
            int randomRewards = Random.Range(111, 222);
            EndGame(randomRewards, _defeat, "Lose");
        }
        Destroy(_enemy.gameObject);
        _gameCounter++;
        if (_gameCounter % 5 == 0)
        {
            _interAd.ShowAd();
        }
    }

    private void EndGame(int reward, Sprite icon, string musicName)
    {
        _audioManager.Stop("BackgroundMusic");
        _audioManager.Play(musicName);
        _endGameScreen.SetActive(true);
        _victoryImage.sprite = icon;
        _rewards.text = reward.ToString();
        _resources.SetGold(reward);
        _reward = reward;
        _gameIsOver = true;
    }

    public void RewardForAd(bool isGoldReward)
    {
        _resources.SetGold(_reward);
        _adButton.SetActive(false);
    }
}
