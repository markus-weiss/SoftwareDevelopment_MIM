using System;
using System.Collections.Generic;





public abstract class HierachyObjekt
{
    public string name;
    public abstract void AcceptVisitor(Visitor visitor);

}

public class Cube : HierachyObjekt
{
    public int length;

    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.Visit(this);
    }
}
public class Sphere : HierachyObjekt
{
    public int radius;

    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.Visit(this);
    }
}
public class Group : HierachyObjekt
{
    public List<HierachyObjekt> children;

    public void Traverse(Visitor visitor)
    {
        foreach (var child in children)
        {
            child.AcceptVisitor(visitor);
        }
    } 

    public override void AcceptVisitor(Visitor visitor)
    {
        visitor.Visit(this);
    }
}

public interface Visitor
{
    void Visit(Cube c);
    void Visit(Sphere s);
    void Visit(Group g);

}

public class Renderer : Visitor
{
    public void Visit(Cube c)
    {
        Console.WriteLine("This is a " + c.GetType() + c.name + "is Renderer");
    }

    public void Visit(Sphere s)
    {
        Console.WriteLine("This is a " + s.GetType() + s.name + "is Renderer");
    }

    public void Visit(Group g)
    {
        Console.WriteLine("This is a " + g.GetType() + g.name +  "is Renderer");
        g.Traverse(this);
    }
}





