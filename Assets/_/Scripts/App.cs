using AwesomeCompany.Common;
using AwesomeCompany.Common.UI;
using AwesomeCompany.RollerSplat.Dynamic;
using AwesomeCompany.RollerSplat.Gameplay;
using AwesomeCompany.RollerSplat.UI.Windows;
using UnityEngine;

namespace AwesomeCompany.RollerSplat
{
    public class App : Singleton<App>
    {
        public IDynamicDataProvider dynamicData { get; private set; }

        public WindowManager windowManager { get; private set; }

        public GameController gameController { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            dynamicData = new DebugDynamicDataProvider();

            windowManager = new GameObject("WindowManager").AddComponent<WindowManager>();
            windowManager.transform.SetParent(transform);

            gameController = new GameObject("GameController").AddComponent<GameController>();
            gameController.transform.SetParent(transform);
        }

        private void Start()
        {
            windowManager.Show<MainMenuWindow>();
        }
    }
}