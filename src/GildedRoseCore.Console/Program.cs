using GildedRoseCore.Console;
using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        IList<Item> Items;

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                        {
                            new Item {Name = ItemNames.DexterityVest, SellIn = 10, Quality = 20},
                            new Item {Name = ItemNames.Brie, SellIn = 2, Quality = 0},
                            new Item {Name = ItemNames.Elixar, SellIn = 5, Quality = 7},
                            new Item {Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80},
                            new Item
                                {
                                    Name = ItemNames.BackstagePass,
                                    SellIn = 15,
                                    Quality = 20
                                },
                            new Item {Name = ItemNames.ManaCake, SellIn = 3, Quality = 6}
                        }

            };

            app.UpdateQuality(app.Items);

            Console.ReadKey();
        }

        public void UpdateQuality(IList<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name != ItemNames.Brie && items[i].Name != ItemNames.BackstagePass)
                {
                    if (items[i].Quality > 0)
                    {
                        if (items[i].Name != ItemNames.Sulfuras)
                        {
                            items[i].Quality = items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality = items[i].Quality + 1;

                        if (items[i].Name == ItemNames.BackstagePass)
                        {
                            if (items[i].SellIn < 11)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }

                            if (items[i].SellIn < 6)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].Name != ItemNames.Sulfuras)
                {
                    items[i].SellIn = items[i].SellIn - 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != ItemNames.Brie)
                    {
                        if (items[i].Name != ItemNames.BackstagePass)
                        {
                            if (items[i].Quality > 0)
                            {
                                if (items[i].Name != ItemNames.Sulfuras)
                                {
                                    items[i].Quality = items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            items[i].Quality = items[i].Quality - items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < 50)
                        {
                            items[i].Quality = items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
