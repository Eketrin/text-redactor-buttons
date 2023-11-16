using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_redactor_buttons
{ /*
    public interface ICommand
    {
        void Execute();
    }

    class CommandBase: ICommand
    {
        public void Execute()
        {
            Console.WriteLine($"Запись сохранена");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            PowerfulBotton powBott = new PowerfulBotton();
            File file = new File();
            powBott.SetCommand(new ButtonOnCommand(file));
            powBott.PressButton();
            powBott.PressUndo();

            Console.Read();
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver - Получатель
    class File
    {
        public void Save()
        {
            Console.WriteLine("Что-то сохранилось");
        }

        public void NoSave()
        {
            Console.WriteLine("Сохранение отменено");
        }
    }

    class CutMe
    {
        public void Cut()
        {
            Console.WriteLine("Вы вырезали что-то");
        }

        public void NoSave()
        {
            Console.WriteLine("Вырезание отменено");
        }
    }
    class ButtonOnCommand : ICommand
    {
        File fi;
        CutMe fi1;
        public ButtonOnCommand(File file)
        {
            this.fi = file;
        }
        public ButtonOnCommand(CutMe file)
        {
            this.fi1 = file;
        }

        public void Execute()
        {
            fi.Save();
        }
        public void Undo()
        {
            fi.NoSave();
        }
    }

    // Invoker - инициатор
    class PowerfulBotton
    {
        ICommand command;

        public PowerfulBotton() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }
}
