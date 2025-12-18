using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterExecutions.Settings {
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {


        [SettingPropertyBool("Enable Execution Relation Notifications", Order = 1, HintText = "Shows notifications for each hero whose relationship changes when you execute someone.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public bool EnableRelationChanges { get; set; } = false;

        [SettingPropertyBool("Enable Charm XP Gain On Relation Changes", Order = 2, HintText = "Gain Charm XP when executions result in positive relation changes.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public bool EnableCharmXPGain { get; set; } = false;

        [SettingPropertyBool("Enable AI Execution", Order = 3, HintText = "Allows AI heroes to execute other heroes, including the player.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public bool AIExecution { get; set; } = true;

        [SettingPropertyInteger("Minimum Age", 0, 100, Order = 4, HintText = "Minimum age for heroes to react to executions.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public int MinimumAge { get; set; } = 14;

        // FAMILIAL

        [SettingPropertyInteger("Spouse", 0, 100, Order = 1, HintText = "Relation loss when executing someone's spouse.", RequireRestart = false)]
		[SettingPropertyGroup("Familial Relation Change")]
		public int SpouseRelationLoss { get; set; } = 100;

        [SettingPropertyInteger("Parent", 0, 100, Order = 2, HintText = "Relation loss when executing someone's parent.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int ParentRelationLoss { get; set; } = 75;

		[SettingPropertyInteger("Child", 0, 100, Order = 3, HintText = "Relation loss when executing someone's child.", RequireRestart = false)]
		[SettingPropertyGroup("Familial Relation Change")]
		public int ChildRelationLoss { get; set; } = 75;

		[SettingPropertyInteger("Sibling", 0, 100, Order = 4, HintText = "Relation loss when executing someone's sibling.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int SiblingRelationLoss { get; set; } = 60;

        [SettingPropertyInteger("Same Clan", 0, 100, Order = 5, HintText = "Relation loss when executing a member of someone's clan.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int SameClanRelationLoss { get; set; } = 20;

        // SOCIAL RELATIONS

		[SettingPropertyInteger("Friend Relation Loss", 0, 100, Order = 1, HintText = "Base relation loss when executing someone's friend.", RequireRestart = false)]
		[SettingPropertyGroup("Social Relation Change")]
		public int FriendRelationLoss { get; set; } = 10;

		[SettingPropertyInteger("Enemy Relation Gain", 0, 100, Order = 2, HintText = "Base relation gain when executing someone's enemy.", RequireRestart = false)]
		[SettingPropertyGroup("Social Relation Change")]
		public int EnemyRelationGain { get; set; } = 10;

        // FACTIONS

        [SettingPropertyInteger("Same Faction", 0, 100, Order = 1, HintText = "Relation loss when executing a member of your faction. Multiplied by 4 if victim is a ruler.", RequireRestart = false)]
        [SettingPropertyGroup("Faction Relation Change")]
        public int SameFactionRelationLoss { get; set; } = 15;

        [SettingPropertyInteger("Enemy Faction", 0, 100, Order = 2, HintText = "Relation gain when executing an enemy faction member. Multiplied by 4 if victim is a ruler.", RequireRestart = false)]
        [SettingPropertyGroup("Faction Relation Change")]
        public int EnemyFactionRelationGain { get; set; } = 15;

		// TRAIT MODIFIERS

		[SettingPropertyInteger("Honor Modifier", 0, 100, Order = 1, HintText = "Multiplier based on the victim's honor trait level.", RequireRestart = false)]
        [SettingPropertyGroup("Trait Modifiers")]
        public int HonorModifier { get; set; } = 2;

        [SettingPropertyInteger("Mercy Modifier", 0, 100, Order = 2, HintText = "Multiplier based on the hero's mercy trait level.", RequireRestart = false)]
        [SettingPropertyGroup("Trait Modifiers")]
        public int MercyModifier { get; set; } = 2;

		[SettingPropertyInteger("Ruler Modifier", 0, 100, Order = 3, HintText = "Multiplier applied when the victim is a faction ruler.", RequireRestart = false)]
		[SettingPropertyGroup("Trait Modifiers")]
		public int RulerMultiplier { get; set; } = 2;

        // EXECUTION LOOT

        [SettingPropertyGroup("Execution Loot")]
        [SettingPropertyBool("Executions Grant Gear", IsToggle = true, Order = 1, RequireRestart = false, HintText = "Executed lords drop their equipment.")]
        public bool EnableExecutionLoot { get; set; } = false;

        [SettingPropertyGroup("Execution Loot")]
        [SettingPropertyFloatingInteger("Usable Chance", 0f, 1f, "0.0%", Order = 2, RequireRestart = false, HintText = "Chance each equipment piece is in usable condition.")]
        public float ExecutionLootUsableChance { get; set; } = .5f;

        [SettingPropertyGroup("Execution Loot")]
        [SettingPropertyInteger("Price Threshold", 0, 1000000, "0", Order = 3, RequireRestart = false, HintText = "Maximum item price to be obtainable. Calculated at the nearest town. 0 = no limit.")]
        public int ExecutionLootPriceThreshold { get; set; } = 0;

        [SettingPropertyGroup("Execution Loot")]
        [SettingPropertyBool("Include Civilian Gear", Order = 4, RequireRestart = false, HintText = "Victim's civilian equipment can also drop.")]
        public bool ExecutionLootCivilianGear { get; set; } = false;


        public override string Id { get { return GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
    }
}
