using System.IO;
using System.Linq;

namespace Penumbra.Mods;

public enum ModPathChangeType
{
    Added,
    Deleted,
    Moved,
    Reloaded,
    StartingReload,
}

public partial class Mod
{
    public DirectoryInfo ModPath { get; private set; }
    public int Index { get; private set; } = -1;

    // Unused if Index < 0 but used for special temporary mods.
    public int Priority
        => 0;

    private Mod( DirectoryInfo modPath )
    {
        ModPath  = modPath;
        _default = new SubMod( this );
    }

    private static Mod? LoadMod( DirectoryInfo modPath, bool incorporateMetaChanges )
    {
        modPath.Refresh();
        if( !modPath.Exists )
        {
            Penumbra.Log.Error( $"Supplied mod directory {modPath} does not exist." );
            return null;
        }

        var mod = new Mod( modPath );
        if( !mod.Reload( incorporateMetaChanges, out _ ) )
        {
            // Can not be base path not existing because that is checked before.
            Penumbra.Log.Warning( $"Mod at {modPath} without name is not supported." );
            return null;
        }

        return mod;
    }

    private bool Reload( bool incorporateMetaChanges, out ModDataChangeType modDataChange )
    {
        modDataChange = ModDataChangeType.Deletion;
        ModPath.Refresh();
        if( !ModPath.Exists )
        {
            return false;
        }

        modDataChange = LoadMeta();
        if( modDataChange.HasFlag( ModDataChangeType.Deletion ) || Name.Length == 0 )
        {
            return false;
        }

        LoadLocalData();

        LoadDefaultOption();
        LoadAllGroups();
        if( incorporateMetaChanges )
        {
            IncorporateAllMetaChanges( true );
        }

        ComputeChangedItems();
        SetCounts();
        return true;
    }

    // Convert all .meta and .rgsp files to their respective meta changes and add them to their options.
    // Deletes the source files if delete is true.
    private void IncorporateAllMetaChanges( bool delete )
    {
        var changes = false;
        foreach( var subMod in AllSubMods.OfType< SubMod >() )
        {
            changes |= subMod.IncorporateMetaChanges( ModPath, delete );
        }

        if( changes )
        {
            SaveAllGroups();
        }
    }
}