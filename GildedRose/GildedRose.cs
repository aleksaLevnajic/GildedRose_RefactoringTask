using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }       

        public void UpdateQuality()
        {
            foreach(var item in _items) 
            {
                CreateUpdatableItem(item).Update();
            }
        }
        public IUpdatableItem CreateUpdatableItem(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgedBrieItem(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassesItem(item),
                "Sulfuras, Hand of Ragnaros" => new SulfurasItem(item),
                _ => new NormalItem(item)
            };
        }
    }
    


}
