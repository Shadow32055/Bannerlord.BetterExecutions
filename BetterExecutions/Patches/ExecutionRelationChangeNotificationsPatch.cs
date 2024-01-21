using HarmonyLib;
using TaleWorlds.CampaignSystem.Actions;

namespace BetterExecutions.Patches {
    [HarmonyPatch(typeof(KillCharacterAction), "ApplyInternal")]
    internal class KillCharacterActionPatch {
        [HarmonyPrefix]
        private static void Prefix(KillCharacterAction.KillCharacterActionDetail actionDetail) {
            // Replace true with mcm config
            if (actionDetail == KillCharacterAction.KillCharacterActionDetail.Executed) {
                if (!BetterExecutions.Settings.EnableRelationChanges)
                    BetterExecutions.HideRelationNotifications = true;
                if (!BetterExecutions.Settings.EnableCharmXPGain)
                    BetterExecutions.RelationChangeInProgress = true;
            }
        }

        [HarmonyPostfix]
        private static void Postfix() {
            BetterExecutions.HideRelationNotifications = false;
            BetterExecutions.RelationChangeInProgress = false;
        }
    }

    [HarmonyPatch(typeof(ChangeRelationAction), "ApplyInternal")]
    internal class ChangeRelationActionPatch {
        [HarmonyPrefix]
        private static void Prefix(ref bool showQuickNotification) {
            if (BetterExecutions.HideRelationNotifications)
                showQuickNotification = false;
        }
    }
}
