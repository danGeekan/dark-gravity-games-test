using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIController : MonoBehaviour
{
    [Header("Spawn button")]
    [SerializeField] private Button startStopButton;
    [SerializeField] private TMP_Text startStopButtonText;
    [SerializeField] private float timeToChangeButtonState;
    [Header("Clear button")]
    [SerializeField] private Button clearButton;
    
    private bool _isSpawning;
    private ObjectSpawner _objectSpawner;
    private ISpawner _spawner;
    private Coroutine _changeButtonStateCoroutine;

    [Inject]
    private void Construct(ObjectSpawner objectSpawner, ISpawner spawner)
    {
        _objectSpawner = objectSpawner;
        _spawner = spawner;

        SubscribeButton();
    }

    private void SubscribeButton()
    {
        startStopButton.onClick.AddListener(StartStopSpawn);
        clearButton.onClick.AddListener(Clear);
    }

    #region Stop/Start spawn

    private void StartStopSpawn()
    {
        if (!_isSpawning)
        {
            if(_changeButtonStateCoroutine != null) StopCoroutine(_changeButtonStateCoroutine);
            
            _objectSpawner.Spawn(() => _changeButtonStateCoroutine = StartCoroutine(ChangeButtonState()));
        }
        else
        {
            _objectSpawner.Stop();
        }
    }

    private IEnumerator ChangeButtonState()
    {
        WaitForSeconds wait = new WaitForSeconds(timeToChangeButtonState);

        startStopButton.interactable = false;

        yield return wait;

        if (!_isSpawning)
        {
            OnClearButton(false);
            startStopButtonText.text = "Stop";
            _isSpawning = true;
        }
        else
        {
            OnClearButton(true);
            startStopButtonText.text = "Start";
            _isSpawning = false;
        }

        startStopButton.interactable = true;
    }

    #endregion

    #region Clear

    private void Clear()
    {
        _spawner.Clear();
        OnClearButton(false);
    }

    private void OnClearButton(bool isOn)
    {
        clearButton.gameObject.SetActive(isOn);
    }
    
    #endregion
}