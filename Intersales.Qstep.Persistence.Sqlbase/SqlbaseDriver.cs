﻿using System.Data;
using NHibernate.Engine.Query;
using NHibernate.SqlTypes;
using NHibernate.Driver;

namespace Intersales.Qstep.Persistence.Sqlbase
{
    /// <summary>
    /// A NHibernate Driver for using the Oracle DataProvider.
    /// </summary>
    public class SqlbaseDriver : ReflectionBasedDriver
    {
        private static readonly SqlType GuidSqlType = new SqlType(DbType.Binary, 16);

        public SqlbaseDriver() :
            base(
            "Unify.SQLBase.Data",
            "Unify.SQLBase.Data, Version=11.6.2.7910, Culture=neutral, PublicKeyToken=b64f610276873336",
            "Unify.SQLBase.Data.SQLBaseConnection",
            "Unify.SQLBase.Data.SQLBaseCommand") { }

        public override bool UseNamedPrefixInSql
        {
            get { return true; }
        }

        public override bool UseNamedPrefixInParameter
        {
            get { return true; }
        }

        public override string NamedPrefix
        {
            get { return ":"; }
        }

        protected override void InitializeParameter(IDbDataParameter dbParam, string name, SqlType sqlType)
        {
            if (sqlType.DbType == DbType.Guid)
            {
                base.InitializeParameter(dbParam, name, GuidSqlType);
            }
            else
            {
                base.InitializeParameter(dbParam, name, sqlType);
            }
        }

        protected override void OnBeforePrepare(IDbCommand command)
        {
            base.OnBeforePrepare(command);

            CallableParser.Detail detail = CallableParser.Parse(command.CommandText);

            if (!detail.IsCallable)
                return;

            throw new System.NotImplementedException(GetType().Name +
                " does not support CallableStatement syntax (stored procedures)." +
                " Consider using OracleDataClientDriver instead.");
        }
    }
}