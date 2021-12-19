using customerList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace customerList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static List<ContactPerson> contacts = new List<ContactPerson>();	

	  public object WriteTextFile { get; private set; }
	  public object FutureAccessList { get; private set; }

	  public MainPage()
        {
            this.InitializeComponent();

        }
        private async void btnAdd_Click(object sender, RoutedEventArgs e)
            {
		var savePicker = new Windows.Storage.Pickers.FileSavePicker();
		savePicker.SuggestedStartLocation =
		 Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
		
		savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
		
		savePicker.SuggestedFileName = "New Document";

		if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text))
		{

		    contacts.Add(new ContactPerson
		    {
			  Rabattkod = Guid.NewGuid(),
			  FirstName = tbFirstName.Text,
			  LastName = tbLastName.Text,
			  Email = tbEmail.Text,
			 // RabattKod = tbRabattkod.Text ??""

		    }
		);
		    lvContacts.ItemsSource = new List<Object>();
		   
		    lvContacts.ItemsSource = contacts;
		
		    FileOpenPicker openPicker = new FileOpenPicker();
		    openPicker.ViewMode = PickerViewMode.Thumbnail;
		    openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
		    openPicker.FileTypeFilter.Add( ".txt");
		  // StorageFile file = await openPicker.PickSingleFileAsync();
		   StorageFile file = await savePicker.PickSaveFileAsync();
		    CachedFileManager.DeferUpdates(file);
		    await Windows.Storage.FileIO.AppendTextAsync(file, $"{tbFirstName.Text}, {tbLastName.Text},{ tbEmail.Text},\r\n");  
		}
	  }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var x = lvContacts.SelectedItem;
            lvContacts.SelectedItem = null;
            contacts.Remove(x as ContactPerson);
            lvContacts.ItemsSource = null;
            lvContacts.ItemsSource = contacts;

        }

    }

	  }
        
    
    
    
    
    

