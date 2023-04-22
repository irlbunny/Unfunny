using HarmonyLib;
using System;

namespace Unfunny.HarmonyPatches
{
    [HarmonyPatch(typeof(DateTime), "get_Now")]
    internal class DateTimeNow
    {
        private static void Postfix(ref DateTime __result)
        {
            var month = __result.Month;
            var day = __result.Day;
            if ((month == 4 && day == 1) || (month == 4 && day == 22))
                __result = __result.AddDays(1); // Skip to April 2nd or April 23rd, thus skipping april fools and earth day.
        }
    }
}
