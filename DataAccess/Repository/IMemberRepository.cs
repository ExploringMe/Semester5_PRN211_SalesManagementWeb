using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByEmailPassword(string email, string password);
        Member GetMemberByID(int memberID);
        void InsertMember(Member member);
        void DeleteMember(int memberID);
        void UpdateMember(Member member);
        bool CheckEmailDeplicate(string email);
    }
}
