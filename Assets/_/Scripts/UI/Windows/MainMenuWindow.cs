using System.Linq;
using AwesomeCompany.Common.UI;
using UnityEngine;
using UnityEngine.UI;

namespace AwesomeCompany.RollerSplat.UI.Windows
{
    public class MainMenuWindow : WindowBase
    {
        [SerializeField] private Button _playButton;

        protected override void Awake()
        {
            base.Awake();
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            var level = App.instance.dynamicData.levels.First();
            App.instance.gameController.Play(level);
            Close();
        }
    }
}