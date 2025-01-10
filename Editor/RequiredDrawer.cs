using UnityEditor;
using UnityEngine;

namespace Incantium.Attributes.Editor
{
    /// <summary>
    /// Class for a custom inspector for every field that is required. This class handles the drawing of a warning when
    /// the object reference field is not set.
    /// </summary>
    [CustomPropertyDrawer(typeof(Required))]
    internal sealed class RequiredDrawer : PropertyDrawer
    { 
        /// <inheritdoc cref="PropertyDrawer.OnGUI"/>
        /// <summary>
        /// Method to draw the field labeled with as required. This method will draw the field itself alongside a
        /// warning if need be.
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        { 
            // Draws the warning box.
            DrawWarning(property);
            
            // Draw the rest of the property.
            EditorGUILayout.PropertyField(property, label, true);
        }
        
        /// <summary>
        /// Method to draw an error message box in the following situations:
        /// <ul>
        ///     <li>The property is not a reference type.</li>
        ///     <li>The property is null and is not present in a prefab.</li>
        /// </ul>
        /// </summary>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        private void DrawWarning(SerializedProperty property)
        {
            var status = Status(property);

            if (status is RequireStatus.Unable)
            {
                var message = $"Required cannot be used on '{property.name}' with '{fieldInfo.FieldType}', which is non-referenceable.";
                EditorGUILayout.HelpBox(message, MessageType.Warning);
            }
            else if (status is RequireStatus.Missing)
            {
                var message = $"Required reference on '{property.name}' for '{fieldInfo.FieldType}' is missing.";
                EditorGUILayout.HelpBox(message, MessageType.Error);
            }
        }

        /// <summary>
        /// Method to check what the required status is of the property.
        /// </summary>
        /// <param name="property">The property to check.</param>
        /// <returns>The status of the requirement</returns>
        private static RequireStatus Status(SerializedProperty property)
        {
            var obj = property.Target();

            if (obj is IRequireable require) return require.status;
            if (property.propertyType != SerializedPropertyType.ObjectReference) return RequireStatus.Unable;
            
            return property.objectReferenceValue != null 
                   || EditorUtility.IsPersistent(property.serializedObject.targetObject) 
                ? RequireStatus.Found : RequireStatus.Missing;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => 0;
    }
}