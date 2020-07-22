namespace ViewingsApp.Models.ViewModel
{
    public class BookingValidation
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public static BookingValidation Valid()
        {
            return new BookingValidation { IsValid = true, ErrorMessage = "" };
        }

        public static BookingValidation InValid(string errorMessage)
        {
            return new BookingValidation { IsValid = false, ErrorMessage = errorMessage };
        }
    }
}