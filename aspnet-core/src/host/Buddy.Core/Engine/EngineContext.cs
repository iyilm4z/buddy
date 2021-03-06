using System.Runtime.CompilerServices;

namespace Buddy.Engine
{
    public static class EngineContext
    {
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Create();
                }

                return Singleton<IEngine>.Instance;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create()
        {
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new BuddyEngine());
        }

        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }
    }
}