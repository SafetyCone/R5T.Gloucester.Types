using System;
using System.Collections.Generic;

using R5T.Ostersund;


namespace R5T.Gloucester.Types
{
    public class ProjectFile
    {
        public TargetFramework TargetFramework { get; set; }

        // Provide instance to make sure we don't have a null references.
        public Settable<bool> GenerateDocumentationFile { get; set; } = new Settable<bool>();
        public Settable<bool> IsPackable { get; set; } = new Settable<bool>();
        public Settable<Version> LanguageVersion { get; set; } = new Settable<Version>();
        public Settable<List<int>> NoWarn { get; set; } = new Settable<List<int>>();
        public Settable<OutputType> OutputType { get; set; } = new Settable<OutputType>();

        public List<ProjectReference> ProjectReferences { get; } = new List<ProjectReference>();
        public List<PackageReference> PackageReferences { get; } = new List<PackageReference>();
    }
}
