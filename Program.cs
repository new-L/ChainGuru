using System;
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.ChainOfResponsibility.Conceptual
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(object request);
    }
    #region Обработчик
    abstract class Component : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
    #endregion

    #region Конкретные обработчикт
    class Button : Component
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Button")
            {
                return $"This is a {request}\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class Dialog : Component
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Dialog")
            {
                return $"This is a {request}\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class Panel : Component
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Panel")
            {
                return $"This is a {request}\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
    #endregion
    class Application
    {
        public static void ApplicationCode(Component handler)
        {
            foreach (var component in new List<string> { "Panel", "Dialog", "Button", "Label" })
            {
                Console.Write($"Did I choose {component}? ");

                var result = handler.Handle(component);

                if (result != null)
                {
                    Console.Write($"    Yes, {result} enters this chain");
                }
                else
                {
                    Console.WriteLine($"    No");
                }

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var button = new Button();
            var dialog = new Dialog();
            var panel = new Panel();

            panel.SetNext(dialog).SetNext(button);

            Console.WriteLine("Цепочка, когда выбрали диалоговое окно: Panel > Dialog > Button\n");
            Application.ApplicationCode(dialog);
            Console.WriteLine();

            Console.WriteLine("Цепочка, когда выбрали кнопку: Dialog > Button\n");
            Application.ApplicationCode(button);

            Console.ReadKey();
        }
    }
}