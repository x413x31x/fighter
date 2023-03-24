using UnityEngine;
using UnityEngine.UI;

public class HealthbarManager : MonoBehaviour
{
    private CharacterStateManager _character;
    private float _maxHealth;
    private Image _slider;
    [SerializeField] private bool _isPlayer;

    private void Start()
    {
        if (_isPlayer)
        {
            _character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStateManager>();
        }
        else
        {
            _character = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CharacterStateManager>();
        }
        _maxHealth = _character._maxHealth;
        _slider = GetComponent<Image>();
    }

    private void Update()
    {
        _slider.fillAmount = _character._currentHealth / _maxHealth;
    }
}
