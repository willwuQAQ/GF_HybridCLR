using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class UserInfoComponent : GameFrameworkComponent
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public int userId { get; set; }
    }
}
