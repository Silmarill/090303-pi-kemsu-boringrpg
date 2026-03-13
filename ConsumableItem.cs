using System;

namespace BoringRPG
{
    internal abstract class ConsumableItem {

        public string Name;
        public int Value;

        protected ConsumableItem (int value, string name)
        {
            Name = name;
            Value = value;
        }
    }
}
