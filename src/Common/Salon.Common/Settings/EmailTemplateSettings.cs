namespace Salon.Common.Settings
{
    public class EmailTemplateSettings
    {
        public EmailTemplate NewOrder { get; set; }

        public EmailTemplate NewEntity { get; set; }

        public EmailTemplate ActivateNewUser { get; set; }

        public EmailTemplate OrderWasShipped { get; set; }

        public EmailTemplate ResetPassword { get; set; }
    }
}