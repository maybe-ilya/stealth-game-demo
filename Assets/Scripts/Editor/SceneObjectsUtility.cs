using System.Linq;
using UnityEditor;

namespace MIG.Editor
{
    public static class SceneObjectsUtility
    {
        private const string GAMEOBJECT_PATH_ROOT = "GameObject/";
        private const string SORT_GAMEOBJECTS_BY_NAME_PATH = GAMEOBJECT_PATH_ROOT + "Sort By Name";

        [MenuItem(SORT_GAMEOBJECTS_BY_NAME_PATH, isValidateFunction: true)]
        private static bool CanSortSelectedGameObject()
        {
            var transforms = Selection.transforms;
            return transforms.Length > 1 &&
                   transforms.Select(transform => transform.parent?.GetInstanceID() ?? int.MinValue)
                       .Distinct()
                       .Count() == 1;
        }

        [MenuItem(SORT_GAMEOBJECTS_BY_NAME_PATH, isValidateFunction: false)]
        private static void SortSelectedGameObjectByName()
        {
            foreach (var transform in Selection.transforms.OrderBy(transform => transform.name).Reverse())
            {
                transform.SetAsFirstSibling();
            }
        }
    }
}