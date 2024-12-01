using System.Reflection;
using UnityEngine;

namespace Incantium.Attributes.Editor
{
    internal static class ObjectLocator
    {
        /// <summary>
        /// Method to look through the current scenes for game objects with invalid required fields.
        /// </summary>
        /// <param name="method">The method to call for <see cref="MonoBehaviour"/> found in the scene.</param>
        public static void CheckScenes(UnityField method)
        {
            foreach (var gameObject in Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
            {
                CheckGameObject(gameObject, gameObject.scene.name, method);
            }
        }

        /// <summary>
        /// Method to look through a game object for any <see cref="MonoBehaviour"/>s with invalid required fields.
        /// </summary>
        /// <param name="gameObject">The game object to search through.</param>
        /// <param name="path">The path at which the game object is located.</param>
        /// <param name="method">The method to call for <see cref="MonoBehaviour"/> found in the scene.</param>
        private static void CheckGameObject(GameObject gameObject, string path, UnityField method)
        {
            path += "/" + gameObject.name;

            foreach (var behaviour in gameObject.GetComponents<MonoBehaviour>())
            {
                CheckBehaviours(behaviour, path, method);
            }
            
            foreach (Transform child in gameObject.transform)
            {
                CheckGameObject(child.gameObject, path, method);
            }
        }

        /// <summary>
        /// Method to check through a <see cref="MonoBehaviour"/> for invalid required fields.
        /// </summary>
        /// <param name="behaviour">The <see cref="MonoBehaviour"/> to search through.</param>
        /// <param name="path">The path at which the <see cref="MonoBehaviour"/> is located in the hierarchy.</param>
        /// <param name="method">The method to call for <see cref="MonoBehaviour"/> found in the scene.</param>
        private static void CheckBehaviours(MonoBehaviour behaviour, string path, UnityField method)
        {
            if (!behaviour) return;

            foreach (var field in behaviour.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            {
                method.Invoke(field, behaviour, path + "/" + behaviour.GetType().Name);
            }
        }
    }
    
    internal delegate void UnityField(FieldInfo field, MonoBehaviour behaviour, string path);
}