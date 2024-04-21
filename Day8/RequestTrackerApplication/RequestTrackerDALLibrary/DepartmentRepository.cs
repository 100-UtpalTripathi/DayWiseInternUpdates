using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RequestTrackerDALLibrary
{
    public class DepartmentRepository : BaseRepository<Department>
    {
        public Department GetDepartmentByName(string departmentName)
        {
            foreach (var department in _data.Values) {
                if(department.Name == departmentName)
                    return department;
            }
            return null;
        }
    }
}
