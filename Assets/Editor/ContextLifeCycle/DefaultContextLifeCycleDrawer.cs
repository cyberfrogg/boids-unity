using System.Collections.Generic;
using System.Reflection;
using Contexts.LifeCycle;
using Contexts.LifeCycle.Impl;
using UnityEditor;

namespace Editor.ContextLifeCycle
{
    [CustomEditor(typeof(DefaultContextLifeCycle))]
    public class DefaultContextLifeCycleDrawer : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var lc = (DefaultContextLifeCycle)target;

            var fields = lc.GetType().GetFields(
                BindingFlags.NonPublic |
                BindingFlags.Instance);

            var initListeners = new List<IInitializeListener>();
            var awakeListeners = new List<IAwakeListener>();
            var updateListeners = new List<IUpdateListener>();
            
            foreach (var field in fields)
            {
                switch (field.Name)
                {
                    case "_initializeListeners":
                        initListeners = (List<IInitializeListener>)field.GetValue(lc);
                        continue;
                    case "_awakeListeners":
                        awakeListeners = (List<IAwakeListener>)field.GetValue(lc);
                        continue;
                    case "_updateListeners":
                        updateListeners = (List<IUpdateListener>)field.GetValue(lc);
                        continue;
                }
            }
            
            EditorGUILayout.LabelField($"Initialize listeners: {initListeners.Count}");
            EditorGUILayout.LabelField($"Awake listeners: {awakeListeners.Count}");
            EditorGUILayout.LabelField($"Update listeners: {updateListeners.Count}");
        }
    }
}