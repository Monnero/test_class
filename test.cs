using System;

namespace tese
{
    abstract class Car
    {
        public string Type { get; set; } //тип автомобиля
        public double FuelTank { get; set; } // объем топлива в баке
        public double FuelConsumption { get; set; } // средний расход топлива на 100 км
        public double Speed { get; set; } // скорость


        public virtual double DriveTime(double FuelTank, double FuelConsumption) // как долго может ехать на заданном кол-ве топлива
        {
            double distance = DriveDistance(FuelTank, FuelConsumption);
            this.FuelTank = FuelTank;
            return distance / Speed;
        }
        public virtual double DriveDistance(double FuelTank, double FuelConsumption, int Baggage = 0) // какое расстояние может проехать на заданном кол-ве топлива с заданным кол-вом пассажиров и кг багажа
        {
            this.FuelConsumption = FuelConsumption;
            return FuelTank / FuelConsumption * 100;
        }
        public virtual double Time(double FuelTank, double Distance) //за сколько доедет
        {
            this.FuelTank = FuelTank;

            if (DriveDistance(FuelTank, FuelConsumption) >= Distance)
                return Distance / Speed;
            else
            {
                return 0;
            }
        }
    }

    class PassengerCar : Car
    {
        public PassengerCar() => Type = "Пассажирский";
        int Passengers { get; set; }

        public override double DriveDistance(double FuelTank, double FuelConsumption, int Passengers)
        {
            this.Passengers = Passengers;
            double percent = Passengers * 6;
            if (Passengers <= 4)
                 
            return this.FuelConsumption = (FuelTank / FuelConsumption * 100) * (100 - percent) / 100;
            else
            {
                Console.WriteLine("Некорректное колическо пассажиров, введите корректное");
                this.Passengers = Convert.ToInt32(Console.ReadLine());
                return DriveDistance(FuelTank, FuelConsumption, this.Passengers);

            }
        }
    }
    class Truck : Car
    {
        public Truck() => Type = "Грузовой";

        int Tonnage = 1000;
        public override double DriveDistance(double FuelTank, double FuelConsumption, int Baggage = 0)
        {
            double percent = Math.Ceiling(Convert.ToDouble(Baggage) / 200) * 4;
            if (Baggage <= Tonnage)

                return this.FuelConsumption = (FuelTank / FuelConsumption * 100) * (100 - percent) / 100;
            else
            {
                Console.WriteLine("Некорректное колическо груза, введите корректное");
                Baggage = Convert.ToInt32(Console.ReadLine());
                return DriveDistance(FuelTank, FuelConsumption, Baggage);

            }
        }
    }

    class Program
    {
        static void Main()
        {
            PassengerCar passengerCar = new PassengerCar();
            double passengerCarDistance = passengerCar.DriveDistance(10.6, 8, 1);
            Console.WriteLine(passengerCarDistance);
            passengerCar.Speed = 60;
            Console.WriteLine($"на заданном количестве топлива может ехать {passengerCar.DriveTime(10.6, 8)} часов ");
            int distance = 5;
            Console.WriteLine($"на {passengerCar.FuelTank} топлива автомобиль проедет дистанцию {distance} за {passengerCar.Time(10.6, distance)} часов");

            Truck truck = new Truck();
            Console.WriteLine(truck.DriveDistance(10.6, 8 , 479));
            Console.ReadLine();

        }
    }
}
