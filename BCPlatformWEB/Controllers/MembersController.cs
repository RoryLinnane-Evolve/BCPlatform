using BCPlatformWEB.Data;
using BCPlatformWEB.Models.Domain;
using BCPlatformWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;

namespace BCPlatformWEB.Controllers
{
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext dBContext;

        public MembersController(ApplicationDbContext DBContext)
        {
            dBContext = DBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var members = await dBContext.Members.ToListAsync();
            return View(members);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMemberViewModel addMemberRequest)
        {
            var member = new Member()
            {
                Id = new Guid(),
                BI_PIN=addMemberRequest.BI_PIN,
                ClubId=new Guid("12312312-1231-1231-1231-123123123123"),
                Name=addMemberRequest.Name,
                DateOfBirth=addMemberRequest.DateOfBirth,
                Gender=addMemberRequest.Gender,
                Address=addMemberRequest.Address,
                Email=addMemberRequest.Email,
                PhoneNumber=addMemberRequest.PhoneNumber,
                MedicalConditions=addMemberRequest.MedicalConditions,
                EmergencyContactNumber  =addMemberRequest.EmergencyContactNumber,
                EmergencyContactRelationship= addMemberRequest.EmergencyContactRelationship,
                Allergies=addMemberRequest.Allergies,
                MedicalNotes=addMemberRequest.MedicalNotes,
                CountryOfBirth=addMemberRequest.CountryOfBirth,
                ParentName=addMemberRequest.ParentName,
                ParentEmail=addMemberRequest.ParentEmail,
                ParentPhoneNumber=addMemberRequest.ParentPhoneNumber,
                RoleId=1,
                RegistrarEmail = HttpContext.User.Identity.Name,
                DateRegistered=DateTime.Now,
                Payed=false
            };

            await dBContext.Members.AddAsync(member);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>View(Guid id)
        {
            var member = await dBContext.Members.FirstOrDefaultAsync(x=>x.Id==id);

            if (member != null)
            {
                var viewModel = new UpdateMemberViewModel()
                {
                    Id = member.Id,
                    BI_PIN = member.BI_PIN,
                    ClubId = member.ClubId,
                    Name = member.Name,
                    DateOfBirth = member.DateOfBirth,
                    Gender = member.Gender,
                    Address = member.Address,
                    Email = member.Email,
                    PhoneNumber = member.PhoneNumber,
                    MedicalConditions = member.MedicalConditions,
                    EmergencyContactNumber = member.EmergencyContactNumber,
                    EmergencyContactRelationship = member.EmergencyContactRelationship,
                    Allergies = member.Allergies,
                    MedicalNotes = member.MedicalNotes,
                    CountryOfBirth = member.CountryOfBirth,
                    ParentName = member.ParentName,
                    ParentEmail = member.ParentEmail,
                    ParentPhoneNumber = member.ParentPhoneNumber,
                    RoleId = member.RoleId,
                    RegistrarEmail = member.RegistrarEmail,
                    Payed = member.Payed
                };
                return await Task.Run(() => View("View", viewModel));
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> View(UpdateMemberViewModel model)
        {
            var employee = await dBContext.Members.FindAsync(model.Id);

            if (employee != null) {
                employee.Id = model.Id;
                employee.BI_PIN = model.BI_PIN;
                employee.ClubId = model.ClubId;
                employee.Name = model.Name;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Gender = model.Gender;
                employee.Address = model.Address;
                employee.Email = model.Email;
                employee.PhoneNumber = model.PhoneNumber;
                employee.MedicalConditions = model.MedicalConditions;
                employee.EmergencyContactNumber = model.EmergencyContactNumber;
                employee.EmergencyContactRelationship = model.EmergencyContactRelationship;
                employee.Allergies = model.Allergies;
                employee.MedicalNotes = model.MedicalNotes;
                employee.CountryOfBirth = model.CountryOfBirth;
                employee.ParentName = model.ParentName;
                employee.ParentEmail = model.ParentEmail;
                employee.ParentPhoneNumber = model.ParentPhoneNumber;
                employee.RoleId = model.RoleId;
                //employee.RegistrarEmail = model.RegistrarEmail;
                employee.Payed = model.Payed;

                await dBContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateMemberViewModel model)
        {
            var member = await dBContext.Members.FindAsync(model.Id);
            if(member !=null)
            {
                dBContext.Members.Remove(member);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
