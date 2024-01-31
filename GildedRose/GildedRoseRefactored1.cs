using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class GildedRoseRefactored1
    {
        IList<Item> Items;
        public GildedRoseRefactored1(IList<Item> Items)
        {
            this.Items = Items;
        }

        //REFACTORING WITHOUT WRITING APPROVAL TESTS
        public void QualityOfSulfurasItem(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                item.Quality = item.Quality;
            }
        }
        public bool IsQualityValueValid(Item item)
        {
            if (item.Quality < 0 || item.Quality > 50)
                return false;
            return true;
        }
        public void AgedBrieItemQuality(Item item)
        {
            if (IsQualityValueValid(item))
            {
                item.Quality += 1;
            }
        }
        public void BackstagePassesItemQuality(Item item)
        {
            if (IsQualityValueValid(item))
            {
                if (item.SellIn >= 11)
                    item.Quality += 1;
                if (item.SellIn > 5 && item.SellIn <= 10)
                    item.Quality += 2;
                if (item.SellIn >= 0 && item.SellIn <= 5)
                    item.Quality += 3;
                if (item.SellIn <= 0)
                    item.Quality = 0;
            }
        }
        public void QualityCheck(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                if (item.Quality > 50)
                    item.Quality = 50;
                if (item.Quality < 0)
                    item.Quality = 0;
            }
        }
        public void ConjuredItemQuality(Item item)
        {
            if (IsQualityValueValid(item))
                item.Quality -= 2;
        }
        public void OtherItemsQuality(Item item)
        {
            if (IsQualityValueValid(item))
                item.Quality -= 1;
        }
        public void CalculateQuality(Item item)
        {
            switch (item.Name)
            {
                case "Backstage passes to a TAFKAL80ETC concert":
                    BackstagePassesItemQuality(item); break;
                case "Aged Brie":
                    AgedBrieItemQuality(item); break;
                case "Conjured Mana Cake":
                    ConjuredItemQuality(item); break;
                case "Sulfuras, Hand of Ragnaros":
                    QualityOfSulfurasItem(item); break;
                default: OtherItemsQuality(item); break;
            }
        }
        //The update method
        public void UpdateQualityRefactored()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                CalculateQuality(Items[i]);
                if (Items[i].SellIn <= 0)
                {
                    CalculateQuality(Items[i]);
                }

                QualityCheck(Items[i]);
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }
            }
        }
    }
}
