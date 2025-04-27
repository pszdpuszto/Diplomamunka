using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Server.Model;

namespace UniversalForm.Server.View
{
    internal class ServerConsole
    {
        readonly string helpString = "Inputs are:\n\tregister\t-\tRegister a new admin user.\n\tstop\t-\tStop the server application.";
        Model.Server _server;
        bool _isRunning = false;
        public ServerConsole(Model.Server server)
        {
            _server = server;
        }
        public void Start()
        {
            Task serverTask = Task.Run(() => _server.Start());
        }
        public void Stop()
        {
            _server.Stop();
        }
        public void ReadConsole()
        {
            Console.WriteLine(helpString);
            _isRunning = true;
            while (_isRunning)
            {
                string? input = Console.ReadLine();
                if (input == null)
                    _isRunning = false;
                else
                    switch (input)
                    {
                        case "register":
                            RegisterUser();
                            break;
                        case "stop":
                            Console.WriteLine("Stopping the server...");
                            _isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Unknown command: \"" + input + "\"\n" + helpString);
                            break;
                    }
            }
        }

        private void RegisterUser()
        {
            Console.WriteLine("Registering a new admin user...");
            Console.Write("Enter username: ");
            string password;
            string confirmPassword;
            string username = Console.ReadLine() ?? string.Empty;
            while (!_server.UsernameAvailable(username)) {
                Console.WriteLine("Username already taken. Please choose another one.\nEnter username: ");
                username = Console.ReadLine() ?? string.Empty;
            }
            bool invalid;
            do
            {
                invalid = false;
                Console.Write("Enter password (at least 8 characters): ");
                password = Console.ReadLine() ?? string.Empty;
                if (password.Length < 8)
                {
                    Console.WriteLine("Password must be at least 8 characters long.");
                    invalid = true;
                    continue;
                }
                Console.Write("Confirm password: ");
                confirmPassword = Console.ReadLine() ?? string.Empty;
                if (password != confirmPassword)
                {
                    Console.WriteLine("Passwords do not match. Please try again.");
                    invalid = true;
                }
            } while (invalid);

            if (_server.RegisterAdmin(username, password))
                Console.WriteLine("Admin registered successfully.");
            else
                Console.WriteLine("Failed to register admin. Please try again.");
        }
    }
}
