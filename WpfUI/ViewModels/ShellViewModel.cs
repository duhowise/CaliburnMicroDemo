using System;
using Caliburn.Micro;
using WpfUI.Models;

namespace WpfUI.ViewModels
{
	public class ShellViewModel:Conductor<object>
	{
		private string _firstName;
		private string _lastName;
		private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
		private PersonModel _selectedPerson;

		public ShellViewModel()
		{
			People.Add(new PersonModel {FirstName = "Paul", LastName = "Smith"});
			People.Add(new PersonModel {FirstName = "Sam", LastName = "Smith"});
			People.Add(new PersonModel {FirstName = "Taylor", LastName = "Smith"});
			People.Add(new PersonModel {FirstName = "Patrick", LastName = "Smith"});

		}

		public bool CanClearText(string firstName, string lastName)=> !string.IsNullOrWhiteSpace(firstName)|| !string.IsNullOrWhiteSpace(lastName);
		//{
		//	return string.IsNullOrWhiteSpace(firstName)
		//	       && string.IsNullOrWhiteSpace(lastName);
		//}
		public void ClearText(string firstName,string lastName)
		{
			FirstName = "";
			LastName = "";
		}

		public void LoadPage()
		{
			ActivateItem(new FirstChildViewModel());
		}
		public void LoadPage2()
		{
			ActivateItem(new SecondChildViewModel());
		}
		public string FirstName
		{
			get { return _firstName; }
			set
			{
				_firstName= value;
				NotifyOfPropertyChange(()=>FirstName);
				NotifyOfPropertyChange(()=>FullName);
			}
		}
		public string LastName
		{
			get { return _lastName; }
			set
			{
				_lastName = value;
				NotifyOfPropertyChange(()=>LastName);
				NotifyOfPropertyChange(()=>FullName);
			}
		}
		public string FullName => $"{FirstName} {LastName}";
		public BindableCollection<PersonModel> People	
		{
			get { return _people; }
			set { _people = value; }
		}
		public PersonModel SelectedPerson
		{
			get { return _selectedPerson; }
			set
			{
				_selectedPerson = value;
				NotifyOfPropertyChange(()=>SelectedPerson);
			}
		}


	}
}