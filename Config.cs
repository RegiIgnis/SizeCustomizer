using RedLoader;
using RedLoader.Preferences;
using SizeCustomizer;
using SonsSdk;
using SonsSdk.Attributes;

public static class Config
{
    public static ConfigCategory Category { get; private set; }
    public static KeybindConfigEntry SpawnEnemy { get; private set; }

    //public static ConfigEntry<bool> SomeEntry { get; private set; }
    public static void Init()
    {
        Category = ConfigSystem.CreateFileCategory("SizeCustomizer", "SizeCustomizer", "SizeCustomizer.cfg");

        // SomeEntry = Category.CreateEntry(
        //     "some_entry",
        //     true,
        //     "Some entry",
        //     "Some entry that does some stuff.");
        SpawnEnemy = Category.CreateKeybindEntry("SpawnEnemy", EInputKey.o, "Spawn an enemy in front of the player", "Spawn an enemy in front of the player");
        SpawnEnemy.Notify(SizeCustomizerAwake.SpawnEnemy);
    }
}