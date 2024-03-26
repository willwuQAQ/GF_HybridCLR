using System.Collections;
using System.Collections.Generic;
using GameFramework.Resource;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameEntry = Game.GameEntry;

namespace GameFramework.Resource
{
    public static class ResourceComponentExtension
    {
        public static void ChangeResourceGroupReadyStateByResourceName(this ResourceComponent resource, string resourceName,
            bool isReady = false)
        {
            var resourceManager = resource.GetResourceManager();
            resourceManager.ChangeResourceGroupReadyState(resourceName,isReady);

            // GameEntry.Resource.Start();
            // List<IResourceGroup> allreourceGroup = new List<IResourceGroup>();
            // resourceManager.GetAllResourceGroups(allreourceGroup);
            // for (int i = 0; i < allreourceGroup.Count; i++)
            // {
            //     allreourceGroup[i].Ready = false;
            // }
            // resourceManager.GetAllLoadAssetInfos()
            // resourceManager..m_ResourceInfos[resourceName].MarkReady();
        }

        public static int GetResourceGroupAssetsCountByName(this ResourceComponent resource, string resourceName)
        {
            var resourceManager = resource.GetResourceManager();
            return resourceManager.GetResourceGroupAssetCountByName(resourceName);
        }
    
    }

}   