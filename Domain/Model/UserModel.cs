namespace Domain.Model
{
    public class UserModel
    {
        public Guid id { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? gender { get; set; }
        public string? organization { get; set; }
        public bool isactive { get; set; }
        public bool requirespasswordrest { get; set; }
    }
}
