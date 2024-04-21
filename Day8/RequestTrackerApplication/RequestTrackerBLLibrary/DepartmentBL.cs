using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly DepartmentRepository _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var department = _departmentRepository.GetDepartmentByName(departmentOldName);
            if (department == null)
            {
                throw new DepartmentNotFoundException();
            }

            var existingDepartment = _departmentRepository.GetDepartmentByName(departmentNewName);
            if (existingDepartment != null)
            {
                throw new DuplicateDepartmentNameException();
            }

            department.Name = departmentNewName;
            return _departmentRepository.Update(department);
        }

        public Department GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                throw new DepartmentNotFoundException();
            }
            return department;
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var department = _departmentRepository.GetDepartmentByName(departmentName);
            if (department == null)
            {
                throw new DepartmentNotFoundException();
            }
            return department;
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var department = _departmentRepository.Get(departmentId);
            if (department == null)
            {
                throw new DepartmentNotFoundException();
            }
            return department.Department_Head;
        }

        public List<Department> GetDepartmentList()
        {
            var departments = _departmentRepository.GetAll();
            if (departments == null || departments.Count == 0)
            {
                throw new NoDepartmentsFoundException();
            }
            return departments;
        }
    }
}
