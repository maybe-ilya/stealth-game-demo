using MIG.API;
using UnityEditor;
using UnityEngine;

namespace MIG.Editor
{
    [CustomPropertyDrawer(typeof(AnimatorHash))]
    public sealed class AnimatorHashPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var propertyCopy = property.Copy();

            using var propertyScope = new EditorGUI.PropertyScope(position, label, property);
            var rect = EditorGUI.PrefixLabel(position, propertyScope.content);
            property.NextVisible(true);

            using var checkScope = new EditorGUI.ChangeCheckScope();
            EditorGUI.PropertyField(rect, property, GUIContent.none);
            var hashName = property.stringValue;

            if (checkScope.changed)
            {
                propertyCopy.boxedValue = new AnimatorHash(hashName);
            }
        }
    }
}