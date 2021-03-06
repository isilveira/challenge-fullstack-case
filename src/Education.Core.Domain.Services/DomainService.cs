﻿using Education.Core.Domain.Entities;
using Education.Core.Domain.Exceptions;
using Education.Core.Domain.Interfaces.Services;
using FluentValidation;
using NetDevPack.Specification;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services
{
    public abstract class DomainService<TEntity> : IDomainService<TEntity>
        where TEntity : DomainEntity
    {
        private AbstractValidator<TEntity> EntityValidator { get; set; }
        private SpecValidator<TEntity> DomainValidator { get; set; }
        public DomainService(AbstractValidator<TEntity> entityValidator, SpecValidator<TEntity> domainValidator)
        {
            EntityValidator = entityValidator;
            DomainValidator = domainValidator;
        }

        protected void ValidateEntity(TEntity entity)
        {
            var validateResult = EntityValidator.Validate(entity);
            if (!validateResult.IsValid)
            {
                var entityExceptions = new List<EntityException>();

                foreach (var error in validateResult.Errors)
                {
                    var errorMessage = string.Format(error.ErrorMessage, error.PropertyName);
                    entityExceptions.Add(new EntityException(error.PropertyName, errorMessage));
                }

                var exception = new BusinessException("Operação falhou na validação de entidade!", entityExceptions, null);

                throw exception;
            }
        }

        protected void ValidateDomain(TEntity entity)
        {
            var validateResult = DomainValidator.Validate(entity);
            if (!validateResult.IsValid)
            {
                var domainExceptions = new List<DomainException>();

                foreach (var error in validateResult.Errors)
                {
                    var errorMessage = string.Format(error.ErrorMessage, error.PropertyName);
                    domainExceptions.Add(new DomainException(errorMessage));
                }

                var exception = new BusinessException("Operação falho na validação de domínio!", null, domainExceptions);

                throw exception;
            }
        }
        public abstract Task Run(TEntity entity);
    }
}
