using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessControl
{
    class RemoteControl
    {
        Task _queueListener = null;
        MainWindow _main = null;

        public RemoteControl(MainWindow main)
        {
            _main = main;
        }

        public void Start()
        {
            _queueListener = Task.Factory.StartNew(() => {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("RemoteControl", false, false, false, null);
                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume("RemoteControl", true, consumer);
                        while (true)
                        {
                            var eventArgs = (BasicDeliverEventArgs) consumer.Queue.Dequeue();
                            var body = eventArgs.Body;
                            var message = Encoding.UTF8.GetString(body);
                            switch (message)
                            {
                                case "Add": _main.Dispatcher.Invoke(() => { _main.btnAddText_Click(null, null); }); break;
                                case "Replace": _main.Dispatcher.Invoke(() => { _main.btnReplace_Click(null, null); }); break;
                                case "Clear": _main.Dispatcher.Invoke(() => { _main.btnClear_Click(null, null); }); break;
                                default: break;
                            }
                        }
                    }
                }

            });

        }

    }
}
