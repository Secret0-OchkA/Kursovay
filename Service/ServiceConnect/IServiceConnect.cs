using Domain.Model;
using Repository.RepositoryPattern;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceConnect
{
    public interface IServiceConnectRead<ParentType, ChieldType>
        where ChieldType : BaseDbEntity
        where ParentType : BaseDbEntity
    {
        ChieldType Get(int parentId);
        IEnumerable<ChieldType> GetAll(int parentId);
    }
    public interface IServiceConnectAdd<ParentType, ChieldType>
        where ChieldType : BaseDbEntity
        where ParentType : BaseDbEntity
    {
        void Add(int parentId, ChieldType entity);
    }
    public interface IServiceConnectDelete<ParentType, ChieldType>
        where ChieldType : BaseDbEntity
        where ParentType : BaseDbEntity
    {
        void Delete(int parentId, int chieldId);
    }
}
