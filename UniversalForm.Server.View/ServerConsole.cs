using UniversalForm.Server.Persistence;

namespace UniversalForm.Server.View
{
    internal class ServerConsole
    {
        readonly string helpString = """
            Inputs are:
            register    -   Register a new admin user.
            delete user -   Delete an existing admin user.
            stop        -   Stop the server application.
            """;
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
                        case "delete user":
                            DeleteUser();
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
            while (!_server.UsernameAvailable(username))
            {
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
        private void DeleteUser()
        {
            Console.WriteLine("Enter username to delete or 'cancel' to cancel:");
            string? input = Console.ReadLine();
            if (input == null)
                return;
            else if (input == "cancel")
                return;
            var run = true;
            while (run)
            {
                Console.WriteLine("Enter password:");
                string? password = Console.ReadLine();
                if (password == null)
                    run = false;
                else
                {
                    var result = _server.DeleteAdmin(input, password);
                    switch (result)
                    {
                        case IPersistence.LoginResult.SUCCESS:
                            Console.WriteLine("User deleted successfully.");
                            run = false;
                            break;
                        case IPersistence.LoginResult.USER_NOT_FOUND:
                            Console.WriteLine("User not found.");
                            run = false;
                            break;
                        case IPersistence.LoginResult.PASSWORD_INCORRECT:
                            Console.WriteLine("Incorrect password.");
                            break;
                        case IPersistence.LoginResult.IO_ERROR:
                        default:
                            Console.WriteLine("Failed to delete user.");
                            run = false;
                            break;
                    }
                }

            }
        }
    }
}
