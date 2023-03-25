using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<CharacterStateManager> _charactersPrefs;
    [SerializeField] private GameObject _cinemachineCameraPref;
    private Button _attackButton;

    [SerializeField] private GameObject _playerSpownPoint;
    [SerializeField] private GameObject _enemySpownPoint;
    public static CharacterStateManager _player;
    public static CharacterStateManager _enemy;

    private void Start()
    {
        CreatePlayer();
        CreateEnemy();
        CreateCamera();
    }

    private void CreatePlayer()
    {
        CharacterStateManager player = Instantiate(_charactersPrefs[0]);
        player.transform.position = _playerSpownPoint.transform.position;
        player.tag = "Player";
        player.gameObject.layer = LayerMask.NameToLayer("Player");
        _player = player;

        _attackButton = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<Button>();
        _attackButton.onClick.AddListener(_player.Attack);
    }

    private void CreateEnemy()
    {
        CharacterStateManager enemy = Instantiate(_charactersPrefs[0]);
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
}
