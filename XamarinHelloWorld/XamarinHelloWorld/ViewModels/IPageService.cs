using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinHelloWorld.ViewModels
{
    public interface IPageService
    {
        Task PushAsync(Page page); //para navigation
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        
    }
}
