namespace DynamicDecoratorCompositionDesignPattern
{
    public abstract class Shape {
        public virtual string AsString() => string.Empty;
    }

    public class Circle : Shape 
    {
        private float radius; 

        public Circle() : this(0) {

        }

        public Circle(float radius) {
            this.radius = radius;
        }

        public void Resize(float factor) {
            radius *= factor; 
        }

        public override string AsString()
        {
            return $"A circle with radius {radius}"; 
        }
    }

    public class Square : Shape 
    {
        private float side; 

        public Square() : this (0) {}

        public Square(float side) {
            this.side = side;
        }

        public override string AsString()
        {
            return $"A square with side {side}";
        }
    }

    public class ColoredShape : Shape
    {
        private Shape shape; 
        private string color; 

        public ColoredShape(Shape shape, string color) {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
            this.color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class TransparentShape : Shape 
    {
        private Shape shape; 
        private float transparency; 

        public TransparentShape(Shape shape, float transparency) { 
            this.shape = shape ?? throw new ArgumentNullException(nameof (shape));
            this.transparency = transparency;
        }

        public override string AsString() {
            return $"{shape.AsString()} has {transparency * 100.0f}% transparency";
        }
    }

    public class ColoredShape<T> : Shape where T : Shape, new() {
        private string color; 
        private T shape = new T(); 

        public ColoredShape() : this("black") { }

        public ColoredShape(string color) {
            this.color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        private float transparency; 
        private T shape = new T(); 

        public TransparentShape(float transparency) {
            this.transparency = transparency;
        }

        public override string AsString() {
            return $"{shape.AsString()} has transparency {transparency * 100.0f}%";
        }
    }

    public class Demo 
    {
        // static void Main(string[] args)
        // {
        //     var square = new Square(1.23f); 
        //     System.Console.WriteLine(square.AsString());

        //     var redSquare = new ColoredShape(square, "red"); 
        //     System.Console.WriteLine(redSquare.AsString());

        //     var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f); 
        //     System.Console.WriteLine(redHalfTransparentSquare.AsString());

        //     ColoredShape<Circle> blueCircle = new ColoredShape<Circle>("blue"); 
        //     System.Console.WriteLine(blueCircle.AsString());

        //     TransparentShape<ColoredShape<Square>> blackHalfSquare = new TransparentShape<ColoredShape<Square>>(0.4f); 
        //     System.Console.WriteLine(blackHalfSquare.AsString());
        // }
    }


}