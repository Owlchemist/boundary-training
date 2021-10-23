using Verse;
using HarmonyLib;
 
namespace BoundaryTraining
{
    public class Mod_BoundaryTraining : Mod
	{
		public Mod_BoundaryTraining(ModContentPack content) : base(content)
		{
			new Harmony(this.Content.PackageIdPlayerFacing).PatchAll();
		}
	}
}
