using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<CharacterStateManager> _charactersPrefs;
    private string _currentPlayerCharacterName;
    [SerializeField] private GameObject _cinemachineCameraPref;
    private Button _attackButton;

    [SerializeField] private GameObject _playerSpownPoint;
    [SerializeField] private GameObject _enemySpownPoint;
    public static CharacterStateManager _player;
    public static CharacterStateManager _enemy;

    private void Awake()
    {
        CreatePlayer();
        CreateEnemy();
        CreateCamera();
    }

    private void Update()
    {
        if (_player._isDead || _enemy._isDead)
        {
            GameOver();
        }
    }

    private void CreatePlayer()
    {
        CharacterStateManager player = Instantiate(_charactersPrefs[FindPlayerCharacterIndex()]);
        player.transform.position = _playerSpownPoint.transform.position;
        player.tag = "Player";
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

    private void GameOver()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
