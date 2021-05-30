using UnityEngine.Profiling;
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
#if UNITY_EDITOR
            for (int i = 0; i < Updates.Count; i++)
            {
                int count = Updates.Count;


                Profiler.BeginSample(Updates[i].Name);
                Updates[i].update?.ThisUpdate();
                Profiler.EndSample();

                while (count > Updates.Count && Updates.Count > 0)
                {
                    if (i > Updates.Count - 1) break;
                    Profiler.BeginSample(Updates[i].Name);
                    Updates[i].update?.ThisUpdate();
                    Profiler.EndSample();
                    count--;
                }
            }
#else
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
#endif
        }

        private void LateUpdate()
        {
#if UNITY_EDITOR
            for (int i = 0; i < LateUpdates.Count; i++)
            {
                int count = LateUpdates.Count;
                Profiler.BeginSample(LateUpdates[i].Name);
                LateUpdates[i].update?.ThisLateUpdate();
                Profiler.EndSample();

                while (count > LateUpdates.Count && LateUpdates.Count > 0)
                {
                    
                    if (i > LateUpdates.Count - 1) break;
                    Profiler.BeginSample(LateUpdates[i].Name);
                    LateUpdates[i].update?.ThisLateUpdate();
                    Profiler.EndSample();
                    count--;
                }
            }
#else
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
#endif
        }

        private void FixedUpdate()
        {
#if UNITY_EDITOR
            for (int i = 0; i < FixedUpdates.Count; i++)
            {
                int count = FixedUpdates.Count;
                Profiler.BeginSample(FixedUpdates[i].Name);
                FixedUpdates[i].update?.ThisFixedUpdates();
                Profiler.EndSample();

                while (count > FixedUpdates.Count && FixedUpdates.Count > 0)
                {
                    if (i > FixedUpdates.Count - 1) break;
                    Profiler.BeginSample(FixedUpdates[i].Name);
                    FixedUpdates[i].update?.ThisFixedUpdates();
                    Profiler.EndSample();
                    count--;
                }
            }
#else
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
#endif
        }

        private void ClearAll(Scene current, Scene next)
        {
            Updates.Clear();

            LateUpdates.Clear();

            FixedUpdates.Clear();
        }
    }
}


