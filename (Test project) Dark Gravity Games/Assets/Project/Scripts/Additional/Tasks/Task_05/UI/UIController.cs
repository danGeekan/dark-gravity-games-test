using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Scripts.Tasks.Task_05
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;

        private GameSaveManager _gameSaveManager;
        private GroupMover _groupMover;

        [Inject]
        private void Construct(GameSaveManager gameSaveManager, GroupMover groupMover)
        {
            _gameSaveManager = gameSaveManager;
            _groupMover = groupMover;
        }
        
        private void Start()
        {
            ButtonsSubscribe();
        }

        private void ButtonsSubscribe()
        {
            saveButton.onClick.AddListener(_gameSaveManager.Save); 
            loadButton.onClick.AddListener(Load);
        }

        private void Load()
        {
            _groupMover.EndMove();
            _gameSaveManager.Load();
        }
    }
}