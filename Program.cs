
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Визначити структуру Напій з полями
    назва напою,
    тип напою(власного перелічувального типу)
    виробник
    кількість ккал
    ціна

Створити необхідні конструктори
Перевизначити метод ToString()
Реалізувати інтерфейс  IComparable(як метод класу int CompareTo(object)) : порівнювати напої за типом, потім за назвою
Реалізувати інтерфейс  IComparable<>(як метод класу int CompareTo(Drink)) : порівнювати за назвою напою

Визначити 3 класи компараторів(реалізують інтерфейс ICompare: тобто int Compare(object, object)) для
  порівняння за ціною(за зростання)
    порівняння за ккал(спадання)
    порівняння за  виробником(зростання)
* Реалізувати інтерфейс IEquatable<>
 

 Перевірити роботу структури.
 Підготувати 2 колекції
     ArrayList
 
     List<Drink>
 Перевірити роботу реалізованих інтерфейсів за допомогою сортування колекцій, IndexOf()*/

namespace drink
{
    enum TypeDrink { HotDrink, ColdDrink };

    struct CmpPrice : IComparer<Drink>
    {
        public int Compare(Drink x, Drink y)
        {
            return x.Price.CompareTo(y.Price);
        }


    }
    struct CmpQuanCcal : IComparer<Drink>
    {
        public int Compare(Drink x, Drink y)
        {
            return x.QuanCcal.CompareTo(y.QuanCcal);
        }


    }
    struct CmpProducer : IComparer<Drink>
    {
        public int Compare(Drink x, Drink y)
        {
            return x.Producer.CompareTo(y.Producer);
        }


    }


    struct Drink : IComparable, IComparable<Drink>, IEquatable<Drink>
    {


        public TypeDrink typeDrink { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
        public uint QuanCcal { get; set; }
        public string Producer { get; set; }
        public int CompareTo(object obj)
        {
            if (!(obj is Drink))
            {
                throw new Exception("obj not drink");

            }
            Drink d = (Drink)obj;

            if (d.typeDrink == this.typeDrink) { return this.Name.CompareTo(d.Name); }
            return this.typeDrink.CompareTo(d.typeDrink);



        }

        public int CompareTo(Drink other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(Drink other)
        {
            if (this.Name == other.Name)
                return true;
            else
                return false;

        }

        public override string ToString()
        {
            return $"name {Name} : type {typeDrink} : price {Price} : quan ccal : {QuanCcal} : producer : {Producer}";
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Drink> DrinkList = new List<Drink>()
            {
                 new Drink(){Name="cola",typeDrink=TypeDrink.ColdDrink,Price=100},
                 new Drink(){Name="Tea",typeDrink=TypeDrink.HotDrink,Price=5},
                 new Drink(){Name="Coffe",typeDrink=TypeDrink.HotDrink,Price=1},
                 new Drink(){Name="juice",typeDrink=TypeDrink.ColdDrink,Price=10 }
            };

            // DrinkList.Sort();
            DrinkList.Sort(new CmpPrice());
            foreach (var i in DrinkList)
            {
                Console.WriteLine(i);
            }





        }
    }
}