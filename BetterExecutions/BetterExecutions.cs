using BetterCore.Utils;
using BetterExecutions.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterExecutions {
    public class BetterExecutions : MBSubModuleBase {
        public static Random Random = new();

        public static bool HideRelationNotifications = false;
        public static bool RelationChangeInProgress = false;

        public static MCMSettings Settings { get; private set; } = new MCMSettings();
        public static ItemRoster Items { get; set; } = new ItemRoster();
        public static string ModName { get; private set; } = "BetterExecutions";

        private bool isInitialized = false;
        private bool isLoaded = false;

        //FIRST
        protected override void OnSubModuleLoad() {
            try {
                base.OnSubModuleLoad();

                if (isInitialized)
                    return;

                Harmony h = new("Bannerlord.Shadow." + ModName);

                h.PatchAll();

                isInitialized = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnSubModuleLoad threw exception " + e);
            }
        }

        //SECOND
        protected override void OnBeforeInitialModuleScreenSetAsRoot() {
            try {
                base.OnBeforeInitialModuleScreenSetAsRoot();

                if (isLoaded)
                    return;

                ModName = base.GetType().Assembly.GetName().Name;

                Settings = MCMSettings.Instance ?? throw new NullReferenceException("Settings are null");

                NotifyHelper.WriteMessage(ModName + " Loaded.", MsgType.Good);
                //Integrations.BetterBandagesLoaded = true;

                isLoaded = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnBeforeInitialModuleScreenSetAsRoot threw exception " + e);
            }
        }

        protected override void OnGameStart(Game game, IGameStarter starterObject) {
            starterObject.AddModel(new NewExecutionRelationModel());

            if (game.GameType is Campaign) {
                CampaignGameStarter campaignStarter = (CampaignGameStarter)starterObject;

                campaignStarter.AddBehavior(new AIExecutionBehavior());
            }
        }
    }
}