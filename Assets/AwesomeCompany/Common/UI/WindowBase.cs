﻿using UnityEngine;

namespace AwesomeCompany.Common.UI
{
    [RequireComponent(typeof(Canvas))]
    public abstract class WindowBase : MonoBehaviour
    {
        public Canvas canvas { get; private set; }

        private WindowManager _windowManager;

        public WindowBase Bind(WindowManager windowManager)
        {
            _windowManager = windowManager;
            return this;
        }

        public virtual void Close()
        {
            _windowManager.Close(this);
        }

        protected virtual void Awake()
        {
            canvas = GetComponent<Canvas>();
        }
    }
}