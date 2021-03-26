using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Update.System
{
    public sealed class UpdateManager : MonoData
    {
        static IMonoData monoData = null;

        public static IMonoData MonoData
        {
            get
            {
                if (monoData == null)
                {
                    monoData = (IMonoData)FindObjectOfType(typeof(UpdateManager));
                }

                return monoData;

            }
        }

        private UpdateManager() { }

        private void Awake()
        {
            monoData = this;

            DontDestroyOnLoad(this);
        }

        void Update()
        {
            for (int i = 0; i < Updates.Count; i++)
            {
                int count = Updates.Count;

                Updates[i].update?.ThisUpdate();

                while (count > Updates.Count && Updates.Count > 0)
                {
                    if (i > Updates.Count - 1) break;
                    Updates[i].update?.ThisUpdate();
                    count--;
                }
            }
        }

        private void LateUpdate()
        {
            foreach (var item in LateUpdates)
            {
                item?.ThisLateUpdate();
            }
        }

        private void FixedUpdate()
        {
            foreach (var item in FixedUpdates)
            {
                item?.ThisFixedUpdates();
            }
        }
    }
}


