namespace MethodChainDesingPattern{

    public class Creature { 
        public string Name; 
        public int Attack, Defense; 

        public Creature(string name, int attack, int defense) { 
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Attack = attack; 
            Defense = defense;
        }

        public override string ToString() { 
            return $"{nameof(Name)}:{Name}, {nameof(Attack)}:{Attack}, {nameof(Defense)}:{Defense}";
        }

    }

    public class CreatureModifier 
    { 
        protected Creature creature; 
        protected CreatureModifier Next; 

        public CreatureModifier(Creature creature) {
            this.creature = creature ?? throw new ArgumentNullException(nameof(creature));
        }

        public void Add(CreatureModifier cm) { 
            if (Next != null) Next.Add(cm); 

            else Next = cm; 
        }

        public virtual void Handle() => Next?.Handle(); 
    }

    public class NoBonusesModifier: CreatureModifier { 
        public NoBonusesModifier(Creature creature) : base(creature) { 

        }

        public override void Handle()
        {
            System.Console.WriteLine("No bonuses for you!");
        }
    }

    public class DoubleAttackModifier : CreatureModifier { 
        public DoubleAttackModifier(Creature creature) : base(creature) { 

        }

        public override void Handle() 
        {
                System.Console.WriteLine($"Doubling {creature.Name}'s attack");
                creature.Attack *= 2; 
                base.Handle();
        }
    }

    public class IncreaseDefenseModifier: CreatureModifier { 
        public IncreaseDefenseModifier(Creature creature) : base(creature) { 

        }

        public override void Handle()
        {
                System.Console.WriteLine($"Increasing {creature.Name}'s defense");

                creature.Defense += 3; 
                base.Handle(); 
        }
    }

    public class Demo { 
        // static void Main(string[] args)
        // {
        //     var goblin = new Creature("Goblin", 2, 2); 
        //     System.Console.WriteLine(goblin);

        //     var root = new CreatureModifier(goblin); 

        //     root.Add(new NoBonusesModifier(goblin));

        //     System.Console.WriteLine("Let's double goblin's attach...");
        //     root.Add(new DoubleAttackModifier(goblin));

        //     System.Console.WriteLine("Let's increase goblin's defense");
        //     root.Add(new IncreaseDefenseModifier(goblin));

        //     root.Handle();
        //     System.Console.WriteLine(goblin);
        // }
    }
}