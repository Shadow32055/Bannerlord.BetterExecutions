using BetterCore.Utils;
using HarmonyLib;
using Helpers;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace BetterExecutions.Patches {
    [HarmonyPatch]
    internal class PartyScreenLogicPatch {

        [HarmonyPrefix]
        [HarmonyPatch(typeof(PartyScreenLogic), "ExecuteTroop")]
        public static bool ExecuteTroopPostfix(PartyScreenLogic.PartyCommand command) {
            if (!BetterExecutions.Settings.EnableExecutionLoot)
                return true;

            if (!command.Character.IsHero)
                return true;

            Settlement closestTownSettlement = SettlementHelper.FindNearestTown((Settlement s) => s.IsTown && !s.IsStarving && !s.IsUnderSiege && !Clan.PlayerClan.MapFaction.IsAtWarWith(s.OwnerClan.MapFaction), null) ?? SettlementHelper.FindNearestTown((Settlement s) => s.IsTown, null);
            TownMarketData marketData = closestTownSettlement.Town.MarketData;

            List<Equipment> equipmentList = new List<Equipment> {
                command.Character.Equipment
            };

            if (BetterExecutions.Settings.ExecutionLootCivilianGear)
                equipmentList.Add(command.Character.HeroObject.CivilianEquipment);
            
            foreach (Equipment? equipment in equipmentList) {
                if (equipment != null) {

                    foreach (EquipmentIndex equipmentIndex in LootHelper.LootableSlots) {

                        EquipmentElement equipmentElement = equipment.GetEquipmentFromSlot(equipmentIndex);

                        if (equipmentElement.Item == null)
                            continue;

                        ItemData itemData = marketData.GetCategoryData(equipmentElement.Item.GetItemCategory());

                        int itemPrice = Campaign.Current.Models.TradeItemPriceFactorModel.GetPrice(equipmentElement, MobileParty.MainParty, null, true, (float)itemData.InStoreValue, itemData.Supply, itemData.Demand);

                        if (!MathHelper.RandomChance(BetterExecutions.Settings.ExecutionLootUsableChance))
                            continue;

                        if (BetterExecutions.Settings.ExecutionLootPriceThreshold == 0 || BetterExecutions.Settings.ExecutionLootPriceThreshold > itemPrice) {
                            PartyBase.MainParty.ItemRoster.AddToCounts(equipmentElement.Item, 1);
                            NotifyHelper.WriteMessage("Added " + equipmentElement.Item.Name + " to inventory.", MsgType.Good);
                        }
                    }
                }
            }
            return true;
        }
    }
}
