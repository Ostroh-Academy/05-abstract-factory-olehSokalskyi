namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }

    public interface IMaterial
    {
        string UseMaterial { get; set; }
    }

    public class ConcreteMaterialMetal : IMaterial
    {
        public string UseMaterial { get; set; } = "Metal";
    }

    public class ConcreteMaterialWood : IMaterial
    {
        public string UseMaterial { get; set; } = "Wood";
    }

    public interface IProductType
    {
        string UseProducType { get; set; }
        IMaterial Collaborator { get; set; }
    }

    public class ConcreteProductClassic : IProductType
    {
        public string UseProducType { get; set; } = "Classic";
        public IMaterial Collaborator { get; set; }

        public override string ToString()
        {
            var result = Collaborator.UseMaterial;
            return $"The {UseProducType} product is made of {result}";
        }
    }

    public class ConcreteProductModern : IProductType
    {
        public string UseProducType { get; set; } = "Modern";
        public IMaterial Collaborator { get; set; }

        public override string ToString()
        {
            var result = Collaborator.UseMaterial;
            return $"The {UseProducType} product is made of {result}";
        }
    }

    public class ConcreteProductIndustrial : IProductType
    {
        public string UseProducType { get; set; } = "Industrial";
        public IMaterial Collaborator { get; set; }

        public override string ToString()
        {
            var result = Collaborator.UseMaterial;
            return $"The {UseProducType} product is made of {result}";
        }
    }

    public interface IProductFactory
    {
        IMaterial CreateMaterial();
        IProductType CreateProductType();
    }

    public class ConcreteFactoryClassic : IProductFactory
    {
        public IMaterial CreateMaterial()
        {
            return new ConcreteMaterialWood();
        }

        public IProductType CreateProductType()
        {
            var product = new ConcreteProductClassic();
            product.Collaborator = CreateMaterial();
            return product;
        }
    }

    public class ConcreteFactoryModern : IProductFactory
    {
        public IMaterial CreateMaterial()
        {
            return new ConcreteMaterialMetal();
        }

        public IProductType CreateProductType()
        {
            var product = new ConcreteProductModern();
            product.Collaborator = CreateMaterial();
            return product;
        }
    }

    public class ConcreteFactoryIndustrial : IProductFactory
    {
        public IMaterial CreateMaterial()
        {
            return new ConcreteMaterialMetal();
        }

        public IProductType CreateProductType()
        {
            var product = new ConcreteProductIndustrial();
            product.Collaborator = CreateMaterial();
            return product;
        }
    }

    public class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new ConcreteFactoryClassic());
            Console.WriteLine();

            Console.WriteLine("Client: Testing client code with the second factory type...");
            ClientMethod(new ConcreteFactoryModern());
            Console.WriteLine();

            Console.WriteLine("Client: Testing client code with the third factory type...");
            ClientMethod(new ConcreteFactoryIndustrial());
        }

        public void ClientMethod(IProductFactory factory)
        {
            var product = factory.CreateProductType();
            Console.WriteLine(product);
        }
    }
}
