namespace DyamicProxyDesignPattern {

    public interface IBankAccount{ 
        void Despoit(int amount); 
        bool Withraw(int amount); 
        string ToString();
    }

    public class BankAccount: IBankAccount { 
        private int balance; 
        private int overdraftLimit = -500; 

        public void Deposit(int amount) { 
            balance += amount; 
            System.Console.WriteLine($"Deposited ${amount}, balance is now {balance}");
        }

        public bool Withraw(int amount) { 
            if (balance - amount >= overfraftLimit) { 
                balance -= amount; 
                System.Console.WriteLine($"Withrew ${amount}, balance is now {balance}");
                return true; 
            }
            return false;
        }

        public override string ToString() { 
            return $"{nameof(balance)}: {balance}"; 
        }
    }

    public class Log<T>: DynamicObject where T : class, new() { 
        private readonly T subject; 
        private Dictionary<string, int> methodCallCount = new Dictionary<string, int>(); 

        protected Log(T subject) { 
            this.subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        public static I As<I>(T subject) where I: class 
        {
            if(!typeof(I).isInterface)) 
                throw new ArgumentException("I must be an interface type"); 

                return new Log<T>(subject).ActLike<I>(); 
        }

        public static I As<I>() where I : class
        { 
            if (!typeof(I).isInterface)
                throw new ArgumentException("I must be an interface type");
            
            return new Log<T>(new T()).ActLike<I>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) { 
            try{ 
                System.Console.WriteLine($"Invoking {subject.GetTYpe().Name}.{binder.Name} with arguments [{string.Join(", ", args)}].");

                if (methodCallCount.ContainsKey(binder.Name)) methodCallCount[binder.Name]++;
                else methodCallCount.Add(binder.Name, 1); 

                result = subject.GetType().GetMethod(binder.Name).Invoke(subject, args); 

                return true; 
            }
            catch{
                result = null; 
                return false; 
            }
        }

        public string Info {
            get { 
                var sb = new Stringbuilder(); 
                foreach (var kv in methodCallCount) 
                    sb.AppendLine($"{kv.Key} called {kv.Value} time(s)" ); 
                return sb.ToString();
            }
        }

        public override string ToString() { 
            return $"{Info}{subject}"
        }
    }

    public class Demo { 
        static void Main(string[] args)
        {
            var ba = Log<BankAccount>.As<IBankAccount>(); 

            ba.Deposit(100); 
            ba.Withraw(50); 

            System.Console.WriteLine(ba);
        }
    }
}