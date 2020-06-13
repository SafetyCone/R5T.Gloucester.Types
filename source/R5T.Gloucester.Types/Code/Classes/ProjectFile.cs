using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0002;
using R5T.T0003;

using R5T.Ostersund;


namespace R5T.Gloucester.Types
{
    public class ProjectFile : IVisualStudioProjectFile
    {
        // Provide Settable<T> instances to make sure we don't have a null references.
        public Settable<string> SDK { get; set; } = new Settable<string>();

        public Settable<bool> GenerateDocumentationFile { get; set; } = new Settable<bool>();
        public Settable<bool> IsPackable { get; set; } = new Settable<bool>();
        public Settable<Version> LanguageVersion { get; set; } = new Settable<Version>();
        public Settable<List<int>> NoWarn { get; set; } = new Settable<List<int>>();
        public Settable<OutputType> OutputType { get; set; } = new Settable<OutputType>();
        public Settable<TargetFramework> TargetFramework { get; set; } = new Settable<TargetFramework>();

        public List<IPackageReference> PackageReferences { get; } = new List<IPackageReference>();
        IEnumerable<IPackageReference> IVisualStudioProjectFile.PackageReferences => this.PackageReferences;

        public List<IProjectReference> ProjectReferences { get; } = new List<IProjectReference>();
        IEnumerable<IProjectReference> IVisualStudioProjectFile.ProjectReferences => this.ProjectReferences;


        public void AddPackageReference(IPackageReference packageReference)
        {
            this.PackageReferences.Add(packageReference);
        }

        public bool RemovePackageReference(IPackageReference packageReference)
        {
            var removed = this.PackageReferences.Remove(packageReference);
            return removed;
        }

        public bool RemoveProjectReference(IProjectReference projectReference)
        {
            var removed = this.ProjectReferences.Remove(projectReference);
            return removed;
        }

        public IProjectReference AddProjectReference(string projectFilePath)
        {
            var hasProjectReference = this.HasProjectReference(projectFilePath);
            if(hasProjectReference)
            {
                throw new InvalidOperationException($"Project file already has project reference:\n{projectFilePath}");
            }

            var projectReference = new ProjectReference(projectFilePath);

            this.ProjectReferences.Add(projectReference);

            return projectReference;
        }

        public IPackageReference AddPackageReference(string name, string versionString)
        {
            var hasPackageReference = this.HasPackageReference(name, versionString);
            if(hasPackageReference)
            {
                throw new InvalidOperationException($"Project file already has package reference:\nName: {name}, Version: {versionString}");
            }

            var packageReference = new PackageReference(name, versionString);

            this.PackageReferences.Add(packageReference);

            return packageReference;
        }

        public bool HasProjectReference(string projectFilePath, out IProjectReference projectReference)
        {
            projectReference = this.ProjectReferences.Where(x => x.ProjectFilePath == projectFilePath).SingleOrDefault();

            var hasProjectReference = projectReference == default;
            return hasProjectReference;
        }

        public bool HasPackageReference(string name, string versionString, out IPackageReference packageReference)
        {
            packageReference = this.PackageReferences.Where(x => x.Name == name && x.VersionString == versionString).SingleOrDefault();

            var hasPackageReference = packageReference == default;
            return hasPackageReference;
        }
    }
}
