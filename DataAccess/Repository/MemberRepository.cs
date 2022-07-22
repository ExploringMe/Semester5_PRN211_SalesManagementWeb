using BusinessObject;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMembers();
        public Member GetMemberByEmailPassword(string email, string password) => MemberDAO.Instance.GetMemberByEmailPassword(email, password);
        public Member GetMemberByID(int memberID) => MemberDAO.Instance.GetMemberByID(memberID);
        public void InsertMember(Member member) => MemberDAO.Instance.AddMember(member);
        public void DeleteMember(int memberID) => MemberDAO.Instance.DeleteMember(memberID);
        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
        public bool CheckEmailDeplicate(string email) => MemberDAO.Instance.CheckEmailDuplicate(email);
    }
}
