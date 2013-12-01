﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Repositories;

namespace UniCloud.Domain.Services
{
    public class DomainService : IDomainService
    {
        #region Private Fields
        private readonly IRepositoryContext _repositoryContext;

        #endregion

        #region Ctor
        public DomainService(IRepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;

        }
        #endregion

        #region IDomainService Members

        #endregion
    }
}
