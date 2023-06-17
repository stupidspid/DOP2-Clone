using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    [SerializeField] private LevelsData levelsData;
    [SerializeField] private TextMeshProUGUI levelCondition;
    [SerializeField] private InputController inputSystem;
    [SerializeField] private Button changeLevel;

    private int _currentLevelIndex;
    private Scratch _currentLevel;
    
    private void OnEnable()
    {
        LevelRegister();
        changeLevel.onClick.AddListener(ChangeLevel);
    }

    private void LevelRegister()
    {
        var currentLevelIndex = PlayerPrefs.GetInt(Constants.CURRENT_LEVEL);
        SetupLevel(currentLevelIndex);
    }

    private void SetupLevel(int currentLevelIndex)
    {
        var currentLevel = levelsData.levels[currentLevelIndex].level;
        
        _currentLevel = Instantiate(currentLevel);
        inputSystem.Scratch = currentLevel;

        levelCondition.text = levelsData.levels[currentLevelIndex].condition;
    }

    private void LoopLevels()
    {
        if (_currentLevelIndex >= levelsData.levels.Count - 1)
        {
            _currentLevelIndex = -1;
        }
    }

    private void ChangeLevel()
    {
        LoopLevels();
        Destroy(_currentLevel.gameObject);
        _currentLevelIndex++;
        SetupLevel(_currentLevelIndex);
    }
}
