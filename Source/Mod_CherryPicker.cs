using Verse;
using HarmonyLib;
 
namespace BoundaryTraining
{
    public class Mod_CherryPicker : Mod
	{
		public Mod_CherryPicker(ModContentPack content) : base(content)
		{
			new Harmony(this.Content.PackageIdPlayerFacing).PatchAll();
		}
	}
}
