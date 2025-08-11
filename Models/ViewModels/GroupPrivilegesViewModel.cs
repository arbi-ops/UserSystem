using System.Collections.Generic;

namespace UserSystem.Models.ViewModels
{
    public class GroupPrivilegesViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public List<PrivilegeCheckbox> Privileges { get; set; }
    }

    public class PrivilegeCheckbox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
