using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterExecutions.Settings {
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {


        [SettingPropertyBool("Enable Execution Relation Notifications", Order = 1, HintText = "Display notifications for each hero affected by executions.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public bool EnableRelationChanges { get; set; } = false;

        [SettingPropertyBool("Enable Charm XP Gain On Relation Changes", Order = 2, HintText = "Gain Charm XP from positive relation changes caused by executions.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public bool EnableCharmXPGain { get; set; } = false;

        [SettingPropertyBool("Enable AI Execution", Order = 3, HintText = "Allow AI heroes to execute prisoners, including the player.", RequireRestart = true)]
        [SettingPropertyGroup("General")]
        public bool AIExecution { get; set; } = true;

        [SettingPropertyInteger("AI Execution Chance Reduction", 0, 100, Order = 4, HintText = "Percentage reduction applied to AI execution probability.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public int AIChanceReduction { get; set; } = 14;

        [SettingPropertyInteger("Minimum Age", 0, 100, Order = 4, HintText = "Minimum age for heroes to have relation changes from executions.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public int MinimumAge { get; set; } = 14;

        [SettingPropertyInteger("Notification Thresshold", 0, 100, Order = 4, HintText = "Relation changes above this are sent in chat.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public int NotificationThreshold { get; set; } = 10;

		// FAMILIAL

        [SettingPropertyInteger("Spouse", 0, 100, Order = 1, HintText = "Relation penalty for executing a hero's spouse.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int SpouseRelationLoss { get; set; } = 100;

        [SettingPropertyInteger("Parent", 0, 100, Order = 2, HintText = "Relation penalty for executing a hero's parent.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int ParentRelationLoss { get; set; } = 75;

        [SettingPropertyInteger("Child", 0, 100, Order = 3, HintText = "Relation penalty for executing a hero's child.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int ChildRelationLoss { get; set; } = 75;

        [SettingPropertyInteger("Sibling", 0, 100, Order = 4, HintText = "Relation penalty for executing a hero's sibling.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int SiblingRelationLoss { get; set; } = 60;

        [SettingPropertyInteger("Same Clan", 0, 100, Order = 5, HintText = "Relation penalty for executing a hero's clan member.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int SameClanRelationLoss { get; set; } = 20;

        // SOCIAL RELATIONS

        [SettingPropertyInteger("Friend Relation Loss", 0, 100, Order = 1, HintText = "Base relation penalty for executing a hero's friend.", RequireRestart = false)]
        [SettingPropertyGroup("Social Relation Change")]
        public int FriendRelationLoss { get; set; } = 10;

        [SettingPropertyInteger("Enemy Relation Gain", 0, 100, Order = 2, HintText = "Base relation bonus for executing a hero's enemy.", RequireRestart = false)]
        [SettingPropertyGroup("Social Relation Change")]
        public int EnemyRelationGain { get; set; } = 10;

        // FACTIONS

        [SettingPropertyInteger("Same Faction", 0, 100, Order = 1, HintText = "Relation penalty for executing an ally. Quadrupled if victim is a ruler.", RequireRestart = false)]
        [SettingPropertyGroup("Faction Relation Change")]
        public int SameFactionRelationLoss { get; set; } = 15;

        [SettingPropertyInteger("Enemy Faction", 0, 100, Order = 2, HintText = "Relation bonus for executing an enemy. Quadrupled if victim is a ruler.", RequireRestart = false)]
        [SettingPropertyGroup("Faction Relation Change")]
        public int EnemyFactionRelationGain { get; set; } = 15;

		// TRAIT MODIFIERS

        [SettingPropertyInteger("Honor Modifier", 0, 100, Order = 1, HintText = "Multiplier applied based on the victim's Honor trait level.", RequireRestart = false)]
        [SettingPropertyGroup("Trait Modifiers")]
        public int HonorModifier { get; set; } = 2;

        [SettingPropertyInteger("Mercy Modifier", 0, 100, Order = 2, HintText = "Multiplier applied based on the observer's Mercy trait level.", RequireRestart = false)]
        [SettingPropertyGroup("Trait Modifiers")]
        public int MercyModifier { get; set; } = 2;

        [SettingPropertyInteger("Ruler Modifier", 0, 100, Order = 3, HintText = "Multiplier applied when executing a faction ruler.", RequireRestart = false)]
        [SettingPropertyGroup("Trait Modifiers")]
        public int RulerMultiplier { get; set; } = 2;

        // EXECUTION LOOT

        [SettingPropertyGroup("Execution Loot")]
        [SettingPropertyBool("Executions Grant Gear", IsToggle = true, Order = 1, RequireRestart = false, HintText = "Executed heroes drop their equipment as loot.")]
        public bool EnableExecutionLoot { get; set; } = false;

        [SettingPropertyGroup("Execution Loot")]
        [SettingPropertyFloatingInteger("Usable Chance", 0f, 1f, "0.0%", Order = 2, RequireRestart = false, HintText = "Probability that each equipment piece is in usable condition.")]
        public float ExecutionLootUsableChance { get; set; } = .5f;

        [SettingPropertyGroup("Execution Loot")]
        [SettingPropertyInteger("Price Threshold", 0, 1000000, "0", Order = 3, RequireRestart = false, HintText = "Maximum item value to drop (based on nearest town). Set to 0 for no limit.")]
        public int ExecutionLootPriceThreshold { get; set; } = 0;

        [SettingPropertyGroup("Execution Loot")]
        [SettingPropertyBool("Include Civilian Gear", Order = 4, RequireRestart = false, HintText = "Include the victim's civilian equipment in potential loot.")]
        public bool ExecutionLootCivilianGear { get; set; } = false;


        public override string Id { get { return GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
    }
}
