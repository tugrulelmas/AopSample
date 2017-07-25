using AopSample.DTOs;
using AopSample.Exceptions;
using AopSample.Helper;
using AopSample.Repositories;
using System;

namespace AopSample.Validation
{
    public class UserValidator : CustomValidator<UserDTO>
    {
        private readonly IUserRepository repository;

        public UserValidator(IUserRepository repository) {
            this.repository = repository;
        }

        public override void Validate(UserDTO instance, ActionType actionType) {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            if (actionType == ActionType.Add) {
                if (string.IsNullOrEmpty(instance.Name))
                    throw new DenialException("UserNameIsEmpty");

                if (string.IsNullOrEmpty(instance.Email))
                    throw new DenialException("UserEmailIsEmpty");

                var user = repository.Get(instance.Email);
                if(user != null)
                    throw new DenialException("UserIsAlreadyRegistered");
            } else {
                if (instance.Id == Guid.Empty)
                    throw new DenialException("UserIdIsEmpty");
            }
        }
    }
}