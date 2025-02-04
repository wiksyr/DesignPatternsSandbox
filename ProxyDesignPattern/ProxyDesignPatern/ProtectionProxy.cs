namespace ProtectionProxyDesignPattern
{
    public interface ICar { 
        void Drive(); 
    }

    public class Car : ICar
    {
        public void Drive() {
            System.Console.WriteLine("car being driven");
        }
    }

    public class CarProxy: ICar
    {
        private Car car = new Car(); 
        private Driver driver; 

        public CarProxy(Driver driver) 
        { 
            this.driver = driver; 
        }

        public void Drive() 
        { 
            if(driver.Age >= 16) {car.Drive() ;} 
            else { System.Console.WriteLine("Driver too young"); }
        }
    }

    public class Driver 
    { 
        public int Age {get ; set; }

        public Driver(int age) { 
            Age = age; 
        }
    }

    public class Demo { 
        static void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver(12)); 
            car.Drive(); 
        }
    }
}