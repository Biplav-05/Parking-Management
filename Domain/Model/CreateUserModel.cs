namespace Domain.Model
{
    public class CreateUserModel
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? gender { get; set; }
        public string? address { get; set; }
        public string? organization { get; set; }
    }
}
