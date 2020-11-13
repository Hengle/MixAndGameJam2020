namespace SenarCustomSystems.Data
{
    using UnityEngine;
    using Sirenix.OdinInspector;
    using System.Linq;

    [CreateAssetMenu(fileName = "Level Selection Conf", menuName = "Custom/Settings/Level Selection Conf", order = 1)]
    public class LevelSelectionConf : AbsSingletonScriptableObject<LevelSelectionConf>
    {
        public bool autoAddAllLevelInAllWorldsOnBuild = true;
    }
}