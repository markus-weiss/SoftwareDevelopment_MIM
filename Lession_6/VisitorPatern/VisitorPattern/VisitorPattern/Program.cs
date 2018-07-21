using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace VisitorPattern
{

    /// <summary>
    ///  Traversiren mit Visitor Pattern
    /// </summary>

    public class Visitor 
    {
        void Visit(Sphere s);
        void Visit(Cuboid c);
        void Visit(Group g);

        delegate void VisiteMethod(GraphicsOb go);

        Dictionary<Type,VisiteMethod> _visitors;

        public Visitor()
        {
            _visitors = new Dictionary<Type, VisiteMethod>();

            Type visitorType = GetType();
            MethodInfo[] methods =  visitorType.GetMethods();
            foreach(var method in methods)
            {
                if (method.Name.StartsWith("Visit"))
                {
                    ParameterInfo[] parameters = method.GetParameters();
                    if(parameters.Length == 1)
                    {
                        if (typeof(GraphicsOb).IsAssignableFrom(parameters[0].ParameterType))
                        {

                        }
                    }
                }
            }
        }

        public void TraversChildren(Group g)
        {
            if (g == null)
            {
                Console.WriteLine("is null");
                return;
            }

            foreach (var child in g.children)
            {
                /// VisitorPattern 
                VisiteMethod visitor;
                if(_visitors.TryGetValue(child.GetType(), out visitor))
                {
                    visitor(child);
                }
            }
        }
    }
        

    public class Renderer : Visitor
    {
        public void Visit(Sphere s)
        {
            // $ Interpolierter String "bla{var}"
            Console.WriteLine($"Hey Im the Sphere, my radius is: {s.radius}. My Name is: {s.name}.");
        }

        public void Visit(Cuboid c)
        {
            // Standart feature {0}, name
            Console.WriteLine("Hey Im the Cuboid, name: {0}, lenght: {1}, heigth: {2}, size: {3}.", c.name, c.length, c.height, c.size);
        }

        public void Visit(Group g)
        {
            Console.WriteLine($"Hey Im the Group named {g.name}.");
            //g.TraversChildren(GraphicsOb Go));         
        }
    }

    public class Group : GraphicsOb
    {
        public List<GraphicsOb> children;
    }

    public abstract class GraphicsOb
    {
        public string name;
    }

    public class Sphere : GraphicsOb
    {
        public int radius;
    }

    public class Cuboid : GraphicsOb
    {
        public float length;
        public float height;
        public float size;
    }

    class JsonExporter
    {
        public void Visit(Sphere s)
        {
            throw new NotImplementedException();
        }

        public void Visit(Cuboid c)
        {
            throw new NotImplementedException();
        }

        public void Visit(Group g)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Struktureninitialisuerung für Bäume
            // Klassische schreibweise
            /*
            Group parentGroup = new Group();
            parentGroup.children = new List<GraphicsOb>();
            parentGroup.name = "Parent Group";
            
            Group childGroup = new Group();
            childGroup.children = new List<GraphicsOb>();
            childGroup.name = "Child Group";
            
            Sphere sphere = new Sphere();
            sphere.radius = 3;
            sphere.name = "sphere Object";
            
            parentGroup.children.Add(childGroup);
            childGroup.children.Add(sphere);
            */

            //////////////////////////////////////////////////////////////////////
            // Bessere Schreibweise

            GraphicsOb scene = new Group
            {
                name = "the ParentGroupBetter",
            
                children = new List<GraphicsOb>()
                {
                    new Group
                    {
                        name = "theChildGroup",

                        children = new List<GraphicsOb>
                        {
                            new Sphere { name = "Sphere Better 1", radius = 1, },
                            new Cuboid { name = "Cuboid Better 1", height = 1, length = 1, size = 1, },
                        },
                    },
                    new Group
                    {
                        name = "theChildGroup2",
                        children = new List<GraphicsOb>
                        {
                            new Sphere { name = "NewSphere2", radius = 2, },
                        }
                    },

                    new Cuboid { name = "Cuboid Better 2", height = 1, length = 1, size = 1, },
                },
            };

            ///Traversieren auslösen
            //Renderer renderer = new Renderer();
            //scene.Accept(renderer);


            Console.ReadLine();
        }
    }
}
