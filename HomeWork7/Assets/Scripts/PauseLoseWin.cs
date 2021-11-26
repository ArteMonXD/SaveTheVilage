using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseLoseWin : MonoBehaviour
{
    [SerializeField] private Text accamulateValue;
    [SerializeField] private Text eatingValue;
    [SerializeField] private Text raidsValue;
    [SerializeField] private Text warriorValue;
    [SerializeField] private Text peasantValue;
    [SerializeField] private StatisticManager statisticManager;
    public void PanelOpen()
    {
        accamulateValue.text = statisticManager.accumulatedWheat.ToString();
        eatingValue.text = statisticManager.wheatEaten.ToString();
        raidsValue.text = statisticManager.countRaid.ToString();
        warriorValue.text = statisticManager.hiredWarriors.ToString();
        peasantValue.text = statisticManager.hirePeasant.ToString();
        gameObject.SetActive(true);
    }
}
