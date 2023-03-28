using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int _gold
    {
        get => PlayerPrefs.GetInt("Gold");
        set => PlayerPrefs.SetInt("Gold", value);
    }
    [SerializeField] private TMP_Text _goldCounter;
    private int _wins
    {
        get => PlayerPrefs.GetInt("Wins");
        set => PlayerPrefs.SetInt("Wins", value);
    }
    [SerializeField] private TMP_Text _winsCounter;

    private int _health
    {
        get => PlayerPrefs.GetInt("Health");
        set => PlayerPrefs.SetInt("Health", value);
    }
    private int _damage
    {
        get => PlayerPrefs.GetInt("Damage");
        set => PlayerPrefs.SetInt("Damage", value);
    }
    private int _speed
    {
        get => PlayerPrefs.GetInt("Speed");
        set => PlayerPrefs.SetInt("Speed", value);
    }
    private float _attackTime
    {
        get => PlayerPrefs.GetFloat("AttackTime");
        set => PlayerPrefs.GetFloat("AttackTime", value);
    }
    private int _critChance
    {
        get => PlayerPrefs.GetInt("CritChance");
        set => PlayerPrefs.SetInt("CritChance", value);
    }
    private int _missChance
    {
        get => PlayerPrefs.GetInt("MissChance");
        set => PlayerPrefs.SetInt("MissChance", value);
    }
    private int _bashChance
    {
        get => PlayerPrefs.GetInt("BashChance");
        set => PlayerPrefs.SetInt("BashChance", value);
    }
    [SerializeField] private TMP_Text _description;

    private int _goldForHealth
    {
        get => PlayerPrefs.GetInt("GoldForHealth");
        set => PlayerPrefs.SetInt("GoldForHealth", value);
    }
    [SerializeField] private TMP_Text _upgradeHealth;
    private int _goldForDamage
    {
        get => PlayerPrefs.GetInt("GoldForDamage");
        set => PlayerPrefs.SetInt("GoldForDamage", value);
    }
    [SerializeField] private TMP_Text _upgradeDamage;
    private int _goldForSpeed
    {
        get => PlayerPrefs.GetInt("GoldForSpeed");
        set => PlayerPrefs.SetInt("GoldForSpeed", value);
    }
    [SerializeField] private TMP_Text _upgradeSpeed;
    private int _goldForCritChance
    {
        get => PlayerPrefs.GetInt("GoldForCritChance");
        set => PlayerPrefs.SetInt("GoldForCritChance", value);
    }
    [SerializeField] private TMP_Text _upgradeCritChance;
    private int _goldForMissChance
    {
        get => PlayerPrefs.GetInt("GoldForMissChance");
        set => PlayerPrefs.SetInt("GoldForMissChance", value);
    }
    [SerializeField] private TMP_Text _upgradeMissChance;
    private int _goldForBashChance
    {
        get => PlayerPrefs.GetInt("GoldForBashChance");
        set => PlayerPrefs.SetInt("GoldForBashChance", value);
    }
    [SerializeField] private TMP_Text _upgradebashChance;

    private void Start()
    {
        CheckPrefs();
        SetResources();
        SetDescription();
        SetUpgrades();
    }

    private void SetResources()
    {
        _goldCounter.text = _gold.ToString();
        _winsCounter.text = _wins.ToString();
    }

    private void SetUpgrades()
    {
        _upgradeHealth.text = _goldForHealth.ToString() + " gold = 200 health";
        _upgradeDamage.text = _goldForDamage.ToString() + " gold = 5 damage";
        _upgradeSpeed.text = _goldForSpeed.ToString() + " gold = 1 speed";
        _upgradeCritChance.text = _goldForCritChance.ToString() + " gold = 1% crit";
        _upgradeMissChance.text = _goldForMissChance.ToString() + " gold = 1% miss";
        _upgradebashChance.text = _goldForBashChance.ToString() + " gold = 1% bash";
    }

    private void SetDescription()
    {
        _description.text =
            "Health: " + _health.ToString() +
            "\nDamage: " + _damage.ToString() +
            "\nSpeed: " + _speed.ToString() +
            "\nAttack time: " + _attackTime.ToString() +
            "\nCrit chance: " + _critChance.ToString() + "%" +
            "\nMiss chance: " + _missChance.ToString() + "%" +
            "\nBash chance: " + _bashChance.ToString() + "%";
    }

    public void OnHealthPressed()
    {
        if(_goldForHealth > _gold)
        {
            return;
        }
        _health += 200;
        _gold -= _goldForHealth;
        _goldForHealth *= 2;

        SetDescription();
        SetUpgrades();
    }

    public void OnDamagePressed()
    {
        SetDescription();
        SetUpgrades();
    }

    public void OnSpeedPressed()
    {
        SetDescription();
        SetUpgrades();
    }

    public void OnCritChancePressed()
    {
        SetDescription();
        SetUpgrades();
    }

    public void OnMissChancePressed()
    {
        SetDescription();
        SetUpgrades();
    }

    public void OnBashChancePressed()
    {
        SetDescription();
        SetUpgrades();
    }

    private void CheckPrefs()
    {
        if (!PlayerPrefs.HasKey("Gold"))
        {
            _gold = 100;
            _wins = 0;
            _health = 1000;
            _damage = 25;
            _speed = 5;
            _attackTime = 0.5f;
            _critChance = 15;
            _missChance = 15;
            _bashChance = 15;
        }
        if (!PlayerPrefs.HasKey("GoldForHealth"))
        {
            _goldForHealth = 200;
            _goldForDamage = 200;
            _goldForSpeed = 200;
            _goldForCritChance = 200;
            _goldForMissChance = 200;
            _goldForBashChance = 200;
        }
    }
}
