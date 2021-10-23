
using HarmonyLib;
using Verse;
using Verse.AI;
using RimWorld;
using System;

namespace BoundaryTraining
{
	[HarmonyPatch(typeof(TrainingCardUtility), nameof(TrainingCardUtility.TryDrawTrainableRow))]
	public class Patch_TryDrawTrainableRow
	{
		static public bool Prefix(Pawn pawn, TrainableDef td)
		{	
			if (td == ResourceBank.TrainableDefOf.Owl_Boundaries && (pawn.RaceProps.roamMtbDays == null || pawn.RaceProps.Dryad)) return false;
			return true;
		}
    }

	[HarmonyPatch(typeof(PawnColumnWorker_Trainable), nameof(PawnColumnWorker_Trainable.DoCell))]
	public class Patch_DoCell
	{
		static public bool Prefix(Pawn pawn, PawnColumnWorker_Trainable __instance)
		{	
			if (__instance.def.trainable == ResourceBank.TrainableDefOf.Owl_Boundaries && (pawn.RaceProps.roamMtbDays == null || pawn.RaceProps.Dryad)) return false;
			return true;
		}
    }

	[HarmonyPatch(typeof(MentalStateWorker_Roaming), nameof(MentalStateWorker_Roaming.CanRoamNow))]
	public class Patch_CanRoamNow
	{
		static public void Postfix(ref bool __result, Pawn pawn)
		{
			if (pawn.training.HasLearned(ResourceBank.TrainableDefOf.Owl_Boundaries)) __result = false;
		}
    }

	[HarmonyPatch(typeof(Pawn_PlayerSettings), nameof(Pawn_PlayerSettings.SupportsAllowedAreas), MethodType.Getter)]
	public class Patch_SupportsAllowedAreas
	{
		static public void Postfix(ref bool __result, Pawn_PlayerSettings __instance)
		{	
			if (__instance.pawn.training?.HasLearned(ResourceBank.TrainableDefOf.Owl_Boundaries) ?? false) __result = true;
		}
    }

	[HarmonyPatch(typeof(AnimalPenUtility), nameof(AnimalPenUtility.NeedsToBeManagedByRope))]
	public class Patch_NeedsToBeManagedByRope
	{
		static public bool Prefix(ref bool __result, Pawn pawn)
		{	
			if (pawn.training?.HasLearned(ResourceBank.TrainableDefOf.Owl_Boundaries) ?? false)
			{
				__result = false;
				return false;
			}
			return true;
		}
    }
}
