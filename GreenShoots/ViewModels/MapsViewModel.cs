using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GreenShoots.Models;
using GreenShoots.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GreenShoots.ViewModels
{
    public class MapsViewModel : BaseViewModel
    {
        List<ToDoItem> todoItems;

        ToDoItem testTDI = new ToDoItem();

        public List<ToDoItem> ToDoItems { get => todoItems; set => SetProperty(ref todoItems, value); }

        public List<ToDoItem> ToDoItemsCheck { get; set; }

        public ICommand RefreshCommand { get; }
        public ICommand CompleteCommand { get; }

        public MapsViewModel()
        {
            ToDoItems = new List<ToDoItem>();

            RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
            CompleteCommand = new Command<ToDoItem>(async (item) => await ExecuteCompleteCommand(item));
        }

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ToDoItems = await CosmosDBService.GetToDoItems();
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteCompleteCommand(ToDoItem item)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await CosmosDBService.CompleteToDoItem(item);
                ToDoItems = await CosmosDBService.GetToDoItems();
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
