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
        private const int HEIGHT = 30;
        
        /// <inheritdoc cref="PropertyDrawer.OnGUI"/>
        /// <summary>
        /// Method to draw the field labeled with as required. This method will draw the field itself alongside a
        /// warning if need be.
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            DrawField(position, property, label);
            DrawWarning(position, property, label);
            
            EditorGUI.EndProperty();
        }
        
        /// <summary>
        /// Method to draw the property field.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        private static void DrawField(Rect position, SerializedProperty property, GUIContent label)
        {
            if (Status(property) is RequireStatus.Missing or RequireStatus.Unable) position.height -= HEIGHT;
            
            EditorGUI.PropertyField(position, property, label);
        }
        
        /// <summary>
        /// Method to draw an error message box in the following situations:
        /// <ul>
        ///     <li>The property is not a reference type.</li>
        ///     <li>The property is null and is not present in a prefab.</li>
        /// </ul>
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        private void DrawWarning(Rect position, SerializedProperty property, GUIContent label)
        {
            var height = base.GetPropertyHeight(property, label);
            var rect = new Rect(position.x, position.y + height, position.width, HEIGHT);

            var status = Status(property);

            if (status is RequireStatus.Unable)
            {
                var message = $"Required cannot be used for '{fieldInfo.FieldType}', which is non-referenceable.";
                EditorGUI.HelpBox(rect, message, MessageType.Warning);
            }
            else if (status is RequireStatus.Missing)
            {
                const string message = "Missing required reference.";
                EditorGUI.HelpBox(rect, message, MessageType.Error);
            }
        }

        /// <inheritdoc cref="PropertyDrawer.GetPropertyHeight"/>
        /// <summary>
        /// Method to calculate the height required for the field. This will take into account the height of a warning
        /// if needed.
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var height = base.GetPropertyHeight(property, label);
            
            if (Status(property) is RequireStatus.Missing or RequireStatus.Unable) height += HEIGHT;
        
            return height;
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
    }
}