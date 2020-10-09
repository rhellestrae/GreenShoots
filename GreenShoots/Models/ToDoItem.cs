using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms;

namespace GreenShoots.Models
{
    public class ToDoItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ToDoItem()
        {
        }

		string _id;
		[JsonProperty("id")]
		public string Id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;

				_id = value;

				HandlePropertyChanged();
			}
		}

		string _valGUID;
		[JsonProperty("valGUID")]
		public string ValGUID
		{
			get => _valGUID;
			set
			{
				if (_valGUID == value)
					return;

				_valGUID = value;

				HandlePropertyChanged();
			}
		}

		string _euroCapital;
		[JsonProperty("euroCapital")]
		public string EuroCapital
		{
			get => _euroCapital;
			set
			{
				if (_euroCapital == value)
					return;

				_euroCapital = value;

				HandlePropertyChanged();
			}
		}

		string _name;
		[JsonProperty("name")]
		public string NameNew
		{
			get => _name;
			set
			{
				if (_name == value)
					return;

				_name = value;

				HandlePropertyChanged();
			}
		}

		ImageSource imageBadge;
		public ImageSource ContactImage
		{
			get { return this.imageBadge; }
			set
			{
				this.imageBadge = value;

				HandlePropertyChanged();
			}
		}

		string _category;
		[JsonProperty("category")]
		public string Category
		{
			get => _category;
			set
			{
				if (_category == value)
					return;

				_category = value;

				HandlePropertyChanged();
			}
		}

		string _description;
		[JsonProperty("description")]
		public string Description
		{
			get => _description;
			set
			{
				if (_description == value)
					return;

				_description = value;

				HandlePropertyChanged();
			}
		}

		bool _completed;
		[JsonProperty("isComplete")]
		public bool Completed
		{
			get => _completed;
			set
			{
				if (_completed == value)
					return;

				_completed = value;

				HandlePropertyChanged();
			}
		}

		void HandlePropertyChanged([CallerMemberName] string propertyName = "")
		{
			var eventArgs = new PropertyChangedEventArgs(propertyName);

			PropertyChanged?.Invoke(this, eventArgs);
		}

	}
}
