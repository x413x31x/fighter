using UnityEngine;


[CreateAssetMenu(fileName = "NewUpgradePrices", menuName = "UpgradePrices")]

public class UpgradePricesObject : ScriptableObject
{
    private int _goldForHealth
    {
        get => PlayerPrefs.GetInt("GoldForHealth");
        set => PlayerPrefs.SetInt("GoldForHealth", value);
    }
    private int _goldForDamage
    {
        get => PlayerPrefs.GetInt("GoldForDamage");
        set => PlayerPrefs.SetInt("GoldForDamage", value);
    }
    private int _goldForSpeed
    {
        get => PlayerPrefs.GetInt("GoldForSpeed");
        set => PlayerPrefs.SetInt("GoldForSpeed", value);
    }
    private int _goldForCritChance
    {
        get => PlayerPrefs.GetInt("GoldForCritChance");
        set => PlayerPrefs.SetInt("GoldForCritChance", value);
    }
    private int _goldForMissChance
    {
        get => PlayerPrefs.GetInt("GoldForMissChance");
        set => PlayerPrefs.SetInt("GoldForMissChance", value);
    }
    private int _goldForBashChance
    {
        get => PlayerPrefs.GetInt("GoldForBashChance");
        set => PlayerPrefs.SetInt("GoldForBashChance", value);
    }

    public int GetGoldForHealth()
    {
        if (!PlayerPrefs.HasKey("GoldForHealth"))
        {
            _goldForHealth = 200;
        }
        return _goldForHealth;
    }

    public void IncreasedGoldForHealth()
    {
        if (!PlayerPrefs.HasKey("GoldForHealth"))
        {
            _goldForHealth = 200;
        }
        _goldForHealth *= 2;
    }

    public int GetGoldForDamage()
    {
        if (!PlayerPrefs.HasKey("GoldForDamage"))
        {
            _goldForDamage = 200;
        }
        return _goldForDamage;
    }

    public void IncreasedGoldForDamage()
    {
        if (!PlayerPrefs.HasKey("GoldForDamage"))
        {
            _goldForDamage = 200;
        }
        _goldForDamage *= 2;
    }

    public int GetGoldForSpeed()
    {
        if (!PlayerPrefs.HasKey("GoldForSpeed"))
        {
            _goldForSpeed = 200;
        }
        return _goldForSpeed;
    }

    public void IncreasedGoldForSpeed()
    {
        if (!PlayerPrefs.HasKey("GoldForSpeed"))
        {
            _goldForSpeed = 200;
        }
        _goldForSpeed *= 2;
    }

    public int GetGoldForCritChance()
    {
        if (!PlayerPrefs.HasKey("GoldForCritChance"))
        {
            _goldForCritChance = 200;
        }
        return _goldForCritChance;
    }

    public void IncreasedGoldForCritChance()
    {
        if (!PlayerPrefs.HasKey("GoldForCritChance"))
        {
            _goldForCritChance = 200;
        }
        _goldForCritChance *= 2;
    }

    public int GetGoldForMissChance()
    {
        if (!PlayerPrefs.HasKey("GoldForMissChance"))
        {
            _goldForMissChance = 200;
        }
        return _goldForMissChance;
    }

    public void IncreasedGoldForMissChance()
    {
        if (!PlayerPrefs.HasKey("GoldForMissChance"))
        {
            _goldForMissChance = 200;
        }
        _goldForMissChance *= 2;
    }

    public int GetGoldForBashChance()
    {
        if (!PlayerPrefs.HasKey("GoldForBashChance"))
        {
            _goldForBashChance = 200;
        }
        return _goldForBashChance;
    }

    public void IncreasedGoldForBashChance()
    {
        if (!PlayerPrefs.HasKey("GoldForBashChance"))
        {
            _goldForBashChance = 200;
        }
        _goldForBashChance *= 2;
    }
}
