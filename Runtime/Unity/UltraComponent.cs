using UnityEngine;
using UnityEngine.Events;
using System;

namespace Ultraio.Unity
{
    #region Enums
    public enum UltraAuthMode
    {
        Auto,
        LaunchedFromUltraClient,
        Manual
    }
    #endregion
    public class UltraComponent : MonoBehaviour
    {
        [Header("Configuration")]
        [Tooltip("Use the manual mode if you wish to programmatically authenticate")]
        public UltraAuthMode AuthenticationMode = UltraAuthMode.Manual;

        [Header("Events")]
        [Tooltip("Event triggered when the Ultra authentication is complete")]
        public UnityEvent InitializationSuccessEvent;

        [Header("Events")]
        [Tooltip("Event triggered when the Ultra authentication failed")]
        public UnityEvent InitializationFailureEvent;

        void Awake()
        {
            bool initOnAwake = false;
            switch (AuthenticationMode)
            {
                case UltraAuthMode.Auto:
                    initOnAwake = true;
                    break;
                case UltraAuthMode.LaunchedFromUltraClient:
                    if (Ultra.LaunchedFromUltraClient)
                    {
                        initOnAwake = true;
                    }
                    break;
            }

            if (initOnAwake)
            {
                Ultra.Init(OnInitializationSuccess, OnInitializationFailure);
            }
        }

        private void OnInitializationSuccess(string username, string idToken)
        {
            if (InitializationSuccessEvent != null)
            {
                InitializationSuccessEvent.Invoke();
            }
        }

        private void OnInitializationFailure(UltraError error)
        {
            if (InitializationFailureEvent != null)
            {
                InitializationFailureEvent.Invoke();
            }
        }
    }
}