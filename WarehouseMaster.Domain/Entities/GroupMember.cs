﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMaster.Domain.Entities
{
    public class GroupMember: BaseEntity
    {
        public GroupChatRoom? Group { get; set; }
        public int GroupId { get; set; }
        public Person Person { get; set; } = new Person();
        public int PersonId { get; set; }
        public int AddedByPerson {  get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsLeaved { get; set; }
    }
}
