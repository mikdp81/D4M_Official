using System;

namespace BaseProvider
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SectionNameAttribute : Attribute
    {
        public string SectionName { get; private set; }

        public SectionNameAttribute(string sectionName)
        {
            this.SectionName = sectionName;
        }
    }
}
