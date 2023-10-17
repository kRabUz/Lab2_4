using Lab2_4.Interfaces;

namespace Lab2_4.Commands
{
    public class ValidateXMLFiles : ICommand
    {
        private readonly IReceiver receiver;
        public ValidateXMLFiles(IReceiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.ValidateXMLFiles();
        }

        public string GetCommandName()
        {
            return "Провалідувати XML-файли";
        }
    }
}
