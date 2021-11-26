using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public SoundManager soundManager;
    public StatisticManager statisticManager;
    public Text peasantIndicator;
    public Text warriorIndicator;
    public Text wheatIndicator;
    public Text enemyIndicator;
    public Text seriesTruceIndicator;
    public Text warriorCostIndicator;
    public Text peasantCostIndicator;
    public Image clockWheatCollectIndicator;
    public Image clockEnemyRaidIndicator;
    public Image clockEatingIndicator;
    public Image clockTraningPeasantIndicator;
    public Image clockTraningWarriorIndicator;
    public Button hirePeasantsButton;
    public Button hireWarriorButton;
    public GameObject costWarriorPanel;
    public GameObject costPeasantPanel;
    public GameObject countEnemyIndicatorPanel;
    public PauseLoseWin winPanel;
    public PauseLoseWin losePanel;
    public float timeWheatCollect;
    public float timeEnemyRaid;
    public float timeEating;
    public float timeTraningPeasant;
    public float timeTraningWarrior;
    public int countMinedWheat;
    public int countEatingWheat;
    public int pricePeasant;
    public int priceWarrior;
    public int winCountWheat;
    public int winCountPeasant;
    public int countSeriesToEnemyRaid;
    public int startCountEnemy;
    public int startPeasantCount;
    public int startWheatCount;
    public int startWarriorCount;
    public int countDifficultyIncreases;
    private int _increaseEnemies;
    private int _currentSeriesToRaid;
    private int _currentCountEnemy;
    private int _currentPeasantCount;
    private int _currentWarriorCount;
    private int _currentWheatCount;
    private float _currentTimeWheatCollect;
    private float _currentTimeEnemyRaid;
    private float _currentTimeEating;
    private float _currentTimeTraningPearsant;
    private float _currentTimeTraningWarrior;
    private bool _traningPeasant;
    private bool _traningWarrior;
    private bool _truce;
    private void Start()
    {
        StartGame();
    }
    void Update()
    {
        TimerCollectWheat();
        TimerEnemyRaid();
        TimerEating();
        ButtonControll();
        ShowTextIndicator();
        ShowTimer();
        CheckWin();
    }
    public void StartGame()
    {
        statisticManager.SatisticClear();
        _currentTimeWheatCollect = timeWheatCollect;
        _currentTimeEnemyRaid = timeEnemyRaid;
        _currentTimeEating = timeEating;
        _currentTimeTraningPearsant = timeTraningPeasant;
        _currentTimeTraningWarrior = timeTraningWarrior;
        _currentCountEnemy = startCountEnemy;
        _currentPeasantCount = startPeasantCount;
        _currentWheatCount = startWheatCount;
        _currentSeriesToRaid = countSeriesToEnemyRaid;
        _currentWarriorCount = startWarriorCount;
        _increaseEnemies = 1;
        seriesTruceIndicator.gameObject.SetActive(true);
        countEnemyIndicatorPanel.SetActive(false);
        costPeasantPanel.SetActive(true);
        costWarriorPanel.SetActive(true);
        clockTraningPeasantIndicator.fillAmount = 0;
        clockTraningWarriorIndicator.fillAmount = 0;
        clockEnemyRaidIndicator.fillAmount = 1;
        statisticManager.UpdateHirePeasant(startPeasantCount);
        _traningPeasant = false;
        _traningWarrior = false;
        _truce = true;
    }
    private void TimerCollectWheat()
    {
        if (_currentTimeWheatCollect <= 0)
        {
            _currentWheatCount += countMinedWheat * _currentPeasantCount;
            statisticManager.UpdateAccumulatedWheat(countMinedWheat * _currentPeasantCount);
            _currentTimeWheatCollect = timeWheatCollect;
            soundManager.WheatCollectAudioPlay();
        }
        _currentTimeWheatCollect -= Time.deltaTime;
    }
    private void TimerEnemyRaid()
    {
        if (_truce)
        {
            if (_currentTimeEnemyRaid <= 0)
            {
                _currentSeriesToRaid--;
                if (_currentSeriesToRaid == 0)
                {
                    _truce = false;
                    countEnemyIndicatorPanel.SetActive(true);
                    seriesTruceIndicator.gameObject.SetActive(false);
                }
                _currentTimeEnemyRaid = timeEnemyRaid;
            }
        }
        else
        {
            if (_currentTimeEnemyRaid <= 0)
            {
                soundManager.EnemyAudioPlay();
                if (_currentWarriorCount >= _currentCountEnemy)
                    _currentWarriorCount -= _currentCountEnemy;
                else
                {
                    _currentWarriorCount = 0;
                    Lose();
                }
                statisticManager.UpdateValueCountRaid();
                if (statisticManager.countRaid % countDifficultyIncreases == 0)
                    _increaseEnemies++;
                _currentCountEnemy += _increaseEnemies;
                _currentTimeEnemyRaid = timeEnemyRaid;
            }
        }
        _currentTimeEnemyRaid -= Time.deltaTime;
    }
    private void TimerEating()
    {
        if(_currentTimeEating <= 0)
        {
            soundManager.EatingAudioPlay();
            if (_currentWarriorCount * countEatingWheat > _currentWheatCount)
            {
                statisticManager.UpdateWheatEaten(_currentWheatCount);
                _currentWheatCount = 0;
            }
            else
            {
                statisticManager.UpdateWheatEaten(_currentWarriorCount * countEatingWheat);
                _currentWheatCount -= _currentWarriorCount * countEatingWheat;
            }
            _currentTimeEating = timeEating;
        }
        _currentTimeEating -= Time.deltaTime;
    }
    private void TimerTraningPeasant()
    {
        if(_currentTimeTraningPearsant <= 0)
        {
            soundManager.PeasantAudioPlay();
            _traningPeasant = false;
            _currentPeasantCount++;
            statisticManager.UpdateHirePeasant(_currentPeasantCount);
            _currentTimeTraningPearsant = timeTraningPeasant;
            costPeasantPanel.SetActive(true);
        }
        _currentTimeTraningPearsant -= Time.deltaTime;
    }
    private void TimerTraningWarrior()
    {
        if(_currentTimeTraningWarrior <= 0)
        {
            soundManager.KnightAudioPlay();
            _traningWarrior = false;
            _currentWarriorCount++;
            statisticManager.UpdateHireWarriors();
            _currentTimeTraningWarrior = timeTraningWarrior;
            costWarriorPanel.SetActive(true);
        }
        _currentTimeTraningWarrior -= Time.deltaTime;
    }
    private void CheckResolutionHirePeasant()
    {
        if (_currentWheatCount< pricePeasant)
            hirePeasantsButton.interactable = false;
        else
            hirePeasantsButton.interactable = true;
    }
    private void CheckResolutionHireWarrior()
    {
        if (_currentWheatCount < priceWarrior)
            hireWarriorButton.interactable = false;
        else
            hireWarriorButton.interactable = true;
    }
    public void HirePeasants()
    {
        hirePeasantsButton.interactable = false;
        _traningPeasant = true;
        _currentWheatCount -= pricePeasant;
        costPeasantPanel.SetActive(false);
    }
    public void HireWarrior()
    {
        hireWarriorButton.interactable = false;
        _traningWarrior = true;
        _currentWheatCount -= priceWarrior;
        costWarriorPanel.SetActive(false);
    }
    private void ButtonControll()
    {
        if (_traningPeasant)
        {
            TimerTraningPeasant();
        }
        else
        {
            CheckResolutionHirePeasant();
        }
        if (_traningWarrior)
        {
            TimerTraningWarrior();
        }
        else
        {
            CheckResolutionHireWarrior();
        }   
    }
    private void ShowTimer()
    {
        clockWheatCollectIndicator.fillAmount = _currentTimeWheatCollect / timeWheatCollect;
        if (!_truce)
            clockEnemyRaidIndicator.fillAmount = _currentTimeEnemyRaid / timeEnemyRaid;
        clockEatingIndicator.fillAmount = _currentTimeEating / timeEating;
        if (_traningPeasant)
            clockTraningPeasantIndicator.fillAmount = _currentTimeTraningPearsant / timeTraningPeasant;
        if (_traningWarrior)
            clockTraningWarriorIndicator.fillAmount = _currentTimeTraningWarrior / timeTraningWarrior;
    }
    private void ShowTextIndicator()
    {
        peasantIndicator.text = _currentPeasantCount.ToString();
        warriorIndicator.text = _currentWarriorCount.ToString();
        wheatIndicator.text = _currentWheatCount.ToString();
        enemyIndicator.text = _currentCountEnemy.ToString();
        warriorCostIndicator.text = priceWarrior.ToString();
        peasantCostIndicator.text = pricePeasant.ToString();
        if(seriesTruceIndicator.gameObject.activeSelf)
            seriesTruceIndicator.text = _currentSeriesToRaid.ToString();
    }
    public void Pause(bool on)
    {
        if (on)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    private void CheckWin()
    {
        if (_currentWheatCount >= winCountWheat || _currentPeasantCount >= winCountPeasant)
            Win();
    }
    private void Win()
    {
        Pause(true);
        winPanel.PanelOpen();
        soundManager.WinAudioPlay();
    }
    private void Lose()
    {
        Pause(true);
        losePanel.PanelOpen();
    }
}
