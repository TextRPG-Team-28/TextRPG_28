using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_28
{
    public enum ItemType
    {
        Weapon,
        Amor,
        MonsterItem
    }

    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }
        public int Value { get; }
        public string Descrip { get; }
        public int Cost { get; }
        public bool IsPurchase { get; set; }
        public bool IsEquip { get; set; }

        public Item(string name, ItemType type, int value, string descrip, int cost)
        {
            Name = name;
            Type = type;
            Value = value;
            Descrip = descrip;
            Cost = cost;
            IsPurchase = false;
            IsEquip = false;
        }

        public string ItemDisplay()
        {
            string str = IsEquip ? "[E] " : "";
            str += $"{Name} | {GetTypeString()} | {Descrip}";
            return str;
        }

        public string GetTypeString()
        {
            string str = (Type == ItemType.Weapon ? $"공격력 +{Value}" : $"방어력 +{Value}");
            return str;
        }

        public string GetPriceString()
        {
            string str = IsPurchase ? "구매완료" : $"{Cost}";
            return str;
        }
        

    }  
    public class DungeonItem
    {
        public enum DungenItemType
        {
            monsteritem,
            Weapon,
            Amor
        }

        public string Name { get; }
        public ItemType Type { get; }
        public int Value { get; }
        public int Cost { get; } 
        public bool IsPurchase { get; set; }
        public bool IsEquip { get; set; }

        public DungeonItem(string name, ItemType type, int value, int cost)
        {
            Name = name;
            Type = type;
            Value = value;
            Cost = cost;
            IsPurchase = false;
            IsEquip = false;
        }
    }
    
}
