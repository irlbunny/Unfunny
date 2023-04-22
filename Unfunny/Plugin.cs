using HarmonyLib;
using IPA;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace Unfunny
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal const string HARMONYID = "com.github.ItsKaitlyn03.Unfunny";

        internal static IPALogger Log { get; private set; }
        internal static Harmony HarmonyInstance { get; private set; } = new(HARMONYID);

        [Init]
        public Plugin(IPALogger logger)
        {
            Log = logger;
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnEnable]
        public void OnEnable()
        { }

        [OnDisable]
        public void OnDisable()
        {
            HarmonyInstance.UnpatchSelf();
        }
    }
}
