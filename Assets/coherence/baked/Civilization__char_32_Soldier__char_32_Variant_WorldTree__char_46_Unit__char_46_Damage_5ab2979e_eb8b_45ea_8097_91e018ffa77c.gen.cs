// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using Coherence.Brook;
	using UnityEngine;
	using Coherence.Entity;

	public struct Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c : IEntityCommand
	{
		public float damage;

		public MessageTarget Routing => MessageTarget.AuthorityOnly;
		public uint GetComponentType() => Definition.InternalCivilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c;

		public Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c
		(
			float datadamage
		)
		{
			damage = datadamage;
		}

		public static void Serialize(Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c commandData, IOutProtocolBitStream bitStream)
		{
			bitStream.WriteFloat(commandData.damage, FloatMeta.NoCompression());
		}

		public static Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c Deserialize(IInProtocolBitStream bitStream)
		{
			var datadamage = bitStream.ReadFloat(FloatMeta.NoCompression());

			return new Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c
			(
				datadamage
			){};
		}
	}
}
