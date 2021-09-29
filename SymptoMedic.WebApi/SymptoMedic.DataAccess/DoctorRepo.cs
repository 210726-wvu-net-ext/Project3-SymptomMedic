using SymptoMedic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymptoMedic.DataAccess.Entities;

namespace SymptoMedic.DataAccess
{
    public class DoctorRepo: IDoctorRepo
    {
        private readonly symptomedicContext _context;
        public DoctorRepo(symptomedicContext context)
        {
            _context = context;
        }
        public Task<List<Domain.Doctor>> GetDoctors()
        {
            /*Task.FromResult(_context.Doctors
                   .Include(a => a.Appointment)
                   .ThenInclude(c => c.Comments)
                   .Include(s => s.Schedule)
                   .ThenInclude(fu => fu.UserId2Navigation)
                   .Select(u => new Domain.Doctor
                   {
                       Id = u.Id,
                       FirstName = u.FirstName,
                       LastName = u.LastName,
                       Email = u.Email,
                       Username = u.Username,
                       AboutMe = u.AboutMe,
                       State = u.State,
                       Country = u.Country,
                       Role = u.Role,
                       PhoneNumber = u.PhoneNumber,
                       DoB = u.DoB,
                       Comments = u.Comments.Select(c => new Domain.Comment(c.Id, c.UserId, c.User.Username, c.PostId, c.Created, c.CommentBody)).ToList(),
                       Friends = u.FollowerUsers.Select(f => new Domain.Follower(f.Id, f.UserId, f.User.Username, f.UserId2, f.UserId2Navigation.Username, f.FriendRequest)).ToList(),
                       Posts = u.Posts.Select(k => new Domain.Post(k.Id, k.UserId, k.User.Username, k.Image, k.Created, k.Title, k.Body, k.Comments.Select(k => new Domain.Comment(k.Id, k.UserId, k.PostId, k.User.Username, k.Created, k.CommentBody)).ToList())).ToList()
                   }
                ).ToList());*/
                return Task.FromResult(_context.Doctors.Select(
                doctors => new Domain.Doctor
                (
                    doctors.Id,
                    doctors.FirstName,
                    doctors.LastName,
                    doctors.License,
                    doctors.PracticeName,
                    doctors.Email,
                    doctors.PhoneNumber,
                    doctors.DoctorSpeciality,
                    doctors.PracticeAddress,
                    doctors.PracticeCity,
                    doctors.PracticeState,
                    doctors.PracticeZipcode,
                    doctors.Certifications,
                    doctors.Education,
                    doctors.Gender
                 )
            ).ToList());
        }
    }
}
