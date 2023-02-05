// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using Coherence.Toolkit;
	using Coherence.Toolkit.Bindings;
	using Coherence.Entity;
	using Coherence.ProtocolDef;
	using Coherence.Brook;
	using Coherence.Toolkit.Bindings.ValueBindings;
	using Coherence.Toolkit.Bindings.TransformBindings;
	using Coherence.Connection;
	using Coherence.Log;
	using Logger = Coherence.Log.Logger;
	using UnityEngine.Scripting;


	[Preserve]
	[AddComponentMenu("coherence/Baked/Baked 'Civilization Soldier Variant' (auto assigned)")]
	[RequireComponent(typeof(CoherenceSync))]
	public class CoherenceSyncCivilization__char_32_Soldier__char_32_Variant : CoherenceSyncBaked
	{
		private CoherenceSync coherenceSync;
		private Logger logger;

		// Cached targets for commands		
		private WorldTree.Unit Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c_CommandTarget;		
		private WorldTree.Unit Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783_CommandTarget;		
		private WorldTree.Unit Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb_CommandTarget;

		private IClient client;
		private CoherenceMonoBridge monoBridge => coherenceSync.MonoBridge;

		protected void Awake()
		{
			coherenceSync = GetComponent<CoherenceSync>();
			coherenceSync.usingReflection = false;

			logger = coherenceSync.logger.With<CoherenceSyncCivilization__char_32_Soldier__char_32_Variant>();
			if (coherenceSync.TryGetBindingByGuid("5ab2979e-eb8b-45ea-8097-91e018ffa77c", "Damage", out Binding Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c))
			{
				Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c_CommandTarget = (WorldTree.Unit)Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c.UnityComponent;
				coherenceSync.AddCommandRequestDelegate("WorldTree.Unit.Damage", "(System.Single)",
				SendCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c, ReceiveLocalCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c, MessageTarget.AuthorityOnly, Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c_CommandTarget,false);
			}
			else
			{
				logger.Error("Couldn't find command binding (Damage)");
			}
			if (coherenceSync.TryGetBindingByGuid("e283d7c7-4ebf-493f-9823-17f79a943783", "Heal", out Binding Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783))
			{
				Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783_CommandTarget = (WorldTree.Unit)Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783.UnityComponent;
				coherenceSync.AddCommandRequestDelegate("WorldTree.Unit.Heal", "(System.Single)",
				SendCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783, ReceiveLocalCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783, MessageTarget.AuthorityOnly, Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783_CommandTarget,false);
			}
			else
			{
				logger.Error("Couldn't find command binding (Heal)");
			}
			if (coherenceSync.TryGetBindingByGuid("6661d113-8f98-49d6-a6f6-fca2d95730eb", "Die", out Binding Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb))
			{
				Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb_CommandTarget = (WorldTree.Unit)Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb.UnityComponent;
				coherenceSync.AddCommandRequestDelegate("WorldTree.Unit.Die", "()",
				SendCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb, ReceiveLocalCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb, MessageTarget.AuthorityOnly, Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb_CommandTarget,false);
			}
			else
			{
				logger.Error("Couldn't find command binding (Die)");
			}
		}

		public override List<ICoherenceComponentData> CreateEntity()
		{
			if (coherenceSync.UsesLODsAtRuntime && (Archetypes.IndexForName.TryGetValue(coherenceSync.Archetype.ArchetypeName, out int archetypeIndex)))
			{
				var components = new List<ICoherenceComponentData>()
				{
					new ArchetypeComponent
					{
						index = archetypeIndex
					}
				};

				return components;
			}
			else
			{
				logger.Warning($"Unable to find archetype {coherenceSync.Archetype.ArchetypeName} in dictionary. Please, bake manually (coherence > Bake)");
			}

			return null;
		}

		public override void Initialize(CoherenceSync sync, IClient client)
		{
			if (coherenceSync == null)
			{
				coherenceSync = sync;
			}
			this.client = client;
		}
		void SendCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c(MessageTarget target, object[] args)
		{
			var command = new Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c();
			int i = 0;
			command.damage = (float)((System.Single)args[i++]);
			client.SendCommand(command, target, coherenceSync.EntityID);
		}

		void ReceiveLocalCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c(MessageTarget target, object[] args)
		{
			var command = new Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c();
			int i = 0;
			command.damage = (float)((System.Single)args[i++]);
			ReceiveCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c(command);
		}

		void ReceiveCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c(Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c command)
		{
			var target = Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c_CommandTarget;
			target.Damage((System.Single)(command.damage));
		}
		void SendCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783(MessageTarget target, object[] args)
		{
			var command = new Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783();
			int i = 0;
			command.health = (float)((System.Single)args[i++]);
			client.SendCommand(command, target, coherenceSync.EntityID);
		}

		void ReceiveLocalCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783(MessageTarget target, object[] args)
		{
			var command = new Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783();
			int i = 0;
			command.health = (float)((System.Single)args[i++]);
			ReceiveCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783(command);
		}

		void ReceiveCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783(Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783 command)
		{
			var target = Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783_CommandTarget;
			target.Heal((System.Single)(command.health));
		}
		void SendCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb(MessageTarget target, object[] args)
		{
			var command = new Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb();
			client.SendCommand(command, target, coherenceSync.EntityID);
		}

		void ReceiveLocalCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb(MessageTarget target, object[] args)
		{
			var command = new Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb();
			ReceiveCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb(command);
		}

		void ReceiveCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb(Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb command)
		{
			var target = Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb_CommandTarget;
			target.Die();
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				case Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c castedCommand:
					ReceiveCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Damage_5ab2979e_eb8b_45ea_8097_91e018ffa77c(castedCommand);
					break;
				case Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783 castedCommand:
					ReceiveCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Heal_e283d7c7_4ebf_493f_9823_17f79a943783(castedCommand);
					break;
				case Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb castedCommand:
					ReceiveCommand_Civilization__char_32_Soldier__char_32_Variant_WorldTree__char_46_Unit__char_46_Die_6661d113_8f98_49d6_a6f6_fca2d95730eb(castedCommand);
					break;
				default:
					logger.Warning($"[CoherenceSyncCivilization__char_32_Soldier__char_32_Variant] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}
