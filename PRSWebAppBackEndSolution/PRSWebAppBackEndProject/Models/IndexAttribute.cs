using System;

namespace PRSWebAppBackEndProject.Models
{
    internal class IndexAttribute : Attribute
    {
        public bool IsUnique { get; set; }
    }
}