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
    public class ItemDetailViewModel : BaseViewModel
    {
        public List<ToDoItem> ToDoItemsCheck { get; set; }

        string testChallengeName; 

        bool isNew;
        public bool IsNew
        {
            get => isNew;
            set => SetProperty(ref isNew, value);
        }

        private string nameCategoryNew;
        public string NameCategoryNew
        {
            get => nameCategoryNew;
            set
            {
                nameCategoryNew = value;
                // OnPropertyChanged();
                HandlePropertyChanged();
            }
        }

        public ItemDetailViewModel()
        {
        }

        public ToDoItem ToDoItem { get; set; }
        public ICommand SaveCommand { get; }

        public event EventHandler SaveComplete;

        public ItemDetailViewModel(ToDoItem todo, bool isNew)
        {
            IsNew = isNew;
            ToDoItem = todo;

            testChallengeName = todo.NameNew;

            SaveCommand = new Command(async () => await ExecuteSaveCommand());

            Title = IsNew ? "Notes" : ToDoItem.NameNew;

            SaveCommand.Execute(null);
        }

        async Task ExecuteSaveCommand()
        {
            var id = Preferences.Get("my_id", string.Empty);
            if (string.IsNullOrWhiteSpace(id))
            {
                id = System.Guid.NewGuid().ToString();
                Preferences.Set("my_id", id);
            }

            ToDoItemsCheck = await CosmosDBService.GetToDoItems();

            Boolean found = false;
            foreach (ToDoItem student in ToDoItemsCheck)
            {
                if (student.NameNew.Contains(testChallengeName))
                {
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                ToDoItem.ValGUID = id;
                await CosmosDBService.InsertToDoItem(ToDoItem);
            }

            SaveComplete?.Invoke(this, new EventArgs());
        }

    }
}
