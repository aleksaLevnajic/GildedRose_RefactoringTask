
using GildedRoseKata;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using VerifyXunit;

using Xunit;

namespace GildedRoseTests
{
    [UsesVerify]
    public class ApprovalTest
    {
        /*[Fact]
        public Task ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { "30" });
            var output = fakeoutput.ToString();

            return Verifier.Verify(output);
        }*/
        public static Item CreateItem(string name, int quality, int sellIn) 
            => new Item { Name = name, Quality  = quality, SellIn = sellIn };
        public static GildedRoseKata.GildedRose CreateGildedRose(Item item)
            => new GildedRoseKata.GildedRose(new List<Item> { item });

        [Fact]
        public void UpdateQuality_Should_ReduceSellInByOne()
        {
            var fooItem = CreateItem("Foo", 5, 5);
            var SUT = CreateGildedRose(fooItem); // SUT - system under test

            SUT.UpdateQuality();

            Assert.Equal(4, fooItem.SellIn);
        }
        [Fact]
        public void UpdateQuality_Should_ReduceQualityByOne()
        {
            var fooItem = CreateItem("Foo", 5, 5);
            var SUT = CreateGildedRose(fooItem); 

            SUT.UpdateQuality();

            Assert.Equal(4, fooItem.Quality);
        }
        [Fact]
        public void UpdateQuality_ShouldReduceQualityTwoTimesWhenSellInIsLowerThan0()
        {
            var zaeroSellInItem = CreateItem("Zero SellIn", 5, -1);
            var SUT = CreateGildedRose(zaeroSellInItem); 

            SUT.UpdateQuality();

            Assert.Equal(3, zaeroSellInItem.Quality);
        }

        [Fact]
        public void UpdateQuality_Should_ReturnZeroForQuality_WhenQualityIsAlreadyZero()
        {
            var zeroQualityItem = CreateItem("Zero Quality", 0, 5);
            var SUT = CreateGildedRose(zeroQualityItem);

            SUT.UpdateQuality();

            Assert.Equal(0, zeroQualityItem.Quality);
        }

        [Fact]
        public void UQ_Should_IncreaseQualityIFItemIsAgedBrie()
        {
            var agedBrieItem = CreateItem("Aged Brie", 1, 5);
            var SUT = CreateGildedRose(agedBrieItem);

            SUT.UpdateQuality();

            Assert.Equal(2, agedBrieItem.Quality);
        }
        [Fact]
        public void UQ_Should_Not_IncreaseQualityOver50()
        {
            var agedBrieItem = CreateItem("Aged Brie", 50, 5);
            var SUT = CreateGildedRose(agedBrieItem);

            SUT.UpdateQuality();

            Assert.Equal(50, agedBrieItem.Quality);
        }
        [Fact]
        public void UQ_Should_Not_DecreaseQualityOfSulfurasLegendaryItem()
        {
            var sulfurasItem = CreateItem("Sulfuras, Hand of Ragnaros", 5, 5);
            var SUT = CreateGildedRose(sulfurasItem); 
            
            SUT.UpdateQuality();

            Assert.Equal(5, sulfurasItem.Quality);
        }
        [Fact]
        public void UQ_Should_Not_DecreaseSellInOfSulfurasLegendaryItem()
        {
            var sulfurasItem = CreateItem("Sulfuras, Hand of Ragnaros", 5, 5);
            var SUT = CreateGildedRose(sulfurasItem);

            SUT.UpdateQuality();

            Assert.Equal(5, sulfurasItem.SellIn);
        }
        [Fact]
        public void UQ_Should_IncreaseBy1_IfSellInValueIsGreatherThan10()
        {
            var backstagePassesItem =
                CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 11);
            var SUT = CreateGildedRose(backstagePassesItem);

            SUT.UpdateQuality();

            Assert.Equal(6, backstagePassesItem.Quality);            
        }
        [Fact]
        public void UQ_Should_IncreaseBy2_IfSellInValueIsLessThan10_ButGreatherThan5()
        {
            var backstagePassesItem =
                CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 9);
            var SUT = CreateGildedRose(backstagePassesItem);

            SUT.UpdateQuality();

            Assert.Equal(7, backstagePassesItem.Quality);
        }
        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        public void UQ_Should_IncreaseBy3_IfSellInValueIsLessThan6_ButGreatherThan1(int sellIn)
        {
            var backstagePassesItem =
                CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, sellIn);
            var SUT = CreateGildedRose(backstagePassesItem);

            SUT.UpdateQuality();

            Assert.Equal(8, backstagePassesItem.Quality);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void UQ_Should_DecreaseTo0_IfSellInValueIsLessOrEqualTo0(int sellIn)
        {
            var backstagePassesItem =
                CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, sellIn);
            var SUT = CreateGildedRose(backstagePassesItem);

            SUT.UpdateQuality();

            Assert.Equal(0, backstagePassesItem.Quality);
        }
        [Fact]
        public void UQ_Sholud_Not_AlterSulfurasItemValue_AndKeepItOn80()
        {
            var sulfurasItem = CreateItem("Sulfuras, Hand of Ragnaros", 80, 10);
            var SUT = CreateGildedRose(sulfurasItem);

            SUT.UpdateQuality();

            Assert.Equal(80, sulfurasItem.Quality);
        }
    }
}
