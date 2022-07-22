using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace DataAccess
{
    public class MemberDAO
    {
        FStoreContext FStoreDB;
        public MemberDAO()
        {
            FStoreDB = new FStoreContext();
        }
        public static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        //
        public Member GetMemberByID(int MemberID)
        {
            Member member = null;
            foreach (Member m in FStoreDB.Members)
            {
                if (m.MemberId == MemberID)
                    member = m;
            }
            return member;
        }
        public Member GetMemberByEmailPassword(string email, string password)
        {
            Member member = null;
            foreach (Member m in FStoreDB.Members)
            {
                if (m.Email == email && m.Password ==password)
                    member = m;
            }
            return member;
        }
        public IEnumerable<Member> GetMembers()
        {
            var membersList = new List<Member>();
            foreach (var m in FStoreDB.Members)
            {
                membersList.Add(m);
            }
            return membersList;
        }
        public void AddMember(Member member)
        {
            try
            {
                member.MemberId = 0;
                FStoreDB.Members.Add(member);
                FStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateMember(Member member)
        {
            try
            {
                var m = GetMemberByID(member.MemberId);
                m.Email = member.Email;
                m.CompanyName = member.CompanyName;
                m.City = member.City;
                m.Country = member.Country;
                m.Password = member.Password;
                FStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteMember(int memberID)
        {
            try
            {
                Member member = GetMemberByID(memberID);
                FStoreDB.Members.Remove(member);
                FStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CheckEmailDuplicate(string email)
        {
            foreach (var checkEmail in FStoreDB.Members)
            {
                if (email.Equals(checkEmail.Email))
                {
                    return false;
                } 
            }
            return true;
        }
    }
}
