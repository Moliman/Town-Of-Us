using System.Linq;
using HarmonyLib;
using TownOfUs.Roles;
using UnityEngine;

namespace TownOfUs.NeutralRoles.ArsonistMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Update))]
    public static class MeetingHudUpdate
    {
        public static void Postfix(MeetingHud __instance)
        {
            var playerNotDousedYet = 0;
            Arsonist role = null;
            bool arsonistAlive = false;
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                var __role = Role.GetRole(player);
                if (!(__role?.RoleType != RoleEnum.Arsonist)) continue;
                role = (Arsonist)__role;
                break;
            }
            if (role == null) return;

            if (true)
            {
                foreach (var player in PlayerControl.AllPlayerControls)
                {
                    if (!player.Data.IsDead && !player.Data.Disconnected && !role.DousedPlayers.Contains(player.PlayerId))
                    {
                        if (player.Data.PlayerId == role.Player.PlayerId)
                            arsonistAlive = true;
                        else
                            playerNotDousedYet++;
                    }
                }
                if (arsonistAlive && !__instance.TimerText.text.Contains("Arsonist has "))
                    __instance.TimerText.text = "Arsonist has " + playerNotDousedYet + " member to douse  |  " + __instance.TimerText.text;
            }


            if (role.Player.PlayerId != PlayerControl.LocalPlayer.PlayerId)
                return;

            foreach (var state in __instance.playerStates)
            {
                var targetId = state.TargetPlayerId;
                var playerData = Utils.PlayerById(targetId)?.Data;
                if (playerData == null || playerData.Disconnected)
                {
                    role.DousedPlayers.Remove(targetId);
                    continue;
                }
                if (role.DousedPlayers.Contains(targetId)) state.NameText.color = Color.black;
            }
        }
    }
}