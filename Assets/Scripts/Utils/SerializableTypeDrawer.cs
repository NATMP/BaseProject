using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Utils
{
    [CustomPropertyDrawer(typeof(SerializableType))]
    public class SerializableTypeDrawer : PropertyDrawer
    {
        TypeFilterAttribute typeFilter;
        string[] typeNames, typeFullNames;

        void Initialize()
        {
            if (typeFullNames != null) return;

            typeFilter = (TypeFilterAttribute) Attribute.GetCustomAttribute(fieldInfo , typeof(TypeFilterAttribute));

            var filteredTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly =>
                {
                    try
                    {
                        return assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        // Use the types that did load (ex.Types may contain nulls)
                        Debug.LogError($"Could not load all types from assembly {assembly.FullName}. Some types will be skipped.");
                        return (ex.Types ?? Array.Empty<Type>());
                    }
                    catch
                    {
                        Debug.LogError($"Could not load types from assembly {assembly.FullName}. Skipping this assembly.");
                        // Skip assemblies that throw other unexpected errors
                        return Enumerable.Empty<Type>();
                    }
                })
                .Where(t => t != null) // drop null entries from ReflectionTypeLoadException
                .Where(t => typeFilter == null ? DefaultFilter(t) : typeFilter.Filter(t))
                .ToArray();

            // Use DeclaringType for nested types (ReflectedType was incorrect here),
            // and produce a readable display name.
            typeNames = filteredTypes.Where(t => t.IsNested && t.DeclaringType != null).Select(t => t.Name).ToArray();

            typeFullNames = filteredTypes.Select(t => t.AssemblyQualifiedName).ToArray();
        }

        static bool DefaultFilter(Type type)
        {
            return !type.IsAbstract && !type.IsInterface && !type.IsGenericType;
        }

        public override void OnGUI(Rect position , SerializedProperty property , GUIContent label)
        {
            Initialize();
            var typeIdProperty = property.FindPropertyRelative("assemblyQualifiedName");

            if (string.IsNullOrEmpty(typeIdProperty.stringValue))
            {
                typeIdProperty.stringValue = typeFullNames.First();
                property.serializedObject.ApplyModifiedProperties();
            }

            var currentIndex = Array.IndexOf(typeFullNames , typeIdProperty.stringValue);
            var selectedIndex = EditorGUI.Popup(position , label.text , currentIndex , typeNames);

            if (selectedIndex >= 0 && selectedIndex != currentIndex)
            {
                typeIdProperty.stringValue = typeFullNames[selectedIndex];
                property.serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
