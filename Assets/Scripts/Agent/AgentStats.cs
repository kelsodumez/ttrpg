using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStats : MonoBehaviour
{
    [SerializeField] private float _hitPoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _initiative;

    public enum _stats
    {
        _hp,
        _moveSpeed,
        _inititiative
    }

    public float getStat(_stats _stat)
    {
        switch(_stat)
        {
            case _stats._hp:
                return _hitPoints;
            case _stats._moveSpeed:
                return _moveSpeed;
            case _stats._inititiative:
                return _initiative;
        }
        return Mathf.NegativeInfinity;
    }

    public void setStat(_stats _stat, float _newValue)
    {
        switch(_stat)
        {
            case _stats._hp:
                _hitPoints = _newValue;
                break;
            case _stats._moveSpeed:
                _moveSpeed = _newValue;
                break;
            case _stats._inititiative:
                _initiative = _newValue;
                break;
        }
    }

    public void addStat(_stats _stat, float _addValue)
    {
        switch(_stat)
        {
            case _stats._hp:
                _hitPoints += _addValue;
                break;
            case _stats._moveSpeed:
                _moveSpeed += _addValue;
                break;
            case _stats._inititiative:
                _initiative += _addValue;
                break;
        }
    }
}
