using SonsSdk;
using HarmonyLib;
using Sons.Ai.Vail;
using TheForest;
using SUI;
using Microsoft.VisualBasic;
using static RedLoader.RLog;
using UnityEngine;
namespace SizeCustomizer;


[HarmonyPatch(typeof(VailActor), nameof(VailActor.Awake))]
public class SizeCustomizerAwake
{
    public static VailActorTypeId currentnpc = VailActorTypeId.Armsy;
    public static float npcsize = 8;
    public static void Postfix(VailActor __instance)
    {
        if (__instance != null && __instance.TypeId == currentnpc)
        {
            __instance.SetScaleMult(npcsize);
        }
        //if (__instance != null && __instance.TypeId == currentnpc)
        //{
        //    __instance.SetScaleMult(npcsize);
        //}
    }
    public static void SpawnEnemy()
    {
        DebugConsole.Instance.SendCommand("addcharacter armsy");
        var armsy = ActorTools.GetPrefab(currentnpc);
        armsy.SetScaleMult(npcsize);
    }
}

    public class SizeCustomizer : SonsMod
{
        public SizeCustomizer()
    {

        // Uncomment any of these if you need a method to run on a specific update loop.
        //OnUpdateCallback = MyUpdateMethod;
        //OnLateUpdateCallback = MyLateUpdateMethod;
        //OnFixedUpdateCallback = MyFixedUpdateMethod;
        //OnGUICallback = MyGUIMethod;

        // Uncomment this to automatically apply harmony patches in your assembly.
        HarmonyPatchAll = true;
    }

    protected override void OnInitializeMod()
    {
        // Do your early mod initialization which doesn't involve game or sdk references here
        Config.Init();
    }

    protected override void OnSdkInitialized()
    {
        // Do your mod initialization which involves game or sdk references here
        // This is for stuff like UI creation, event registration etc.
        SizeCustomizerUi.Create();
        SettingsRegistry.CreateSettings(this, null, typeof(Config));
    }

    protected override void OnGameStart()
    {
        // This is called once the player spawns in the world and gains control.
    }
}