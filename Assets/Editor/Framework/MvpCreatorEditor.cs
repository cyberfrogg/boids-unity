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

            RefreshUnitsList();

            var createUnitButton = rootVisualElement.Query<Button>(name:"button_createunit").First();
            createUnitButton.clickable.clicked += OnAddUnitButtonClick;
            
            var createFieldUnitButton = rootVisualElement.Query<Button>(name:"button_addunitfield").First();
            createFieldUnitButton.clickable.clicked += OnAddFieldToCurrentUnitClick;
        }

        private void OnFocus()
        {
            RefreshUnitsList();
        }


        private void OnAddUnitButtonClick()
        {
            var newUnitName = rootVisualElement.Query<TextField>(name:"newunitname").First().value;
            var newUnitWorldName = rootVisualElement.Query<TextField>(name:"newunitworld").First().value;
            newUnitName = newUnitName.Replace(" ", "");
            newUnitWorldName = newUnitWorldName.Replace(" ", "");
            
            if(newUnitName == "" || newUnitWorldName == "")
                return;

            var newUnitSettings = new NewUnitSettings()
            {
                Name = newUnitName,
                Fields = new List<NewUnitSettingsField>()
            };

            var fieldElements = rootVisualElement.Query<GroupBox>(name: "field").ToList();
            foreach (var fieldElement in fieldElements)
            {
                var fieldNewName = fieldElement.Query<TextField>(name:"field_name").First().value.Replace(" ", "");
                var fieldNewType = fieldElement.Query<DropdownField>(name:"field_type").First().value;
                
                if(fieldNewName == "")
                    continue;

                var newFieldItem = new NewUnitSettingsField()
                {
                    Name = fieldNewName,
                    Type = fieldNewType
                };
                newUnitSettings.Fields.Add(newFieldItem);
            }

            Debug.Log($"Creating unit: {newUnitName} | Fields count: {fieldElements.Count}");

            var modelName = $"{newUnitName}Model.cs";
            var viewName = $"{newUnitName}View.cs";
            var controllerName = $"{newUnitName}Controller.cs";
            var modelPath = Path.Join(Path.Join(_pathToWorlds, newUnitWorldName), "Models", modelName);
            var viewPath = Path.Join(Path.Join(_pathToWorlds, newUnitWorldName), "Views", viewName);
            var controllerPath = Path.Join(Path.Join(_pathToWorlds, newUnitWorldName), "Controllers", controllerName);

            Directory.CreateDirectory(new FileInfo(modelPath).Directory.FullName);
            Directory.CreateDirectory(new FileInfo(viewPath).Directory.FullName);
            Directory.CreateDirectory(new FileInfo(controllerPath).Directory.FullName);
            
            var modelContent = "text model";
            var viewContent = "text view";
            var controllerContent = "text controller";
            
            File.WriteAllText(Path.Join(Application.dataPath, modelPath.Substring(modelPath.IndexOf("/"))), modelContent);
            File.WriteAllText(Path.Join(Application.dataPath, viewPath.Substring(viewPath.IndexOf("/"))), viewContent);
            File.WriteAllText(Path.Join(Application.dataPath, controllerPath.Substring(controllerPath.IndexOf("/"))), controllerContent);
            
            AssetDatabase.Refresh();
        }

        private void OnAddFieldToCurrentUnitClick()
        {
            var fieldParent = rootVisualElement.Query<GroupBox>(name:"fields").First();
            
            CreateUnitFieldElement(fieldParent);
        }
        

        private void RefreshUnitsList()
        {
            SetupAllClassTypes();
            
            var unitslist = rootVisualElement.Query<ScrollView>(name: "unitslist").First();
            if(unitslist == null)
                return;
            
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

        private void CreateUnitFieldElement(VisualElement parent)
        {
            var fieldContainer = new GroupBox();
            fieldContainer.style.display = DisplayStyle.Flex;
            fieldContainer.style.flexDirection = FlexDirection.Row;
            fieldContainer.name = "field";
            parent.Add(fieldContainer);
            
            var fieldNameTextField = new TextField();
            fieldNameTextField.name = "field_name";
            fieldNameTextField.style.width = 200;
            fieldContainer.Add(fieldNameTextField);
            
            var fieldTypeDropdown = new DropdownField(ConvertUnitFieldObjectEnumToString(), 0);
            fieldTypeDropdown.style.width = 100;
            fieldTypeDropdown.name = "field_type";
            fieldContainer.Add(fieldTypeDropdown);
            
            var closeButton = new Button();
            closeButton.text = "x";
            closeButton.style.width = 10;
            fieldContainer.Add(closeButton);
        }

        private List<string> ConvertUnitFieldObjectEnumToString()
        {
            return Enum.GetNames(typeof(EUnitFieldObjectType)).ToList();
        }
        
        public enum EUnitFieldObjectType
        {
            Object,
            String,
            Int,
            Float
        }

        public class NewUnitSettings
        {
            public string Name;
            public List<NewUnitSettingsField> Fields;
        }
        
        public class NewUnitSettingsField
        {
            public string Name;
            public string Type;
        }
    }
}