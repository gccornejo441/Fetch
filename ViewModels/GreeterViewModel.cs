using CommunityToolkit.Mvvm.ComponentModel;
using Fetch.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.ViewModels
{
    public partial class GreeterViewModel : BaseViewModel
    {
        private readonly Greeter.GreeterClient _client;

        [ObservableProperty]
        string greetingMessage;

        public GreeterViewModel(Greeter.GreeterClient client)
        {
            _client = client;
            GreetingMessage = "Hello, world!";
        }

        public async Task GreetAsync()
        {
            try
            {
                var res = await _client.SayHelloAsync(new HelloRequest { Name = "Megan" });
                GreetingMessage = res.Message;

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}
