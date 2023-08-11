// Created by dylan@hathora.dev

using Hathora.Core.Scripts.Editor.Server.ConfigStyle.PostAuth;
using Hathora.Core.Scripts.Runtime.Server;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object; // Added by Robin Cormie @ Lost Crow Games

namespace Hathora.Core.Scripts.Editor.Server.ConfigStyle
{
    /// <summary>
    /// The main editor for HathoraServerConfig, including all the button clicks and extra UI.
    /// </summary>
    [CustomEditor(typeof(HathoraServerConfig))]
    public class HathoraConfigUI : UnityEditor.Editor
    {
        #region Vars
        /// <summary>Set false to view the "raw" ScriptableObject</summary>
        public const bool ENABLE_BODY_STYLE = true;

        private HathoraConfigHeaderUI headerUI { get; set; }
        private HathoraConfigPreAuthBodyUI preAuthBodyUI { get; set; }
        private HathoraConfigPostAuthBodyUI postAuthBodyUI { get; set; }
        private HathoraConfigFooterUI footerUI { get; set; }

        private string previousDevAuthToken { get; set; }
        private HathoraServerConfig SelectedServerConfig { get; set; }
        private SerializedObject serializedConfig { get; set; }

        private bool IsAuthed =>
            SelectedServerConfig.HathoraCoreOpts.DevAuthOpts.HasAuthToken;

        private HathoraServerConfig getSelectedInstance() =>
            (HathoraServerConfig)target;
        #endregion // Vars


        #region Main
        public void OnEnable()
        {
            if (SelectedServerConfig == null)
                SelectedServerConfig = getSelectedInstance();

            // If !authed, check again for a physical token cache file
            if (SelectedServerConfig != null && !IsAuthed)
                HathoraConfigPreAuthBodyUI.CheckedTokenCache = false;
        }

        /// <summary>
        /// Essentially the editor version of Update().
        /// We'll mask over the entire ServerConfig with a styled UI.
        /// </summary>
        public override void OnInspectorGUI()
        {
            checkForDirtyRefs();
            drawHeaderBodyFooter();
            // (!) Saved changes occur @ HathoraConfigUIBase.SaveConfigChange()
        }

        private void drawHeaderBodyFooter()
        {
            headerUI.Draw();

            if (!ENABLE_BODY_STYLE)
                base.OnInspectorGUI(); // Show the raw _serverConfig, auto-gen'd by ScriptableObj
            else if (IsAuthed)
                postAuthBodyUI.Draw();
            else
                preAuthBodyUI.Draw();

            footerUI.Draw();
        }

        private void checkForDirtyRefs()
        {
            bool lostRefs = headerUI == null
                || preAuthBodyUI == null
                || postAuthBodyUI == null
                || footerUI == null
                || !ReferenceEquals(SelectedServerConfig, getSelectedInstance());

            if (lostRefs)
                initDrawUtils();

            serializedConfig.Update();
        }

        private void initDrawUtils()
        {
            SelectedServerConfig = getSelectedInstance();
            serializedConfig = new SerializedObject(SelectedServerConfig);

            // New instances of util draw classes
            headerUI = new HathoraConfigHeaderUI(SelectedServerConfig, serializedConfig);
            preAuthBodyUI = new HathoraConfigPreAuthBodyUI(SelectedServerConfig, serializedConfig);

            postAuthBodyUI = new HathoraConfigPostAuthBodyUI(
                SelectedServerConfig,
                serializedConfig);

            footerUI = new HathoraConfigFooterUI(
                SelectedServerConfig,
                serializedConfig,
                postAuthBodyUI.BodyBuildUI,
                postAuthBodyUI.BodyDeployUI
            );

            // Subscribe to repainting events // TODO: Deprecated?
            headerUI.RequestRepaint += Repaint;
            preAuthBodyUI.RequestRepaint += Repaint;
            postAuthBodyUI.RequestRepaint += Repaint;
            footerUI.RequestRepaint += Repaint;
        }
        #endregion // Main


        #region Core Buttons
        // private void insertSplitButtons(HathoraServerConfig _serverConfig, bool _isAuthed)
        // {
        //     EditorGUILayout.Space(5f);
        //
        //     if (!_isAuthed)
        //     {
        //
        //         return;
        //     }
        //
        //     // InsertHorizontalLine(1, Color.gray);
        //     EditorGUILayout.Space(10f);
        //
        //     EditorGUILayout.BeginVertical(GUI.skin.box);
        //     GUILayout.Label($"{HathoraEditorUtils.StartHathoraGreenColor}" +
        //         "Customize via `Linux Auto Build Opts`</color>", CenterAlignLabelStyle);
        //     insertBuildBtn(_serverConfig);
        //     EditorGUILayout.EndVertical();
        //
        //     EditorGUILayout.Space(10f);
        //
        //     EditorGUILayout.BeginVertical(GUI.skin.box);
        //     GUILayout.Label($"{HathoraEditorUtils.StartHathoraGreenColor}" +
        //         "Customize via `Hathora Deploy Opts`</color>", CenterAlignLabelStyle);
        //     insertHathoraDeployBtn(_serverConfig);
        //     EditorGUILayout.EndVertical();
        // }

        // private static async Task insertHathoraDeployBtn(HathoraServerConfig SelectedServerConfig)
        // {
        //     GUI.enabled = SelectedServerConfig.MeetsDeployBtnReqs();
        //
        //     if (GUILayout.Button("Deploy to Hathora", GeneralButtonStyle))
        //     {
        //         await HathoraServerDeploy.DeployToHathoraAsync(SelectedServerConfig);
        //         EditorGUILayout.Space(20f);
        //     }
        //     
        //     GUI.enabled = true;
        // }

        // private static void insertBuildBtn(HathoraServerConfig SelectedServerConfig)
        // {
        //     GUI.enabled = SelectedServerConfig.MeetsBuildBtnReqs();
        //     
        //     if (GUILayout.Button("Build Linux Server", GeneralButtonStyle))
        //     {
        //         HathoraServerBuild.BuildHathoraLinuxServer(SelectedServerConfig);
        //     }
        //     
        //     GUI.enabled = true;
        // }
        #endregion // Core Buttons


        #region Meta
        /// <summary>Change the icon of the ScriptableObject in the Project window.</summary>
        /// Modified by Robin Cormie @ Lost Crow Games
        public override Texture2D RenderStaticPreview(
            string assetPath,
            Object[] subAssets,
            int width,
            int height)
        {
#if UNITY_EDITOR
            // Check if the Resources folder exists
            if (!Directory.Exists("Assets/Resources"))
            {
                Debug.LogError("The 'Resources' folder does not exist. Create a 'Resources' folder in the 'Assets' directory and place the custom icon inside it.");
                return null;
            }

            string customIconPath = "Assets/Resources/Icons"; // Update with the correct path

            try
            {
                // Load the custom icon using the Resources.Load method and the new path
                Texture2D icon = Resources.Load<Texture2D>(customIconPath);
                if (icon != null)
                {
                    return icon; // our custom icon
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error loading custom icon: {ex.Message}");
            }
#endif

            // Default fallback
            return base.RenderStaticPreview(assetPath, subAssets, width, height);
        }
    }
}
        #endregion // Meta

