using DecoratorDesignPattern;

namespace DecoratorDesignPattern {

    public class Bird {
        public void Fly() {
            System.Console.WriteLine("flying in the sky");
        }
    }

    public class Lizard {

        public void Crawl() {
            System.Console.WriteLine("crawling on the ground");
        }
    }

    public class Dragon 
    {
        private Bird bird = new Bird(); 
        private Lizard lizard = new Lizard(); 

        public Dragon()
        {
            
        }

        public Dragon(Bird bird, Lizard lizard) {
            this.bird = bird ?? throw new ArgumentNullException(nameof(bird));
            this.lizard = lizard ?? throw new ArgumentNullException(nameof(lizard));
        }

        public void Crawl() {
            lizard.Crawl(); 
        }
        public void Fly() {
            bird.Fly(); 
        }
    }

    public class Program {
        // public static void Main(string[] args)
        // {
        //     var d = new Dragon(); 
        //     d.Crawl(); 
        //     d.Fly(); 
        // }
    }

}
