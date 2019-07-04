using System;

namespace CarBuilderExample
{
    class Car
    {
        // slozity objekt
    }

    // nas Stavitel, trida udavajici rozhrani pro vytvareni
    // komplexnich objektu
    abstract class CarSerializer
    {
        // metody pro vytvareni casti objektu
        public abstract void BuildHeader(Car car);
        public abstract void AddParams(Car car);
        public abstract void AddImages(Car car);

        // metoda pro navraceni vytvoreneho produktu
        public abstract string GetSerializedCar();
    }

    // konkretni stavitel pro format json
    class JsonCarSerializer : CarSerializer
    {
        private string jsonCar;

        public override void BuildHeader(Car car)
        {
            // zde se vytvori header pro json
            Console.WriteLine("Creating header for json");
        }

        public override void AddImages(Car car)
        {
            // zde se pridaji do produktu obrazky auta pro json
            Console.WriteLine("Adding images for json");
        }

        public override void AddParams(Car car)
        {
            // zde se pridaji do produktu parametry auta pro json
            Console.WriteLine("Adding parameters for json");
        }

        public override string GetSerializedCar()
        {
            // zde se v pripade potreby doladi finalizace json
            // a pote se vrati hotovy produkt json
            Console.WriteLine("Returning built json car");
            return jsonCar;
        }
    }

    // konkretni stavitel pro format xml
    class XmlCarSerializer : CarSerializer
    {
        private string xmlCar;

        public override void BuildHeader(Car car)
        {
            // zde se vytvori header pro xml
            Console.WriteLine("Creating header for xml");
        }

        public override void AddImages(Car car)
        {
            // zde se pridaji do produktu obrazky auta pro xml
            Console.WriteLine("Adding images for xml");
        }

        public override void AddParams(Car car)
        {
            // zde se pridaji do produktu parametry auta pro xml
            Console.WriteLine("Adding parameters for xml");
        }

        public override string GetSerializedCar()
        {
            // zde se v pripade potreby doladi finalizace xml
            // a pote se vrati hotovy produkt xml
            Console.WriteLine("Returning built xml car");
            return xmlCar;
        }
    }

    // nas direktor, objekt obsluhujici konstrukci objektu
    class Director
    {
        private CarSerializer carSerializer;

        public Director(CarSerializer carSerializer)
        {
            this.carSerializer = carSerializer;
        }

        // metoda pro serializaci auta se vsemi jeho castmi
        public string SerializeCar(Car car)
        {
            carSerializer.BuildHeader(car);
            carSerializer.AddImages(car);
            carSerializer.AddParams(car);

            return carSerializer.GetSerializedCar();
        }

        // metoda pro serializaci auta bez obrazku
        public string SerializeCarWithoutImages(Car car)
        {
            carSerializer.BuildHeader(car);
            carSerializer.AddParams(car);

            return carSerializer.GetSerializedCar();
        }

        // metoda pro serializace auta bez parametru
        public string SerializeCarWithoutParams(Car car)
        {
            carSerializer.BuildHeader(car);
            carSerializer.AddImages(car);

            return carSerializer.GetSerializedCar();
        }

        // mohli bychom mít spoustu dalsich metod upresnujicich presnou
        // konstrukci serializovaneho auta
    }

    class Program
    {
        static void Main(string[] args)
        {
            // nas klient nyni muze podle pozadavku vytvaret 
            // serializovana auta jak ve formatu json, tak ve
            // formatu xml -> staci k tomu pouze vyber konkretniho
            // stavitele (CarSerializer)

            Car car = new Car();
            CarSerializer carSerializer;
            Director director;

            // rekneme, ze chceme serializovat auto pro json
            carSerializer = new JsonCarSerializer();
            director = new Director(carSerializer);

            // nyni muzeme provest samotnou serializaci (napriklad bez obrazku)
            string serializedCar = director.SerializeCarWithoutImages(car);

            Console.ReadKey();
        }
    }
}
