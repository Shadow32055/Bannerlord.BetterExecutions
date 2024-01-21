using BetterCore.Utils;
using HarmonyLib;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace BetterExecutions.Patches {
    [HarmonyPatch]
    internal class PartyScreenLogicPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PartyScreenLogic), "ExecuteTroop")]
        public static void ExecuteTroopPostfix(PartyScreenLogic.PartyCommand command) {
            if (!BetterExecutions.Settings.EnableExecutionLoot)
                return;

            foreach (EquipmentIndex equipmentIndex in LootHelper.LootableSlots) {

                EquipmentElement equipment = command.Character.Equipment.GetEquipmentFromSlot(equipmentIndex);

                if (equipment.Item == null)
                    continue;

                if (MathHelper.RandomChance(BetterExecutions.Settings.ExecutionLootUsableChance)) {
                    PartyBase.MainParty.ItemRoster.AddToCounts(equipment.Item, 1);
                    NotifyHelper.WriteMessage("Added " + equipment.Item.Name + " to inventory.", MsgType.Good);
                }
            }
        }
    }
}
