using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticManager : MonoBehaviour
{
    public int countRaid;
    public int accumulatedWheat;
    public int hiredWarriors;
    public int wheatEaten;
    public int hirePeasant;
    public void UpdateValueCountRaid()
    {
        countRaid++;
    }
    public void UpdateAccumulatedWheat(int increaseWheat)
    {
        accumulatedWheat += increaseWheat;
    }
    public void UpdateHireWarriors()
    {
        hiredWarriors++;
    }
    public void UpdateWheatEaten(int _eatenWheat)
    {
        wheatEaten += _eatenWheat;
    }
    public void UpdateHirePeasant(int _peasantCount)
    {
        hirePeasant = _peasantCount;
    }
    public void SatisticClear()
    {
        countRaid = 0;
        accumulatedWheat = 0;
        hiredWarriors = 0;
        wheatEaten = 0;
        hirePeasant = 0;
    }
}
