using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UsingReflection
{
    class TypeInfo
    {
        private Type type;

        public TypeInfo(object obj)
        {
            type = obj.GetType();
        }
        public TypeInfo(Type type)
        {
            this.type = type;
        }

        public Type GetType()
        {
            return type;
        }
        public void ShowType()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{type}:");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //print most of the information about our type
        public void ShowMostInformation()
        {
            if(type.GetMethods().Length != 0)
            {
                ShowMethods();
                Console.WriteLine();
            }
            if (type.GetConstructors().Length != 0)
            {
                ShowConstructors();
                Console.WriteLine();
            }
            if (type.GetFields().Length != 0)
            {
                ShowFialds();
                Console.WriteLine();
            }
            if (type.GetProperties().Length != 0)
            {
                ShowProperties();
                Console.WriteLine();
            }
            if (type.GetInterfaces().Length != 0)
            {
                ShowInterfaces();
                Console.WriteLine();
            }  
        }

        //list of methods, constructors, etc
        public MemberInfo[] GetMembers()
        {
            return type.GetMembers();
        }
        public void ShowMembers()
        {
            Console.WriteLine("Members:");
            foreach (MemberInfo mi in type.GetMembers())
            {
                Console.WriteLine(mi.MemberType + " " + mi.Name);
            }
        }

        //list of methods
        public MethodInfo[] GetMethods()
        {
            return type.GetMethods();
        }
        public void ShowMethods()
        {
            Console.WriteLine("Methods:");
            foreach (MethodInfo method in type.GetMethods())
            {
                Console.Write(method.ReturnType.Name + " " + method.Name + " (");

                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }

        //list of constructors
        public ConstructorInfo[] GetConstructors()
        {
            return type.GetConstructors();
        }
        public void ShowConstructors()
        {
            Console.WriteLine("Constructors:");
            foreach (ConstructorInfo ctor in type.GetConstructors())
            {
                Console.Write(type.Name + " (");

                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }

        //list of fields
        public FieldInfo[] GetFields()
        {
            return type.GetFields();
        }
        public void ShowFialds()
        {
            Console.WriteLine("Fields:");
            foreach (FieldInfo field in type.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }
        }

        //list of properties
        public PropertyInfo[] GetProperties()
        {
            return type.GetProperties();
        }
        public void ShowProperties()
        {
            Console.WriteLine("Properties:");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }
        }

        //list of implemented interfaces
        public Type[] GetInterfaces()
        {
            return type.GetInterfaces();
        }
        public void ShowInterfaces()
        {
            Console.WriteLine("Implemented interfaces:");
            foreach (Type i in type.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
        }
    }
}
