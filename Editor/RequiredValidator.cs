// using System.Reflection;
// using Incantium.Attributes;
// using UnityEditor;
// using UnityEngine;
//
// namespace Incantium.Editor.Attributes
// {
//     /// <summary>
//     /// Class that handles the searching and validation of all required object reference fields in the game object
//     /// within the current scenes.
//     /// </summary>
//     /// <seealso cref="Required"/>
//     internal static class RequiredValidator
//     {
//         private static bool errors;
//
//         /// <summary>
//         /// Method to look through all the game objects in the scene for any invalid required fields.
//         /// </summary>
//         [MenuItem("Services/Validation/Required fields", false, 0)]
//         private static void OnValidate()
//         {
//             errors = false;
//             
//             ObjectLocator.CheckScenes(CheckField);
//             
//             if (!errors) Debug.Log("No missing required fields found.");
//         }
//         
//         /// <summary>
//         /// Method to look through all the game objects in the scene at the initialization of play mode in the Unity
//         /// Editor.
//         /// </summary>
//         [InitializeOnEnterPlayMode]
//         private static void OnEnterPlayMode()
//         {
//             errors = false;
//             
//             ObjectLocator.CheckScenes(CheckField);
//         
//             if (errors) EditorApplication.isPaused = true;
//         }
//
//         /// <summary>
//         /// Method to check if a field is required. If it is, it will check if there is a value attached. Otherwise, it
//         /// will log an error.
//         /// </summary>
//         /// <param name="field">The field to check.</param>
//         /// <param name="obj">The object to which the field is attached.</param>
//         /// <param name="path">The path at which the field is located in the hierarchy.</param>
//         private static void CheckField(FieldInfo field, object obj, string path)
//         {
//             if (!field.IsDefined(typeof(Required))) return;
//
//             var value = field.GetValue(obj);
//                 
//             if (value != null && !value.Equals(null)) return;
//                 
//             Error(field.Name, path);
//         }
//
//         /// <summary>
//         /// Method to log the error found.
//         /// </summary>
//         /// <param name="field">The name of the field that is not set and is required.</param>
//         /// <param name="path">The path to the field in the hierarchy.</param>
//         private static void Error(string field, string path)
//         {
//             errors = true;
//             
//             Debug.LogError($"Required object reference field '{field}' is not set at '{path}'.");
//         }
//     }
// }