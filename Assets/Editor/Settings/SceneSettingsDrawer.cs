using System.Collections.Generic;
using Services.Scenes;
using Services.Scenes.Impl;
using Settings.Settings.Scene.Impl;
using UnityEditor;
using UnityEngine;

namespace Editor.Settings
{
    [CustomEditor(typeof(SceneSettings))]
    public class SceneSettingsDrawer : UnityEditor.Editor
    {
        private string _addSceneNameValue;

        private List<int> _scenesToDelete;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            var sceneSettingsTarget = (SceneSettings) target;

            if (sceneSettingsTarget.Target == null)
                sceneSettingsTarget.Target = new List<IScene>();

            DeleteScenesFromQueue(sceneSettingsTarget);

            DrawScenes(sceneSettingsTarget);
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            DrawSceneInput(sceneSettingsTarget);
        }

        private void DrawSceneInput(SceneSettings target)
        {
            EditorGUILayout.LabelField("AddScene:", EditorStyles.boldLabel);
            GuiLine(10);
            _addSceneNameValue = EditorGUILayout.TextField("Add Scene Name", _addSceneNameValue);
            
            if(GUILayout.Button("AddScene"))
            {
                target.Target.Add(new Scene(target.Target.Count, _addSceneNameValue));
                EditorUtility.SetDirty(target);
            }
            GuiLine(10);
        }

        private void DrawScenes(SceneSettings target)
        {
            foreach (var scene in target.Target)
            {
                GuiLine();
                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.TextField("Name", scene.Name);
                EditorGUILayout.IntField("Index", scene.Index);
                EditorGUI.EndDisabledGroup();
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                // if (GUILayout.Button("/\\", GUILayout.Width(20)))
                // {
                //     
                // }
                // if (GUILayout.Button("\\/", GUILayout.Width(20)))
                // {
                //     
                // }
                GUILayout.Space(EditorGUIUtility.labelWidth);
                GUILayout.Space(EditorGUIUtility.labelWidth);
                if (GUILayout.Button("X", GUILayout.Width(20)))
                {
                    DeleteScene(scene.Index, target);
                }
                GUILayout.EndHorizontal();
                GuiLine();
            }
        }
        
        private void GuiLine(int i_height = 1)
        {
            var rect = EditorGUILayout.GetControlRect(false, i_height );
            rect.height = i_height;
            EditorGUI.DrawRect(rect, new Color ( 0.5f,0.5f,0.5f, 1 ) );
        }

        private void DeleteScene(int index, SceneSettings target)
        {
            _scenesToDelete = new List<int>();
            _scenesToDelete.Add(index);
        }

        private void DeleteScenesFromQueue(SceneSettings target)
        {
            if(_scenesToDelete == null || _scenesToDelete?.Count == 0)
                return;
            
            foreach (var sceneToDelete in _scenesToDelete)
            {
                target.Target.RemoveAt(sceneToDelete);
            }
            _scenesToDelete.Clear();

            var newList = new List<IScene>();
            for (var i = 0; i < target.Target.Count; i++)
            {
                var scene = target.Target[i];
                var newScene = new Scene(i, scene.Name);
                newList.Add(newScene);
            }
            
            target.Target = newList;
            EditorUtility.SetDirty(target);
            Repaint();
        }
    }
}