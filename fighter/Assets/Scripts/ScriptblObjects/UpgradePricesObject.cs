using UnityEngine;


[CreateAssetMenu(fileName = "NewUpgradePrices", menuName = "UpgradePrices")]

public class UpgradePricesObject : ScriptableObject
{
    public int _bravo;
    public int _charlie;
    public int _delta;
    public int _echo;
    public int _foxtrot;
    public int _golf;
    public int _hotel;

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

    private int _bravoIsBought
    {
        get => PlayerPrefs.GetInt("BravoIsBought");
        set => PlayerPrefs.SetInt("BravoIsBought", value);
    }
    private int _charlieIsBought
    {
        get => PlayerPrefs.GetInt("CharlieIsBought");
        set => PlayerPrefs.SetInt("CharlieIsBought", value);
    }
    private int _deltaIsBought
    {
        get => PlayerPrefs.GetInt("DeltaIsBought");
        set => PlayerPrefs.SetInt("DeltaIsBought", value);
    }
    private int _echoIsBought
    {
        get => PlayerPrefs.GetInt("EchoIsBought");
        set => PlayerPrefs.SetInt("EchoIsBought", value);
    }
    private int _foxtrotIsBought
    {
        get => PlayerPrefs.GetInt("FoxtrotIsBought");
        set => PlayerPrefs.SetInt("FoxtrotIsBought", value);
    }
    private int _golfIsBought
    {
        get => PlayerPrefs.GetInt("GolfIsBought");
        set => PlayerPrefs.SetInt("GolfIsBought", value);
    }
    private int _hotelIsBought
    {
        get => PlayerPrefs.GetInt("HotelIsBought");
        set => PlayerPrefs.SetInt("HotelIsBought", value);
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

    public int CheckBravo()
    {
        if (!PlayerPrefs.HasKey("BravoIsBought"))
        {
            _bravoIsBought = 0;
        }
        return _bravoIsBought;
    }

    public void SetBravoTrue()
    {
        _bravoIsBought = 1;
    }

    public int CheckCharlie()
    {
        if (!PlayerPrefs.HasKey("CharlieIsBought"))
        {
            _charlieIsBought = 0;
        }
        return _charlieIsBought;
    }

    public void SetCharlieTrue()
    {
        _charlieIsBought = 1;
    }

    public int CheckDelta()
    {
        if (!PlayerPrefs.HasKey("DeltaIsBought"))
        {
            _deltaIsBought = 0;
        }
        return _deltaIsBought;
    }

    public void SetDeltaTrue()
    {
        _deltaIsBought = 1;
    }

    public int CheckEcho()
    {
        if (!PlayerPrefs.HasKey("EchoIsBought"))
        {
            _echoIsBought = 0;
        }
        return _echoIsBought;
    }

    public void SetEchoTrue()
    {
        _echoIsBought = 1;
    }

    public int CheckFoxtrot()
    {
        if (!PlayerPrefs.HasKey("FoxtrotIsBought"))
        {
            _foxtrotIsBought = 0;
        }
        return _foxtrotIsBought;
    }

    public void SetFoxtrotTrue()
    {
        _foxtrotIsBought = 1;
    }

    public int CheckGolf()
    {
        if (!PlayerPrefs.HasKey("GolfIsBought"))
        {
            _golfIsBought = 0;
        }
        return _golfIsBought;
    }

    public void SetGolfTrue()
    {
        _golfIsBought = 1;
    }

    public int CheckHotel()
    {
        if (!PlayerPrefs.HasKey("HotelIsBought"))
        {
            _hotelIsBought = 0;
        }
        return _hotelIsBought;
    }

    public void SetHotelTrue()
    {
        _hotelIsBought = 1;
    }
}
