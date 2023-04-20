using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria;
using BepInEx;

namespace ETGClasses
{
    [BepInDependency("etgmodding.etg.mtgapi")]
    [BepInPlugin(GUID, NAME, VERSION)]

    public class Module : BaseUnityPlugin
    {
        public const string GUID = "lynceus.etg.classes";
        public const string NAME = "R&D Ammonomicon";
        public const string VERSION = "1.0";
        public const string TEXT_COLOR = "#eb34d8";
        public static AdvancedStringDB Strings;
        public void Start()
        {
            ETGModMainBehaviour.WaitForGameManagerStart(GMStart);
        }



        public void GMStart(GameManager g)
        {
            Log($"{NAME} has added entries! Go unlock them, if you haven't.", TEXT_COLOR);
            Module.Strings = new AdvancedStringDB();

            EnemyBuilder.Init();

            GameStart.Init();
        }
        public static void Log(string text, string color = "FFFFFF")
        {
            ETGModConsole.Log($"<color={color}>{text}</color>");
        }

    }
}
