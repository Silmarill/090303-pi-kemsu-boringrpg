namespace BoringRPG
{
    internal abstract class ConsumableItem
    {
        public int Value { get; set; }
        protected ConsumableItem(int value)
        {
            Value = value;
        }
    }
}