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
    [SerializeField] private TMP_Text _discription;


    private void Start()
    {
        CheckPrefs();
        SetResources();
        SetDiscription();
    }

    public void SetResources()
    {
        _goldCounter.text = _gold.ToString();
        _winsCounter.text = _wins.ToString();
    }

    public void SetDiscription()
    {
        _discription.text =
            "Health: " + _health.ToString() +
            "\nDamage: " + _damage.ToString() +
            "\nSpeed: " + _speed.ToString() +
            "\nAttack time: " + _attackTime.ToString() +
            "\nCrit chance: " + _critChance.ToString() + "%" +
            "\nMiss chance: " + _missChance.ToString() + "%" +
            "\nBash chance: " + _bashChance.ToString() + "%";
    }

    private void CheckPrefs()
    {
        if (!PlayerPrefs.HasKey("Gold"))
        {
            _gold = 100;
        }
        if (!PlayerPrefs.HasKey("Wins"))
        {
            _wins = 0;
        }
        if (!PlayerPrefs.HasKey("Health"))
        {
            _health = 1000;
        }
        if (!PlayerPrefs.HasKey("Damage"))
        {
            _damage = 25;
        }
        if (!PlayerPrefs.HasKey("Speed"))
        {
            _speed = 5;
        }
        if (!PlayerPrefs.HasKey("AttackTime"))
        {
            _attackTime = 0.5f;
        }
        if (!PlayerPrefs.HasKey("CritChance"))
        {
            _critChance = 15;
        }
        if (!PlayerPrefs.HasKey("MissChance"))
        {
            _missChance = 15;
        }
        if (!PlayerPrefs.HasKey("BashChance"))
        {
            _bashChance = 15;
        }
    }
}
