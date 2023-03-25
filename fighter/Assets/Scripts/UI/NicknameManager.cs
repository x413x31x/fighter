using UnityEngine;
using TMPro;

public class NicknameManager : MonoBehaviour
{
    private CharacterStateManager _character;
    private TMP_Text _nickname;
    [SerializeField] private bool _isPlayer = true;

    private void Start()
    {
        if (_isPlayer)
        {
            _character = GameManager._player;
        }
        else
        {
            _character = GameManager._enemy;
        }
        _nickname = GetComponent<TMP_Text>();
        _nickname.text = _character._nickname;
    }
}
