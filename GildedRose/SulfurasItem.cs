namespace GildedRoseKata
{
    public class SulfurasItem : IUpdatableItem
    {
        private Item item;
        public SulfurasItem(Item item)
        {
            this.item = item;
        }
        public void Update()
        {
            return;
        }
    }
}
