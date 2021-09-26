using HarmonyLib;

namespace TownOfUs
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Update))]
    public class MeetingHud_Update
    {
        public static void Postfix(MeetingHud __instance)
        {
            if (__instance.state == MeetingHud.VoteStates.NotVoted)
            {
                // Nothing yet...
            }
        }
    }
}
