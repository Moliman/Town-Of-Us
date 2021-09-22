using HarmonyLib;
using System.Threading;

namespace TownOfUs
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
    public class MeetingHud_Start
    {
        public static void Postfix(MeetingHud __instance)
        {
            Utils.ShowDeadBodies = PlayerControl.LocalPlayer.Data.IsDead;

            // Voting time initial (for 3 players) (45)
            // Voting time added per player (+15)
            var totalElaspedTime = 0;
            foreach (var voteArea in __instance.playerStates)
            {
                if (voteArea.AmDead)
                    totalElaspedTime += 15; // Reduce voting time per dead players
            }
            // 10 players: 180s
            // 3 players: 60s
            //var totalVotingTime = 15 + 15*totalPlayer

            __instance.discussionTimer = totalElaspedTime;
        }
    }
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Update))]
    public class MeetingHud_Update
    {
        public static void Postfix(MeetingHud __instance)
        {
            if (__instance.state == MeetingHud.VoteStates.NotVoted)
            {
                //temp = __instance;
                //var ooo = new Thread(oooMethod);
                //ooo.Start();
            }

        }
        public static MeetingHud temp;
        public static void oooMethod()
        {
            Thread.Sleep(10);
            temp.discussionTimer = 30;
        }
    }
}
