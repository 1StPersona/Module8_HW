using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8_HW
{
    /// <summary>
    /// Task1
    /// </summary>
    public class MyArray
    {
       public int[] Arr;
       public Random rnd = new Random();
        public MyArray(int size)//конструктор 
        {
            Arr = new int[size];
        }

        public int this[int index]//индексатор возвращающий квадрат элемента массива
        {
            get { return Arr[index]; }
            set { Arr[index] = value * value; }


        }
        public void Print()//функция вывода массива 
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = rnd.Next(10);
                Console.WriteLine(Arr[i]);
            }
        }
    }
    /// <summary>
    /// Task2
    /// </summary>
    public class Payment
    {
        public double[] rates=new double[4];//конструктор для тарифов
        public double[] privileage = {1.0,0.3,0.5};//конструктор для привилегий 1) нет ; 2) ветеран труда ; 3) ветеран войны;


        public double this[int index]
        {
            get { return rates[index]; }
            set { rates[index] = value; }
        }

        public double this[string privileageType]
        {
            get
            {
                if(privileageType=="Ветеран войны")
                {
                    return privileage[2];
                }
                else if(privileageType=="Ветеран труда")
                {
                    return privileage[1];
                }
                else
                {
                    return privileage[0];
                }
            }
        }

        public double CalculateHeatingCost(double area,string seassons)//Метод расчета стоимости отопления
        //по принципу площадь помещения * стоимость отопления(в учет идет сезон Х1,5 при зиме или осени) 
        {
            double heatingRate = rates[0];
            if (seassons == "Winter" || seassons == "Autumn")
            {
                heatingRate *=1.5 ;
            }
            return area*heatingRate;
        }
        public double CalculateWaterCost(int numberOfResident)//метод расчет стоимости воды по принципу кол-во жильцов*стоимость воды
        {
            double waterRate= rates[1];
            return waterRate*numberOfResident;
        }

        public double CalculateGasCost(int numberOfResident)//метод расчет стоимости воды по принципу кол-во жильцов*стоимость воды
        {
            double gasRate= rates[2];
            return gasRate*numberOfResident;
        }

        public double CalculateRepairCost(double area)
        {
            double repairRate= rates[3];
            return repairRate*area;
        }

        public double CalculateDiscount(double totalCost,string privileageType)
        {
            double discount = this[privileageType];
            return discount*totalCost;

        }
        public void Print(double area, int numberOfResidents, string season, string privileageType)
        {
            double heatingCost = CalculateHeatingCost(area, season);
            double waterCost = CalculateWaterCost(numberOfResidents);
            double gasCost = CalculateGasCost(numberOfResidents);
            double repairCost = CalculateRepairCost(area);

            double totalCost = heatingCost + waterCost + gasCost + repairCost;
            double discount = CalculateDiscount(totalCost, privileageType);

            Console.WriteLine("Вид платежа Начислено Льготная скидка Итого");
            Console.WriteLine($"Отопление {heatingCost}"); 
            Console.WriteLine($"Вода{waterCost}");
            Console.WriteLine($"Газ {gasCost}  {gasCost}");
            Console.WriteLine($"Текущий ремонт {repairCost} {repairCost}");
            Console.WriteLine($"Итого {totalCost}");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {       
                
                MyArray Ar = new MyArray(5);//экземпляр класса
                Ar.Print();//вывод массива 
                Ar[2] = 5;//присванивание элементу массива с индексом 2 значения 5
                Console.WriteLine(Ar[2]);//вывод элемента с индексом 2 умноженой в квадрат

            ////////////////////////////////////////////////////////////////////////////////////////
            Payment payment = new Payment();

            Console.WriteLine("Введите тариф на отопление (на 1 м2 площади):");
            payment[0] = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите тариф на воду (на 1 человека):");
            payment[1] = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите тариф на газ (на 1 человека):");
            payment[2] = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите тариф на текущий ремонт (на 1 м2 площади):");
            payment[3] = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите метраж помещения (м2):");
            double area = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество проживающих людей:");
            int numberOfResidents = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите сезон (Autumn or Winter/Spring or Summer):");
            string season = Console.ReadLine();

            Console.WriteLine("Есть ли льготы (ветеран труда/ветеран войны/нет):");
            string discountType = Console.ReadLine();

            payment.Print(area, numberOfResidents, season, discountType);


        }
    }
}
