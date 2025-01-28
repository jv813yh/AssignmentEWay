using MVVMEssentials.ViewModels;
using System.IO;
using System.Windows.Media.Imaging;

namespace AssignmentEWay.WPF.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        public string ItemGuid { get; set; }
        public string OwnerGuid { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string BusinessAddressCity { get; set; } 
        public string BusinessAddressStreet { get; set; } 
        public string BusinessAddressPostalCode { get; set; } 
        public string BusinessAddressState { get; set; } 
        public string Company { get; set; } 
        public string Department { get; set; } 
        public string EmailAddress { get; set; } 
        public string HomeAddressCity { get; set; } 
        public string HomeAddressStreet { get; set; }
        public string HomeAddressState { get; set; } 
        public string ProfilePictureBase64 { get; set; } 
        public string Title { get; set; } 
        public string PhoneNumber1 { get; set; }

        public BitmapImage ProfilePicture 
            => ConvertBase64ToImage(ProfilePictureBase64);

        private BitmapImage ConvertBase64ToImage(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return null;

            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (var ms = new MemoryStream(imageBytes))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze(); // Correct for WPF
                    return bitmap;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error decoding Base64 image: {ex.Message}");
                return null;
            }
        }
    }
}
