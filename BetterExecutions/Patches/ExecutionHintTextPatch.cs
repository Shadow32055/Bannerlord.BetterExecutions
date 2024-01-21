using HarmonyLib;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SceneInformationPopupTypes;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace BetterExecutions.Patches {
    [HarmonyPatch(typeof(HeroExecutionSceneNotificationData), "GetExecuteTroopHintText")]
    internal class ExecutionHintTextPatch {
        [HarmonyPrefix]
        private static bool Prefix(ref TextObject __result, Hero dyingHero, bool showAll) {
			// SAVE RULER INFORMATION FOR ACTUAL EXECUTION RELATIONS
			NewExecutionRelationModel.IsHeroRuler[dyingHero] = dyingHero.MapFaction != null && dyingHero.MapFaction.Leader != null && dyingHero.MapFaction.Leader == dyingHero;

			Dictionary<Hero, int> heroRelationChanges = new Dictionary<Hero, int>();
			GameTexts.SetVariable("LEFT", new TextObject("{=jxypVgl2}Relation Changes", null));
			string text = GameTexts.FindText("str_LEFT_colon", null).ToString();
			foreach (Clan clan in Clan.All) {
				foreach (Hero hero in clan.Heroes) {
					if (!hero.IsHumanPlayerCharacter && hero.IsAlive && hero != dyingHero) {
						bool flag;
						int relationChangeForExecutingHero = Campaign.Current.Models.ExecutionRelationModel.GetRelationChangeForExecutingHero(dyingHero, hero, out flag);
						if (relationChangeForExecutingHero != 0) {
							heroRelationChanges[hero] = relationChangeForExecutingHero;
						}
					}
				}
			}
			GameTexts.SetVariable("newline", "\n");
			int num = 0;
			foreach (KeyValuePair<Hero, int> keyValuePair in heroRelationChanges) {
				Hero key = keyValuePair.Key;
				int value = keyValuePair.Value;
				GameTexts.SetVariable("LEFT", key.Name);
				GameTexts.SetVariable("RIGHT", value);
				string content = GameTexts.FindText("str_LEFT_colon_RIGHT_wSpaceAfterColon", null).ToString();
				GameTexts.SetVariable("STR1", text);
				GameTexts.SetVariable("STR2", content);
				text = GameTexts.FindText("str_string_newline_string", null).ToString();
				num++;
				if (!showAll && num == 8) {
					TextObject content2 = new TextObject("{=DPTPuyip}And {NUMBER} more...", null);
					GameTexts.SetVariable("NUMBER", heroRelationChanges.Count - num);
					GameTexts.SetVariable("STR1", text);
					GameTexts.SetVariable("STR2", content2);
					text = GameTexts.FindText("str_string_newline_string", null).ToString();
					TextObject textObject = new TextObject("{=u12ocP9f}Hold '{EXTEND_KEY}' for more info.", null);
					textObject.SetTextVariable("EXTEND_KEY", GameTexts.FindText("str_game_key_text", "anyalt"));
					GameTexts.SetVariable("STR1", text);
					GameTexts.SetVariable("STR2", textObject);
					text = GameTexts.FindText("str_string_newline_string", null).ToString();
					break;
				}
			}
			__result =  new TextObject("{=!}" + text, null);

			return false;
        }
    }
}
