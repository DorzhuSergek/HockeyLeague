using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyLeague
{
    partial class HockeyLeagueEntities
    {
        public static HockeyLeagueEntities _context;
        public static HockeyLeagueEntities GetContext()
        {
            if (_context == null)
                _context = new HockeyLeagueEntities();
            return _context;
        }
    }
}
