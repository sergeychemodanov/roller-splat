﻿using AwesomeCompany.Common.UI;
using UnityEngine;
using UnityEngine.UI;

namespace AwesomeCompany.RollerSplat.UI.Windows
{
    public class LevelPassedWindow : WindowBase
    {
        [SerializeField] private Button _mainMenuButton;

        protected override void Awake()
        {
            base.Awake();
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnMainMenuButtonClicked()
        {
            App.instance.gameController.Clear();
            App.instance.windowManager.Show<MainMenuWindow>();
            Close();
        }
    }
}