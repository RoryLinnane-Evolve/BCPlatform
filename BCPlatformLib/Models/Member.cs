namespace BCPlatformLib.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string BI_PIN { get; set; }
        public Guid ClubId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MedicalConditions { get; set; }
        public string? EmergencyContactNumber { get; set; }
        public string? EmergencyContactRelationship { get;set; }
        public string? Allergies { get; set; }
        public string? MedicalNotes { get; set; }
        public string? CountryOfBirth{ get; set; }
        public string? ParentName { get; set; }
        public string? ParentEmail { get; set; }
        public string? ParentPhoneNumber{ get; set; }
        public int RoleId { get; set; }
        public string RegistrarEmail { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool Payed { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Member()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        public Member(Guid id, string bI_PIN, Guid clubId, string name, DateTime dateOfBirth, string gender, string address, string? email, string? phoneNumber, string? medicalConditions, string? emergencyContactNumber, string? emergencyContactRelationship, string? allergies, string? medicalNotes, string? countryOfBirth, string? parentName, string? parentEmail, string? parentPhoneNumber, int roleId, string registrarEmail, DateTime dateRegistered, bool payed)
        {
            Id = id;
            BI_PIN = bI_PIN;
            ClubId = clubId;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            MedicalConditions = medicalConditions;
            EmergencyContactNumber = emergencyContactNumber;
            EmergencyContactRelationship = emergencyContactRelationship;
            Allergies = allergies;
            MedicalNotes = medicalNotes;
            CountryOfBirth = countryOfBirth;
            ParentName = parentName;
            ParentEmail = parentEmail;
            ParentPhoneNumber = parentPhoneNumber;
            RoleId = roleId;
            RegistrarEmail = registrarEmail;
            DateRegistered = dateRegistered;
            Payed = payed;
        }
    }
}
