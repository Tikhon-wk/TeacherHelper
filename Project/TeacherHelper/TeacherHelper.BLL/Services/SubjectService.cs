using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelper.BLL.Interfaces;
using TeacherHelper.BLL.ModelsDTO;
using TeacherHelper.DAL.Repositories;

namespace TeacherHelper.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        private SubjectRepository repository;
        public SubjectService(SubjectRepository repository)
        {
            this.repository = repository;
        }
        public void Create(SubjectDTO data)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubjectDTO data)
        {
            throw new NotImplementedException();
        }

        public SubjectDTO Read(string id)
        {
            throw new NotImplementedException();
        }

        public List<SubjectDTO> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SubjectDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
