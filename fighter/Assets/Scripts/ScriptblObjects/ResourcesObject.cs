using UnityEngine;

[CreateAssetMenu(fileName = "NewResources", menuName = "Resources")]
public class ResourcesObject : ScriptableObject
{
    private static int _gold
    {
        get => PlayerPrefs.GetInt("Gold");
        set => PlayerPrefs.SetInt("Gold", value);
    }
    private int _wins
    {
        get => PlayerPrefs.GetInt("Wins");
        set => PlayerPrefs.SetInt("Wins", value);
    }

    public int GetGold()
    {
        if (!PlayerPrefs.HasKey("Gold"))
        {
            _gold = 10000;
        }
        return _gold;
    }

    public void SetGold(int gold)
    {
        if (!PlayerPrefs.HasKey("Gold"))
        {
            _gold = 100;
        }
        _gold += gold;
    }

    public int GetWins()
    {
        if (!PlayerPrefs.HasKey("Wins"))
        {
            _wins = 0;
        }
        return _wins;
    }

    public void SetWins(int wins)
    {
        if (!PlayerPrefs.HasKey("Wins"))
        {
            _gold = 0;
        }
        _wins += wins;
    }
}
