using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthbarManager : MonoBehaviour
{
    private CharacterStateManager _character;
    private float _maxHealth;
    private Image _slider;
    private TMP_Text _healthCounter;
    [SerializeField] private Sprite _yellow;
    [SerializeField] private Sprite _red;
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
        _healthCounter = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        if(_character._currentHealth / _maxHealth <= 0.6 && _character._currentHealth / _maxHealth > 0.3)
        {
            _slider.sprite = _yellow;
        }
        else if(_character._currentHealth / _maxHealth <= 0.3)
        {
            _slider.sprite = _red;
        }
        _healthCounter.text = _character._currentHealth.ToString();
        _slider.fillAmount = _character._currentHealth / _maxHealth;
    }
}