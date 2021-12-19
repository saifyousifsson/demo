using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace customerList.Models
{
    public class ContactPerson
    {
	  public Guid Rabattkod { get; set; }

	  public string FirstName { get; set; }
	  public string LastName { get; set; }
	  public string Email { get; set; }
	  public string RabattKod { get; set; }
	  public object FileHelper { get;  set; }
	  public string FullName => $"{FirstName} {LastName}";
	  public string Guid => RabattKod.ToString().Substring(0,5);
	  public IDictionary<string, IList<string>> FileTypeChoices { get; }
	  public StorageFolder LocalFolder { get; }
	  public PickerViewMode ViewMode { get; set; }
	  public IList<string> FileTypeFilter { get; }
    }

}
