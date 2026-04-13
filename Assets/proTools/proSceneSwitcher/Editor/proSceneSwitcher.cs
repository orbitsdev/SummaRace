using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace proSceneSwitcher
{
    [InitializeOnLoad]
    public class proSceneSwitcher
    {
        private static List<SceneData> buildScenes = new List<SceneData>();
        private static List<SceneData> projectScenes = new List<SceneData>();

        private static int selectedIndex = 0;
        private static bool showAllScenes = true;
        private static bool isCollapsed = false;
        private static string searchQuery = "";

        private static readonly string[] excludedKeywords =
        {
            "Basic", "Standard", "URP", "UniversalRenderPipeline"
        };

        static proSceneSwitcher()
        {
            RefreshScenes();
            EditorBuildSettings.sceneListChanged += RefreshScenes;
            EditorSceneManager.sceneOpened += OnSceneOpened;
            SceneView.duringSceneGui += OnSceneViewGUI;
        }

        private static void OnSceneViewGUI(SceneView sceneView)
        {
            try
            {
                Handles.BeginGUI();

                float width = Mathf.Clamp(sceneView.position.width, 400f, 2000f);

                if (isCollapsed)
                {
                    GUILayout.BeginArea(new Rect(width - 40, 10, 30, 24));
                    if (GUILayout.Button(EditorGUIUtility.IconContent("d_tab_prev"), EditorStyles.toolbarButton, GUILayout.Width(25)))
                        isCollapsed = false;
                    GUILayout.EndArea();
                }
                else
                {
                    var toolbarRect = new Rect(width - 420, 10, 410, 30);
                    DrawToolbar(toolbarRect);
                }
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                Handles.EndGUI();
            }
        }

        private static void DrawToolbar(Rect rect)
        {
            GUILayout.BeginArea(rect);
            GUILayout.BeginHorizontal(EditorStyles.toolbar);

            // Search field
            GUIStyle searchStyle = new GUIStyle(EditorStyles.toolbarTextField) { fixedWidth = 100 };
            string newSearch = EditorGUILayout.TextField(searchQuery, searchStyle, GUILayout.Width(100));
            if (newSearch != searchQuery)
            {
                searchQuery = newSearch ?? "";
                UpdateSelectedIndex();
            }

            // Scene dropdown
            DrawSceneDropdown();

            // All button
            Color prev = GUI.backgroundColor;
            if (showAllScenes)
                GUI.backgroundColor = new Color32(0x80, 0xB8, 0xF0, 0xFF);
            bool newAll = GUILayout.Toggle(showAllScenes, new GUIContent("All", "Show all project scenes"), EditorStyles.toolbarButton, GUILayout.Width(40));
            GUI.backgroundColor = prev;

            if (newAll != showAllScenes)
            {
                showAllScenes = newAll;
                UpdateSelectedIndex();
            }

            // Play button
            GUIContent playIcon = EditorGUIUtility.IconContent("PlayButton");
            if (GUILayout.Button(playIcon, EditorStyles.toolbarButton, GUILayout.Width(30)))
            {
                var list = GetCurrentSceneListFiltered();
                if (list.Count > 0 && selectedIndex >= 0 && selectedIndex < list.Count)
                {
                    var scene = list[selectedIndex];
                    if (OpenSceneAndSaveIfNeeded(scene))
                        EditorApplication.delayCall += () => { EditorApplication.isPlaying = true; };
                }
            }

            // Refresh button
            GUIContent refreshIcon = EditorGUIUtility.IconContent("Refresh");
            if (GUILayout.Button(refreshIcon, EditorStyles.toolbarButton, GUILayout.Width(30)))
                RefreshScenes();

            // Collapse button
            GUIContent collapseIcon = EditorGUIUtility.IconContent("d_tab_next");
            if (GUILayout.Button(collapseIcon, EditorStyles.toolbarButton, GUILayout.Width(25)))
                isCollapsed = true;

            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private static void DrawSceneDropdown()
        {
            var list = GetCurrentSceneListFiltered();
            if (list.Count == 0)
            {
                GUILayout.Label("No Scenes", EditorStyles.miniLabel, GUILayout.Width(200));
                selectedIndex = 0;
                return;
            }

            GUIContent[] contents = list.Select(s => new GUIContent(s.Name)).ToArray();

            GUIStyle popupStyle = new GUIStyle(EditorStyles.toolbarPopup) { fixedWidth = 200 };
            int newIndex = EditorGUILayout.Popup(Mathf.Clamp(selectedIndex, 0, contents.Length - 1), contents, popupStyle);

            if (newIndex != selectedIndex)
            {
                selectedIndex = newIndex;
                OpenSceneAndSaveIfNeeded(list[selectedIndex]);
            }
        }

        #region Scene Management

        private static void RefreshScenes()
        {
            buildScenes.Clear();
            projectScenes.Clear();

            foreach (var s in EditorBuildSettings.scenes)
            {
                if (!string.IsNullOrEmpty(s.path) && File.Exists(s.path))
                    if (!IsExcluded(s.path))
                        buildScenes.Add(new SceneData(s.path, true));
            }

            foreach (string guid in AssetDatabase.FindAssets("t:Scene"))
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    if (!IsExcluded(path))
                        projectScenes.Add(new SceneData(path, false));
            }

            buildScenes = buildScenes.OrderBy(x => x.Name).ToList();
            projectScenes = projectScenes.OrderBy(x => x.Name).ToList();

            UpdateSelectedIndex();
        }

        private static bool IsExcluded(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            return excludedKeywords.Any(k => name.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private static List<SceneData> GetCurrentSceneList()
        {
            if (showAllScenes)
            {
                var all = new List<SceneData>(buildScenes);
                all.AddRange(projectScenes.Where(ps => !buildScenes.Any(bs => bs.Path == ps.Path)));
                return all.OrderBy(s => s.Name).ToList();
            }
            return buildScenes.Count > 0 ? new List<SceneData>(buildScenes) : new List<SceneData>(projectScenes);
        }

        private static List<SceneData> GetCurrentSceneListFiltered()
        {
            var list = GetCurrentSceneList();
            if (string.IsNullOrEmpty(searchQuery)) return list;
            string q = searchQuery.ToLowerInvariant();
            return list.Where(s => s.Name.ToLowerInvariant().Contains(q)).ToList();
        }

        private static void UpdateSelectedIndex()
        {
            var list = GetCurrentSceneListFiltered();
            string current = SceneManager.GetActiveScene().name;
            selectedIndex = Math.Max(0, list.FindIndex(s => s.Name == current));
            if (selectedIndex < 0) selectedIndex = 0;
        }

        private static bool OpenSceneAndSaveIfNeeded(SceneData sceneData)
        {
            if (sceneData == null || string.IsNullOrEmpty(sceneData.Path)) return false;
            if (!File.Exists(sceneData.Path))
            {
                Debug.LogError($"Scene not found: {sceneData.Path}");
                RefreshScenes();
                return false;
            }

            if (SceneManager.GetActiveScene().path == sceneData.Path) return true;

            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                UpdateSelectedIndex();
                return false;
            }

            EditorSceneManager.OpenScene(sceneData.Path);
            return true;
        }

        private static void OnSceneOpened(Scene scene, OpenSceneMode mode)
        {
            UpdateSelectedIndex();
        }

        #endregion

        #region Data

        public class SceneData
        {
            public string Path { get; }
            public string Name { get; }
            public bool FromBuildSettings { get; }

            public SceneData(string path, bool fromBuildSettings)
            {
                Path = path;
                Name = System.IO.Path.GetFileNameWithoutExtension(path) ?? "";
                FromBuildSettings = fromBuildSettings;
            }
        }

        #endregion
    }
}