using System;

namespace CoreSchool.Entities
{
    public abstract class ObjectSchoolBase
    {
        public string UniqueId {get; private set;}
        public string Name {get; set;}
        public ObjectSchoolBase(){
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Name},  {UniqueId}";
        }
    }
}