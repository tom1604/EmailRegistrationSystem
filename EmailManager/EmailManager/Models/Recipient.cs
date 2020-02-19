namespace EmailManager.Models
{
    public class Recipient
    {
        public Recipient(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
