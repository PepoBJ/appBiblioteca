using System.Collections.Generic;

namespace _00_DataBase.Repository
{
    public interface RepoGeneric<Dto>
    {
        bool Insert(Dto dto);
        Dto GetByPrimaryKey(string primaryKey);
        bool Edit(Dto dto);
        bool Delete(string primaryKey);
        List<Dto> GetAll();
    }
}