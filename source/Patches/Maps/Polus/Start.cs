using System;
using HarmonyLib;
using TownOfUs.Roles;
using UnityEngine;

namespace TownOfUs.Patches.Maps.Polus
{
    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Start))]
    public static class Start
    {
        public static void Postfix(ShipStatus __instance)
        {
            // Reverse X:
            // Scale: -=1, 0, 0

            // Reverse Y:
            // Scale: 0, -=1, -=0.1 (0.9)

            var mapTable = UnityEngine.GameObject.Find("/PolusShip(Clone)/Admin/mapTable");
            var rightPod = UnityEngine.GameObject.Find("/PolusShip(Clone)/RightPod");
            var mapTableClone = UnityEngine.GameObject.Instantiate(mapTable, rightPod.transform);
            mapTableClone.transform.localPosition = new Vector3(0, -1, 0);
        }
    }
}
