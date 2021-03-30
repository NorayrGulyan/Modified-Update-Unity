using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Update.System
{
    public sealed class UpdateManager : MonoData
    {
        static IImplementation implementation = null;

        public static IImplementation Implementation
        {
            get
            {
                if (implementation == null)
                {
                    implementation = (IImplementation)FindObjectOfType(typeof(UpdateManager));
                }

                return implementation;

            }
        }

        public IImplementation GetImplementation => this;

        private UpdateManager() { }

        private void Awake()
        {
            implementation = this;

            DontDestroyOnLoad(this);

            SceneManager.activeSceneChanged += ClearAll;
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
            for (int i = 0; i < LateUpdates.Count; i++)
            {
                int count = LateUpdates.Count;

                LateUpdates[i].update?.ThisLateUpdate();

                while (count > LateUpdates.Count && LateUpdates.Count > 0)
                {
                    if (i > LateUpdates.Count - 1) break;
                    LateUpdates[i].update?.ThisLateUpdate();
                    count--;
                }
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < FixedUpdates.Count; i++)
            {
                int count = FixedUpdates.Count;

                FixedUpdates[i].update?.ThisFixedUpdates();

                while (count > FixedUpdates.Count && FixedUpdates.Count > 0)
                {
                    if (i > FixedUpdates.Count - 1) break;
                    FixedUpdates[i].update?.ThisFixedUpdates();
                    count--;
                }
            }
        }

        private void ClearAll(Scene current, Scene next)
        {
            Updates.Clear();

            LateUpdates.Clear();

            FixedUpdates.Clear();
        }
    }
}


