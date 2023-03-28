using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<CharacterObject> _allCharacters;
    private CharacterObject _character;
    private string _currentCharacterName
    {
        get => PlayerPrefs.GetString("CurrentCharacter");
        set => PlayerPrefs.SetString("CurrentCharacter", value);
    }

    [SerializeField] private ResourcesObject _resources;
    [SerializeField] private UpgradedStatsObject _upgradedStats;
    [SerializeField] private UpgradePricesObject _prices;

    [SerializeField] private TMP_Text _goldCounter;
    [SerializeField] private TMP_Text _winsCounter;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _icon;

    [SerializeField] private TMP_Text _upgradeHealth;
    [SerializeField] private TMP_Text _upgradeDamage;
    [SerializeField] private TMP_Text _upgradeSpeed;
    [SerializeField] private TMP_Text _upgradeCritChance;
    [SerializeField] private TMP_Text _upgradeMissChance;
    [SerializeField] private TMP_Text _upgradebashChance;

    private int _healthPerUp = 200;
    private int _damagePerUp = 5;
    private int _speedPerUp = 1;
    private int _chancePerUp = 1;

    private void Start()
    {
        Refresh();
    }

    private void SetCharacter()
    {
        if (!PlayerPrefs.HasKey("CurrentCharacter"))
        {
            _currentCharacterName = "AlphaSpartan";
        }

        if(_currentCharacterName == _allCharacters[0].name)
        {
            _character = _allCharacters[0];
        }
        else if(_currentCharacterName == _allCharacters[1].name)
        {
            _character = _allCharacters[1];
        }
        else if (_currentCharacterName == _allCharacters[2].name)
        {
            _character = _allCharacters[2];
        }
        else if (_currentCharacterName == _allCharacters[3].name)
        {
            _character = _allCharacters[3];
        }
        else if (_currentCharacterName == _allCharacters[4].name)
        {
            _character = _allCharacters[4];
        }
        else if (_currentCharacterName == _allCharacters[5].name)
        {
            _character = _allCharacters[5];
        }
        else if (_currentCharacterName == _allCharacters[6].name)
        {
            _character = _allCharacters[6];
        }
        else if (_currentCharacterName == _allCharacters[7].name)
        {
            _character = _allCharacters[7];
        }
    }

    private void SetResources()
    {
        _goldCounter.text = _resources.GetGold().ToString();
        _winsCounter.text = _resources.GetWins().ToString();
    }

    private void SetDescription()
    {
        int health = _character._health + _upgradedStats.GetHealth();
        int damage = _character._damage + _upgradedStats.GetDamage();
        int speed = _character._speed + _upgradedStats.GetSpeed();
        float attackTime = _character._attackTime;
        int critChance = _character._critChance + _upgradedStats.GetCritChance();
        int missChance = _character._missChance + _upgradedStats.GetMissChance();
        int bashChance = _character._bashChance + _upgradedStats.GetBashChance();

        _description.text =
            "Health: " + health.ToString() +
            "\nDamage: " + damage.ToString() +
            "\nSpeed: " + speed.ToString() +
            "\nAttack time: " + attackTime.ToString() +
            "\nCrit chance: " + critChance.ToString() + "%" +
            "\nMiss chance: " + missChance.ToString() + "%" +
            "\nBash chance: " + bashChance.ToString() + "%";
    }

    private void SetUpgrades()
    {
        _upgradeHealth.text = _prices.GetGoldForHealth().ToString() + " gold = 200 health";
        _upgradeDamage.text = _prices.GetGoldForDamage().ToString() + " gold = 5 damage";
        _upgradeSpeed.text = _prices.GetGoldForSpeed().ToString() + " gold = 1 speed";
        _upgradeCritChance.text = _prices.GetGoldForCritChance().ToString() + " gold = 1% crit";
        _upgradeMissChance.text = _prices.GetGoldForMissChance().ToString() + " gold = 1% miss";
        _upgradebashChance.text = _prices.GetGoldForBashChance().ToString() + " gold = 1% bash";
    }

    private void SetIcon()
    {
        _icon.sprite = _character._icon;
    } 

    private void Refresh()
    {
        SetCharacter();
        SetResources();
        SetDescription();
        SetUpgrades();
        SetIcon();
    }

    public void OnHealthPressed()
    {
        if(_prices.GetGoldForHealth() > _resources.GetGold())
        {
            return;
        }
        _upgradedStats.SetHealth(_healthPerUp);
        _resources.SetGold(-_prices.GetGoldForHealth());
        _prices.IncreasedGoldForHealth();

        Refresh();
    }

    public void OnDamagePressed()
    {
        if (_prices.GetGoldForDamage() > _resources.GetGold())
        {
            return;
        }
        _upgradedStats.SetDamage(_damagePerUp);
        _resources.SetGold(-_prices.GetGoldForDamage());
        _prices.IncreasedGoldForDamage();

        Refresh();
    }

    public void OnSpeedPressed()
    {
        if (_prices.GetGoldForSpeed() > _resources.GetGold())
        {
            return;
        }
        _upgradedStats.SetSpeed(_speedPerUp);
        _resources.SetGold(-_prices.GetGoldForSpeed());
        _prices.IncreasedGoldForSpeed();

        Refresh();
    }

    public void OnCritChancePressed()
    {
        if (_prices.GetGoldForCritChance() > _resources.GetGold())
        {
            return;
        }
        _upgradedStats.SetCritChance(_chancePerUp);
        _resources.SetGold(-_prices.GetGoldForCritChance());
        _prices.IncreasedGoldForCritChance();
        Refresh();
    }

    public void OnMissChancePressed()
    {
        if (_prices.GetGoldForMissChance() > _resources.GetGold())
        {
            return;
        }
        _upgradedStats.SetMissChance(_chancePerUp);
        _resources.SetGold(-_prices.GetGoldForMissChance());
        _prices.IncreasedGoldForMissChance();
        Refresh();
    }

    public void OnBashChancePressed()
    {
        if (_prices.GetGoldForBashChance() > _resources.GetGold())
        {
            return;
        }
        _upgradedStats.SetBashChance(_chancePerUp);
        _resources.SetGold(-_prices.GetGoldForBashChance());
        _prices.IncreasedGoldForBashChance();
        Refresh();
    }

    public void OnAlphaPressed()
    {
        _currentCharacterName = "AlphaSpartan";
        Refresh();
    }

    public void OnBravoPressed()
    {
        _currentCharacterName = "BravoStrongman";
        Refresh();
    }

    public void OnCharliePressed()
    {
        Refresh();
    }

    public void OnDeltaPressed()
    {
        Refresh();
    }

    public void OnEchoPressed()
    {
        Refresh();
    }

    public void OnFoxtrotPressed()
    {
        Refresh();
    }

    public void OnGolfPressed()
    {
        Refresh();
    }

    public void OnHotelPressed()
    {
        Refresh();
    }
}
