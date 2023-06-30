using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace manage_demo.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }//id
        public string Email { get; set; }//用户邮箱
        public string Phone { get; set; }//用户电话
        public string Name { get; set; }//用户姓名
        public string Account { get; set; }//账号
        public string Password { get; set; }//密码
        public string Address { get; set; }//地址
        public string Permission{ get; set; }//权限
        public string CreateTime { get; set; }
    }
}

