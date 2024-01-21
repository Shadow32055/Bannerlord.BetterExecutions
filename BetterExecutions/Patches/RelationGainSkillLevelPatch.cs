using HarmonyLib;
using TaleWorlds.CampaignSystem.CharacterDevelopment;

namespace BetterExecutions.Patches {
    [HarmonyPatch(typeof(DefaultSkillLevelingManager), nameof(DefaultSkillLevelingManager.OnGainRelation))]
    internal class RelationGainSkillLevelPatch {
        [HarmonyPrefix]
        private static bool Prefix() {
            if (!BetterExecutions.Settings.EnableCharmXPGain && BetterExecutions.RelationChangeInProgress) {
                return false;
            }
            return true;
        }
    }
}
