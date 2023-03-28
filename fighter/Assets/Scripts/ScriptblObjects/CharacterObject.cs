using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class CharacterObject : ScriptableObject
{
    public string _name;
    public int _health;
    public int _damage;
    public int _speed;
    public float _attackTime;
    public int _critChance;
    public int _missChance;
    public int _bashChance;
    public Sprite _icon;
}
