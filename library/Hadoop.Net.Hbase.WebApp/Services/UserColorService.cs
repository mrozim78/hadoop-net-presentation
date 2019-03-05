using System.Threading.Tasks;
using Hadoop.Net.Hbase.WebApp.Model;
using Hadoop.Net.Hbase.WebApp.Repository;

namespace Hadoop.Net.Hbase.WebApp
{
    public class UserColorService:IUserColorService
    {
        private IUserColorRepository _userColorRepository;
        public UserColorService(IUserColorRepository userColorRepository)
        {
            _userColorRepository = userColorRepository;
        }

        public void AddUserColor(UserHtmlColor userHtmlColor)
        {
            _userColorRepository.AddUserColor(userHtmlColor);
        }
    }
}