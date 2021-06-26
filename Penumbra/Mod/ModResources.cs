using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Penumbra.Meta;

namespace Penumbra.Mod
{
    [Flags]
    public enum ResourceChange
    {
        Files = 1,
        Meta  = 2,
    }

    // Contains static mod data that should only change on filesystem changes.
    public class ModResources
    {
        public List< FileInfo > ModFiles { get; private set; } = new();
        public List< FileInfo > MetaFiles { get; private set; } = new();

        public MetaCollection MetaManipulations { get; private set; } = new();


        private void ForceManipulationsUpdate( ModMeta meta, DirectoryInfo basePath )
        {
            MetaManipulations.Update( MetaFiles, basePath, meta );
            MetaManipulations.SaveToFile( MetaCollection.FileName( basePath ) );
        }

        public void SetManipulations( ModMeta meta, DirectoryInfo basePath )
        {
            var newManipulations = MetaCollection.LoadFromFile( MetaCollection.FileName( basePath ) );
            if( newManipulations == null )
            {
                ForceManipulationsUpdate( meta, basePath );
            }
            else
            {
                MetaManipulations = newManipulations;
                if( !MetaManipulations.Validate( meta ) )
                {
                    ForceManipulationsUpdate( meta, basePath );
                }
            }
        }


        // Update the current set of files used by the mod,
        // returns true if anything changed.
        public ResourceChange RefreshModFiles( DirectoryInfo basePath )
        {
            List< FileInfo > tmpFiles = new( ModFiles.Count );
            List< FileInfo > tmpMetas = new( MetaFiles.Count );
            // we don't care about any _files_ in the root dir, but any folders should be a game folder/file combo
            foreach( var file in basePath.EnumerateDirectories()
               .SelectMany( dir => dir.EnumerateFiles( "*.*", SearchOption.AllDirectories ) )
               .OrderBy( f => f.FullName ) )
            {
                if( file.Extension != ".meta" )
                {
                    tmpFiles.Add( file );
                }
                else
                {
                    tmpMetas.Add( file );
                }
            }

            ResourceChange changes = 0;
            if( !tmpFiles.SequenceEqual( ModFiles ) )
            {
                ModFiles =  tmpFiles;
                changes  |= ResourceChange.Files;
            }

            if( !tmpMetas.SequenceEqual( MetaFiles ) )
            {
                MetaFiles =  tmpMetas;
                changes   |= ResourceChange.Meta;
            }

            return changes;
        }
    }
}