using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intersales.Qstep.Persistence.Sqlbase
{
    public class Reflector
    {
        public static void Do()
        {
            var type = "Unify.SQLBase.Data.SQLBaseConnection";
            //var assembly = "Unfiy.SQLBase.Data.dll";
            var assembly = "Unify.SQLBase.Data, Version=11.6.2.7910, Culture=neutral, PublicKeyToken=b64f610276873336";
            //ReflectHelper.TypeFromAssembly(type, assembly, true);
            var name = new AssemblyQualifiedTypeName(type, assembly);
            var assembly2 = Assembly.Load(name.Assembly);
        }
    }
}
