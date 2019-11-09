using ConsoleApplication;
using GildedRoseCore.Console;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestAssemblyTests
    {
        private Program _program;

        public TestAssemblyTests()
        {
            _program = new Program();
        }

        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]
        public void AgedBrie_Should_Increase_In_Quality_While_Selln_Greater_Than_0()
        {
            var agedBrie = new Item()
            {
                Name = ItemNames.Brie,
                Quality = 40,
                SellIn = 10
            };
            var items = new List<Item>()
            {
                agedBrie
            };
            _program.UpdateQuality(items);
            Assert.Equal(41, items[0].Quality);
        }

        [Fact]
        public void AgedBrie_Should_Increase_In_Quality_By_Double_While_Selln_Less_Than_0()
        {
            var agedBrie = new Item()
            {
                Name = ItemNames.Brie,
                Quality = 40,
                SellIn = -1
            };
            var items = new List<Item>()
            {
                agedBrie
            };
            _program.UpdateQuality(items);
            Assert.Equal(42, items[0].Quality);
        }

        [Fact]
        public void Quality_Should_Never_Be_Negative()
        {
            var elixar = new Item()
            {
                Name = ItemNames.Elixar,
                Quality = 0,
                SellIn = 2
            };
            var items = new List<Item>()
            {
                elixar
            };
            _program.UpdateQuality(items);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void Backstage_Passes_Increases_In_Quality_By_1_When_SellIn_Greater_Than_10()
        {
            var backstage = new Item()
            {
                Name = ItemNames.BackstagePass,
                Quality = 40,
                SellIn = 11
            };
            var items = new List<Item>()
            {
                backstage
            };
            _program.UpdateQuality(items);
            Assert.Equal(41, items[0].Quality);
        }

        [Fact]
        public void Backstage_Passes_Increases_In_Quality_By_2_When_SellIn_Less_Than_10_And_Greater_Than_4()
        {
            var backstage = new Item()
            {
                Name = ItemNames.BackstagePass,
                Quality = 40,
                SellIn = 9
            };
            var items = new List<Item>()
            {
                backstage
            };
            _program.UpdateQuality(items);
            Assert.Equal(42, items[0].Quality);
        }

        [Fact]
        public void Backstage_Passes_Increases_In_Quality_By_2_When_SellIn_Less_Than_5()
        {
            var backstage = new Item()
            {
                Name = ItemNames.BackstagePass,
                Quality = 40,
                SellIn = 4
            };
            var items = new List<Item>()
            {
                backstage
            };
            _program.UpdateQuality(items);
            Assert.Equal(43, items[0].Quality);
        }

        [Fact]
        public void Backstage_Passes_Decrease_To_0_After_Concert()
        {
            var backstage = new Item()
            {
                Name = ItemNames.BackstagePass,
                Quality = 40,
                SellIn = -1
            };
            var items = new List<Item>()
            {
                backstage
            };
            _program.UpdateQuality(items);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void Standard_Product_Should_Decrease_Quality_By_1()
        {
            var elixar = new Item()
            {
                Name = ItemNames.Elixar,
                Quality = 40,
                SellIn = 10
            };
            var items = new List<Item>()
            {
                elixar
            };
            _program.UpdateQuality(items);
            Assert.Equal(39, items[0].Quality);
        }

        [Fact]
        public void Standard_Product_Should_Decrease_Quality_By_Double_After_SellIn()
        {
            var elixar = new Item()
            {
                Name = ItemNames.Elixar,
                Quality = 40,
                SellIn = -1
            };
            var items = new List<Item>()
            {
                elixar
            };
            _program.UpdateQuality(items);
            Assert.Equal(38, items[0].Quality);
        }

        [Fact]
        public void Quality_Should_Never_Be_More_Than_50()
        {
            var backstage = new Item()
            {
                Name = ItemNames.BackstagePass,
                Quality = 48,
                SellIn = 4
            };
            var items = new List<Item>()
            {
                backstage
            };
            _program.UpdateQuality(items);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void Sulfuras_Does_Not_Decrease_Or_Increase_In_Quality()
        {
            var sulfuras = new Item()
            {
                Name = ItemNames.Sulfuras,
                Quality = 40,
                SellIn = 11
            };
            var items = new List<Item>()
            {
                sulfuras
            };
            _program.UpdateQuality(items);
            Assert.Equal(40, items[0].Quality);
        }

        [Fact]
        public void Sulfuras_Does_Not_Decrease_In_SellIn()
        {
            var sulfuras = new Item()
            {
                Name = ItemNames.Sulfuras,
                Quality = 40,
                SellIn = 11
            };
            var items = new List<Item>()
            {
                sulfuras
            };
            _program.UpdateQuality(items);
            Assert.Equal(11, items[0].SellIn);
        }

        [Fact]
        public void Product_Other_Than_Sulfuras_Decreases_SellIn_By_1()
        {
            var elixar = new Item()
            {
                Name = ItemNames.Elixar,
                Quality = 40,
                SellIn = 10
            };
            var items = new List<Item>()
            {
                elixar
            };
            _program.UpdateQuality(items);
            Assert.Equal(9, items[0].SellIn);
        }
    }
}
