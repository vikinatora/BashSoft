using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class AliasAttribute:Attribute
    {
        private string name;

        public string Name
        {
            get { return name; }
        }

        public AliasAttribute(string aliasName)
        {
            this.name = aliasName;
        }

        public override bool Equals(object obj)
        {
            return this.name.Equals(obj);
        }
    }
}
