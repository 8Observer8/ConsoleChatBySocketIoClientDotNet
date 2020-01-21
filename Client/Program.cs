using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаём сокет
            //var socket = Quobject.SocketIoClientDotNet.Client.IO.Socket("http://localhost:1337");
            //var socket = Quobject.SocketIoClientDotNet.Client.IO.Socket("ws://127.0.0.1:1337/socket.io/?EIO=4&transport=websocket");
            var socket = Quobject.SocketIoClientDotNet.Client.IO.Socket("ws://socketioclientdotnet-js.herokuapp.com");

            // Принимаем сообщение и выводим на экран
            socket.On("message", (data) =>
            {
                // Переходим на новую строку
                Console.WriteLine();
                // Выводим принятое сообщение на экран
                Console.WriteLine("Ответ: " + data);
                // Выводим приглашение ввести сообщение
                Console.Write("Введите сообщение: ");
            });

            while (true)
            {
                // Выводим приглашение ввести сообщение
                Console.Write("Введите сообщение: ");
                // Читаем сообщение из консоли
                string mess = Console.ReadLine();
                // Отправляем сообщение на сервер
                socket.Emit("message", mess);
            }
        }
    }
}
