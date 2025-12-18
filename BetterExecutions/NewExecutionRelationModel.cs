using BetterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BetterExecutions {
    public class NewExecutionRelationModel : DefaultExecutionRelationModel {
        public static Dictionary<Hero, bool> IsHeroRuler = new();

        // Must be in a clan for hero to run through this natively.
        public override int GetRelationChangeForExecutingHero(Hero victim, Hero hero, out bool showQuickNotification)
		{
			int result = 0;
			showQuickNotification = false;

			if (hero.IsHumanPlayerCharacter || !hero.IsAlive || hero == victim || hero.Age < BetterExecutions.Settings.MinimumAge)
			{
				return result;
			}

			// Familial Relations
			if (hero.Father == victim || hero.Mother == victim)
			{
				result -= BetterExecutions.Settings.ParentRelationLoss;
				//NotifyHelper.WriteMessage($"Negitive relation change: '{hero.Name}' was the child of '{victim.Name}' result:'{result}'", MsgType.Alert);
			}

			if (victim.Father == hero || victim.Mother == hero)
			{
				result -= BetterExecutions.Settings.ChildRelationLoss;
				//NotifyHelper.WriteMessage($"Negitive relation change: '{hero.Name}' was the parent of '{victim.Name}' result:'{result}'", MsgType.Alert);
			}

			if (hero.Spouse == victim)
			{
				result -= BetterExecutions.Settings.SpouseRelationLoss;
				//NotifyHelper.WriteMessage($"Negitive relation change: '{hero.Name}' was the spouse of '{victim.Name}' result:'{result}'", MsgType.Alert);
			}

			if (hero.Siblings.Contains(victim))
			{
				result -= BetterExecutions.Settings.SiblingRelationLoss;
				//NotifyHelper.WriteMessage($"Negitive relation change: '{hero.Name}' and '{victim.Name}' were siblings ' result:'{result}'", MsgType.Alert);
			}

			// Personal Relations
			if (hero.IsEnemy(victim))
			{
				result += BetterExecutions.Settings.EnemyRelationGain;
				//NotifyHelper.WriteMessage($"Positive relation change: '{hero.Name}' and '{victim.Name}' were enemies ' result:'{result}'", MsgType.Alert);
			}
			if (hero.IsFriend(victim))
			{
				result -= BetterExecutions.Settings.FriendRelationLoss;
				//NotifyHelper.WriteMessage($"Negitive relation change: '{hero.Name}' and '{victim.Name}' were friends ' result:'{result}'", MsgType.Alert);
			}

			// Clan Relations
			if (hero.Clan == victim.Clan)
			{
				result -= BetterExecutions.Settings.SameClanRelationLoss;
				//NotifyHelper.WriteMessage($"Negitive relation change: '{hero.Name}' and '{victim.Name}' were in the same clan ' result:'{result}'", MsgType.Alert);
			}


			// Faction Relations
			if (hero.MapFaction == victim.MapFaction)
			{
				result -= BetterExecutions.Settings.SameFactionRelationLoss;
				//NotifyHelper.WriteMessage($"Negitive relation change: '{hero.Name}' and '{victim.Name}' were in the same faction ' result:'{result}'", MsgType.Alert);
			}
			if (victim.MapFaction.IsAtWarWith(hero.MapFaction))
			{
				result += BetterExecutions.Settings.EnemyFactionRelationGain;
				//NotifyHelper.WriteMessage($"Positive relation change: '{hero.Name}' and '{victim.Name}' were in enemy factions ' result:'{result}'", MsgType.Alert);
			}

			// Trait Modifiers
			if (IsHeroRuler[victim])
			{
				result *= BetterExecutions.Settings.RulerMultiplier;
				//NotifyHelper.WriteMessage($"Relation change multiplier applied: '{victim.Name}' was a ruler ' result:'{result}'", MsgType.Alert);
			}

			if (victim.GetTraitLevel(DefaultTraits.Honor) < 0 && result != 0)
			{
				result /= BetterExecutions.Settings.HonorModifier;
				//NotifyHelper.WriteMessage($"Positive relation change multiplier applied: '{victim.Name}' had negative honor ' result:'{result}'", MsgType.Alert);
			}

			if (victim.GetTraitLevel(DefaultTraits.Honor) > 0)
			{
				result *= BetterExecutions.Settings.HonorModifier;
				//NotifyHelper.WriteMessage($"Negitive relation change multiplier applied: '{victim.Name}' had positive honor ' result:'{result}'", MsgType.Alert);
			}

			if (hero.GetTraitLevel(DefaultTraits.Mercy) > 0 && result != 0)
			{
				result /= BetterExecutions.Settings.MercyModifier;
				//NotifyHelper.WriteMessage($"Negative relation change multiplier applied: '{hero.Name}' has positive mercy ' result:'{result}'", MsgType.Alert);
			}
			if (hero.GetTraitLevel(DefaultTraits.Mercy) < 0)
			{
				result *= BetterExecutions.Settings.MercyModifier;
				//NotifyHelper.WriteMessage($"Positive relation change multiplier applied: '{hero.Name}' has negative mercy ' result:'{result}'", MsgType.Alert);
			}

			//NotifyHelper.WriteMessage($"Final relation change for '{hero.Name}' executing '{victim.Name}': '{result}'", MsgType.Warning);
			return result;
        }
    }
}
