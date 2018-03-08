using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ticketbus.Logic.DTO;
using ticketbus.Logic.Interfaces;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;

namespace ticketbus.WEB.Providers
{
    public class CustomRoleProvider : RoleProvider
    {

        private IUserService UserRepository;

        public CustomRoleProvider()
        {
            UserRepository = DependencyResolver.Current.GetService<IUserService>();
        }
        
        public override string[] GetRolesForUser(string username)
        {
           
            UserDTO user = UserRepository.FindUser(username);

            string[] roles = new string[] { };

            if(user!=null && user.UserRole != null)
            {
                roles = new string[] { user.UserRole.Name };
            }
            return roles;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            UserDTO user = UserRepository.FindUser(username);

            if (user != null && user.UserRole != null && user.UserRole.Name == roleName)
                return true;
            else
                return false;
        }


        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}