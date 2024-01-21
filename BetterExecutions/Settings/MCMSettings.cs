using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterExecutions.Settings {
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {


        [SettingPropertyBool("Enable Execution Relation Notifications", Order = 1, HintText = "Enables notifications for all 100-200+ heroes you change relations with.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public bool EnableRelationChanges { get; set; } = false;

        [SettingPropertyBool("Enable Charm XP Gain On Relation Changes", Order = 2, HintText = "Enables charm XP gain for a positive relation change upon executing another.", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public bool EnableCharmXPGain { get; set; } = false;

        [SettingPropertyBool("Enable AI Execution", Order = 3, HintText = "Enables AI heroes to execute other AI heroes (or you probably).", RequireRestart = false)]
        [SettingPropertyGroup("General")]
        public bool AIExecution { get; set; } = true;

        // REQUIREMENTS

        [SettingPropertyInteger("Minimum Age", 0, 100, Order = 1, HintText = "Set the minimum age a hero needs to react to an execution.", RequireRestart = false)]
        [SettingPropertyGroup("Relation Change Requirements")]
        public int MinimumAge { get; set; } = 14;

        // TRAIT MODIFIERS

        [SettingPropertyInteger("Honor Modifier", 0, 100, Order = 1, HintText = "Multiplies this by the honor value to find a relation decrease/increase.", RequireRestart = false)]
        [SettingPropertyGroup("Trait Modifiers")]
        public int HonorModifier { get; set; } = 10;

        [SettingPropertyInteger("Mercy Modifier", 0, 100, Order = 2, HintText = "Multiplies this by the mercy value to find a relation decrease/increase.", RequireRestart = false)]
        [SettingPropertyGroup("Trait Modifiers")]
        public int MercyModifier { get; set; } = 20;

        // FACTIONS

        [SettingPropertyInteger("Same Faction", 0, 100, Order = 1, HintText = "Relation LOSS if executed faction member. This is multiplied by 4 if victim is a king/independent leader.", RequireRestart = false)]
        [SettingPropertyGroup("Faction Relation Change")]
        public int SameFactionRelationLoss { get; set; } = 15;

        [SettingPropertyInteger("Enemy Faction", 0, 100, Order = 2, HintText = "Relation GAIN if executed enemy faction member. This is multiplied by 4 if victim is a king/independent leader.", RequireRestart = false)]
        [SettingPropertyGroup("Faction Relation Change")]
        public int EnemyFactionRelationGain { get; set; } = 15;

        // FAMILIAL

        /*[SettingPropertyInteger("Spouse", 0, 100, Order = 1, HintText = "Relation LOSS if executed spouse.", RequireRestart = false)]
		[SettingPropertyGroup("Familial Relation Change")]
		public int SpouseRelationLoss { get; set; } = 100;*/

        [SettingPropertyInteger("Parent/Child", 0, 100, Order = 2, HintText = "Relation LOSS if executed parent/child.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int ParentChildRelationLoss { get; set; } = 75;

        [SettingPropertyInteger("Sibling", 0, 100, Order = 3, HintText = "Relation LOSS if executed sibling.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int SiblingRelationLoss { get; set; } = 60;

        [SettingPropertyInteger("Same Clan", 0, 100, Order = 4, HintText = "Relation LOSS if executed clan member.", RequireRestart = false)]
        [SettingPropertyGroup("Familial Relation Change")]
        public int SameClanRelationLoss { get; set; } = 20;

        [SettingPropertyGroup("Drop Gear")]
        [SettingPropertyBool("Executions Grant Gear", IsToggle = true, Order = 0, RequireRestart = false, HintText = "Do executed lords drop their gear.")]
        public bool EnableExecutionLoot { get; set; } = false;

        [SettingPropertyGroup("Drop Gear")]
        [SettingPropertyFloatingInteger("Usable Chance", 0f, 1f, "0.0%", Order = 0, RequireRestart = false, HintText = "Chance each piece of gear is in good enough quality to be added to your inventory")]
        public float ExecutionLootUsableChance { get; set; } = .5f;


        public override string Id { get { return GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
    }
}
