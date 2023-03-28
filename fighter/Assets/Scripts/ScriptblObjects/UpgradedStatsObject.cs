using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgradedStats", menuName = "UpgradedStats")]

public class UpgradedStatsObject : ScriptableObject
{
    private int _health
    {
        get => PlayerPrefs.GetInt("UpgradedHealth");
        set => PlayerPrefs.SetInt("UpgradedHealth", value);
    }
    private int _damage
    {
        get => PlayerPrefs.GetInt("UpgradedDamage");
        set => PlayerPrefs.SetInt("UpgradedDamage", value);
    }
    private int _speed
    {
        get => PlayerPrefs.GetInt("UpgradedSpeed");
        set => PlayerPrefs.SetInt("UpgradedSpeed", value);
    }
    private int _critChance
    {
        get => PlayerPrefs.GetInt("UpgradedCritChance");
        set => PlayerPrefs.SetInt("UpgradedCritChance", value);
    }
    private int _missChance
    {
        get => PlayerPrefs.GetInt("UpgradedMissChance");
        set => PlayerPrefs.SetInt("UpgradedMissChance", value);
    }
    private int _bashChance
    {
        get => PlayerPrefs.GetInt("UpgradedBashChance");
        set => PlayerPrefs.SetInt("UpgradedBashChance", value);
    }

    public int GetHealth()
    {
        if (!PlayerPrefs.HasKey("UpgradedHealth"))
        {
            _health = 0;
        }
        return _health;
    }

    public void SetHealth(int healthUpTo)
    {
        if (!PlayerPrefs.HasKey("UpgradedHealth"))
        {
            _health = 0;
        }
        _health += healthUpTo;
    }

    public int GetDamage()
    {
        if (!PlayerPrefs.HasKey("UpgradedDamage"))
        {
            _damage = 0;
        }
        return _damage;
    }

    public void SetDamage(int damageUpTo)
    {
        if (!PlayerPrefs.HasKey("UpgradedDamage"))
        {
            _damage = 0;
        }
        _damage += damageUpTo;
    }

    public int GetSpeed()
    {
        if (!PlayerPrefs.HasKey("UpgradedSpeed"))
        {
            _speed = 0;
        }
        return _speed;
    }

    public void SetSpeed(int speedUpTo)
    {
        if (!PlayerPrefs.HasKey("UpgradedSpeed"))
        {
            _speed = 0;
        }
        _speed += speedUpTo;
    }

    public int GetCritChance()
    {
        if (!PlayerPrefs.HasKey("UpgradedCritChance"))
        {
            _critChance = 0;
        }
        return _critChance;
    }

    public void SetCritChance(int critChanceUpTo)
    {
        if (!PlayerPrefs.HasKey("UpgradedCritChance"))
        {
            _critChance = 0;
        }
        _critChance += critChanceUpTo;
    }

    public int GetMissChance()
    {
        if (!PlayerPrefs.HasKey("UpgradedMissChance"))
        {
            _missChance = 0;
        }
        return _missChance;
    }

    public void SetMissChance(int missChanceUpTo)
    {
        if (!PlayerPrefs.HasKey("UpgradedMissChance"))
        {
            _missChance = 0;
        }
        _missChance += missChanceUpTo;
    }

    public int GetBashChance()
    {
        if (!PlayerPrefs.HasKey("UpgradedBashChance"))
        {
            _bashChance = 0;
        }
        return _bashChance;
    }

    public void SetBashChance(int bashChanceUpTo)
    {
        if (!PlayerPrefs.HasKey("UpgradedBashChance"))
        {
            _bashChance = 0;
        }
        _bashChance += bashChanceUpTo;
    }
}
