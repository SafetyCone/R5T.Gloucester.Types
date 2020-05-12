using System;


namespace R5T.Gloucester.Types
{
    public class ProjectReference
    {
        public string ProjectFilePath { get; set; }


        public ProjectReference()
        {
        }

        public ProjectReference(string projectFilePath)
        {
            this.ProjectFilePath = projectFilePath;
        }
    }
}
