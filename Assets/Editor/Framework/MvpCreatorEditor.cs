using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.Framework
{
    public class MvpCreatorEditor : EditorWindow
    {
        private const string _pathToWorlds = "Assets/Scripts/Worlds/Impl";

        private IEnumerable<Type> _allClassTypes;

        private VisualTreeAsset _visualTreeAsset;
        
        [MenuItem("Tools/" + nameof(MvpCreatorEditor))]
        public static void ShowMyEditor()
        {
            var wnd = GetWindow<MvpCreatorEditor>();
            wnd.titleContent = new GUIContent(nameof(MvpCreatorEditor));
        }
        
        public void CreateGUI()
        {
            _visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Framework/mvpcreator.uxml");
            
            rootVisualElement.Clear();
            _visualTreeAsset.CloneTree(rootVisualElement);
        }

        private void OnFocus()
        {
            RefreshUnitsList();
        }

        private void RefreshUnitsList()
        {
            SetupAllClassTypes();
            
            var unitslist = rootVisualElement.Query<ScrollView>(name: "unitslist").First();
            unitslist.Clear();
            
            DrawUnitsListRecursive(_pathToWorlds, 1, unitslist);
        }

        private void DrawUnitsListRecursive(string path, int depth, ScrollView scrollView)
        {
            var folders = AssetDatabase.GetSubFolders(path);
            var pathToFiles = Path.Join(Application.dataPath, path.Substring(path.IndexOf("/")));
            var files = Directory.GetFiles(pathToFiles);
            

            for (var i = 0; i < folders.Length; i++)
            {
                var lastFolder = new DirectoryInfo(folders[i]).Name;
                
                var itemLabel = new Label(ConstructUnitListName(lastFolder, path, depth));
                scrollView.Add(itemLabel);
                
                DrawUnitsListRecursive(folders[i], depth + 1, scrollView);
            }
            
            for (var i = 0; i < files.Length; i++)
            {
                var fileName = Path.GetFileName(files[i]);
                if (Path.GetExtension(fileName) != ".cs")
                    continue;
                
                var itemLabel = new Label(ConstructUnitListName(fileName, files[i], depth));
                scrollView.Add(itemLabel);
            }
        }

        private string ConstructUnitListName(string name, string path, int depth)
        {
            var isFile = File.Exists(path);
            
            var result = "";

            for (var i = 0; i < depth; i++)
            {
                result += "   ";
            }

            if (isFile)
            {
                var searchClassName = name.Substring(0, name.Length - 3);

                var needleType = _allClassTypes.First(x => x.Name.ToLower().Contains(searchClassName.ToLower()));

                var isCompiled = needleType != null;
                var displayName = isCompiled ? needleType.Name : name;

                var displayIcon = "  ";

                displayIcon = needleType.FullName.ToLower().Contains("view") ? "V" : displayIcon;
                displayIcon = needleType.FullName.ToLower().Contains("controller") ? "C" : displayIcon;
                displayIcon = needleType.FullName.ToLower().Contains("model") ? "M" : displayIcon;
                
                result += $"L [{displayIcon}] {displayName}";
            }
            else
            {
                result += "L " + name;
            }
            return result;
        }

        private void SetupAllClassTypes()
        {
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => 
                    !x.FullName.Contains("UnityEngine") && 
                    !x.FullName.Contains("UnityEditor") && 
                    !x.FullName.Contains("Unity") &&
                    !x.FullName.Contains("Microsoft.CSharp") &&
                    !x.FullName.Contains("Bee.BeeDriver") &&
                    !x.FullName.Contains("mscorlib") &&
                    !x.FullName.Contains("log4net") &&
                    !x.FullName.Contains("System.")
                );

            _allClassTypes = allAssemblies.SelectMany(assembly => assembly.GetTypes());
        }
    }
}