﻿using FishNet.Utility.Constant;
using System.Runtime.CompilerServices;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif



[assembly: InternalsVisibleTo(Constants.GENERATED_ASSEMBLY_NAME)]
namespace FishNet.Utility
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    internal static class ApplicationState
    {

#if !UNITY_EDITOR
        /// <summary>
        /// True if application is quitting.
        /// </summary>
        private static bool _isQuitting = false;
#endif
        static ApplicationState()
        {
#if !UNITY_EDITOR
            _isQuitting = false;
#endif
            Application.quitting -= Application_quitting;
            Application.quitting += Application_quitting;
        }

        private static void Application_quitting()
        {
#if !UNITY_EDITOR
            _isQuitting = true;
#endif
        }

        public static bool IsQuitting()
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying)
                return true;
            else
                return false;
#else
            return _isQuitting;
#endif
        }

    }


}