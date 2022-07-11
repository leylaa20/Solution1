namespace FactoryMethodTask;

public interface IShape
{
    void draw();
}

public class RoundedRectangle : IShape
{
    public void draw() => Console.WriteLine("RoundedRectangle draw");

}

public class RoundedSquare : IShape
{
    public void draw() => Console.WriteLine("RoundedSquare draw");

}

public class Rectangle : IShape
{
    public void draw() => Console.WriteLine("Rectangle draw");

}

public class Square : IShape
{
    public void draw() => Console.WriteLine("Square draw");

}

public abstract class AbstractFactory
{
    public abstract IShape getShape(string shapeType);
}


public class ShapeFactory : AbstractFactory
{
    public override IShape getShape(string shapeType)
    {
        if (shapeType == "Rectangle")
            return new Rectangle();

        else if (shapeType == "Square")
            return new Square();

        return null;
    }
}

public class RoundedShapeFactory : AbstractFactory
{
    public override IShape getShape(string shapeType)
    {
        if (shapeType == "Rectangle")
            return new RoundedRectangle();

        else if (shapeType == "Square")
            return new RoundedSquare();

        return null;
    }
}

public class FactoryProducer
{
    public static AbstractFactory getFactory(bool rounded)
    {
        if (rounded) return new RoundedShapeFactory();

        else return new ShapeFactory();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        AbstractFactory shapeFactory = FactoryProducer.getFactory(false);   
        
        IShape shape1 = shapeFactory.getShape("Rectangle");
        IShape shape2 = shapeFactory.getShape("Square");
        
        shape1.draw();               
        shape2.draw();
        
        AbstractFactory shapeFactory1 = FactoryProducer.getFactory(true);
        
        IShape shape3 = shapeFactory1.getShape("Rectangle");
        IShape shape4 = shapeFactory1.getShape("Square");
        
        shape3.draw();                 
        shape4.draw();
    }
}