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
            SaveMe saveMe = new SaveMe();
            powBott.SetCommand(new ButtonOnCommand(saveMe));
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
    class SaveMe
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
        SaveMe file;
        CutMe file1;
        public ButtonOnCommand(SaveMe file)
        {
            this.file = file;
        }
        public ButtonOnCommand(CutMe file)
        {
            this.file1 = file;
        }

        public void Execute()
        {
            file.Save();
        }
        public void Undo()
        {
            file.NoSave();
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
